using System.Collections;
using System.Collections.Generic;
using System.Text;
using Cysharp.Threading.Tasks;
using NextGenDialogue.VITS;
using NextGenDialogue.VITS.Example;
using R3;
using UnityEngine;
using UnityEngine.UI;

namespace NextGenDialogue.Example
{
    public class BubbleDialogueUI : MonoBehaviour
    {
        [SerializeField]
        private Text mainText;
        
        [SerializeField]
        private Transform optionPanel;
        
        private readonly List<VitsOptionUI> optionSlots = new();
        
        [SerializeField]
        private VitsOptionUI optionPrefab;
        
        private DialogueSystem _dialogueSystem;
        
        [SerializeField]
        private AudioSource audioSource;
        
        public int BubbleMaxWord => IsChinese ? 15 : 30;
        
        [field: SerializeField]
        public bool IsChinese { get; set; }
        
        [SerializeField]
        private CanvasGroup bubbleGroup;
        
        private void Start()
        {
            _dialogueSystem = DialogueSystem.Get();
            _dialogueSystem.OnDialogueOver.Subscribe(DialogueOverHandler).AddTo(this);
            _dialogueSystem.OnPiecePlay.Subscribe(PlayDialoguePiece).AddTo(this);
            _dialogueSystem.OnOptionCreate.Subscribe(CreateOption).AddTo(this);
        }
        
        private void DialogueOverHandler(Unit _)
        {
            StopCoroutine(nameof(WaitOver));
            StartCoroutine(nameof(WaitOver));
        }
        
        private IEnumerator WaitOver()
        {
            yield return new WaitForSeconds(1f);
            bubbleGroup.alpha = 0;
            CleanUp();
        }

        private void PlayDialoguePiece(IPieceResolver resolver)
        {
            StopCoroutine(nameof(WaitOver));
            CleanUp();
            bubbleGroup.alpha = 1;
            StartCoroutine(PlayText(resolver.DialoguePiece.Contents, ((VITSPieceResolver)resolver).AudioClips, () => resolver.ExitPiece().Forget()));
        }
        
        private readonly StringBuilder _stringBuilder = new();
        
        private IEnumerator PlayText(string[] contents, AudioClip[] audioClips, System.Action callBack)
        {
            for (int index = 0; index < contents.Length; ++index)
            {
                var text = contents[index];
                var clip = audioClips[index];
                audioSource.clip = clip;
                audioSource.Play();
                WaitForSeconds seconds = new(clip.length / text.Length);
                int count = text.Length;
                mainText.text = string.Empty;
                _stringBuilder.Clear();
                for (int i = 0; i < count; i++)
                {
                    if (_stringBuilder.Length > BubbleMaxWord)
                    {
                        if (IsChinese || text[i - 1] == ' ')
                            _stringBuilder.Clear();
                    }

                    _stringBuilder.Append(text[i]);
                    mainText.text = _stringBuilder.ToString();
                    yield return seconds;
                }
            }

            callBack?.Invoke();
        }
        
        private void CreateOption(IOptionResolver resolver)
        {
            foreach (var option in resolver.DialogueOptions)
            {
                VitsOptionUI optionSlot = GetOption();
                optionSlots.Add(optionSlot);
                optionSlot.UpdateOption(option, opt => ClickOptionCoroutine(resolver, opt).Forget());
            }
        }
        
        private async UniTask ClickOptionCoroutine(IOptionResolver resolver, Option opt)
        {
            await resolver.ClickOption(opt);
            CleanUp();
        }
        
        private void CleanUp()
        {
            mainText.text = string.Empty;
            foreach (var slot in optionSlots) Destroy(slot.gameObject);
            optionSlots.Clear();
        }
        
        private VitsOptionUI GetOption()
        {
            return Instantiate(optionPrefab, optionPanel);
        }
    }
}
