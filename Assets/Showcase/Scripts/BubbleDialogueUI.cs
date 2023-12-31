using System.Collections;
using System.Collections.Generic;
using System.Text;
using Kurisu.NGDT.VITS.Example;
using UnityEngine;
using UnityEngine.UI;
namespace Kurisu.NGDS.Example
{
    public class BubbleDialogueUI : MonoBehaviour
    {
        [SerializeField]
        private Text mainText;
        [SerializeField]
        private Transform optionPanel;
        private readonly List<VITSOptionUI> optionSlots = new();
        [SerializeField]
        private VITSOptionUI optionPrefab;
        private IDialogueSystem dialogueSystem;
        [SerializeField]
        private AudioSource audioSource;
        public int BubbleMaxWord => IsChinese ? 15 : 30;
        [field: SerializeField]
        public bool IsChinese { get; set; }
        [SerializeField]
        private CanvasGroup bubbleGroup;
        private void Start()
        {
            dialogueSystem = IOCContainer.Resolve<IDialogueSystem>();
            dialogueSystem.OnDialogueOver += DialogueOverHandler;
            dialogueSystem.OnPiecePlay += PlayDialoguePiece;
            dialogueSystem.OnOptionCreate += CreateOption;
        }
        private void DialogueOverHandler()
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
        private void OnDestroy()
        {
            dialogueSystem.OnDialogueOver -= DialogueOverHandler;
            dialogueSystem.OnPiecePlay -= PlayDialoguePiece;
            dialogueSystem.OnOptionCreate -= CreateOption;
        }
        private void PlayDialoguePiece(IPieceResolver resolver)
        {
            StopCoroutine(nameof(WaitOver));
            CleanUp();
            bubbleGroup.alpha = 1;
            StartCoroutine(PlayText(resolver.DialoguePiece.Content, () => StartCoroutine(resolver.ExitPiece())));
        }
        private readonly StringBuilder stringBuilder = new();
        private IEnumerator PlayText(string text, System.Action callBack)
        {
            WaitForSeconds seconds = new(audioSource.clip.length / text.Length);
            int count = text.Length;
            mainText.text = string.Empty;
            stringBuilder.Clear();
            for (int i = 0; i < count; i++)
            {
                if (stringBuilder.Length > BubbleMaxWord)
                {
                    if (IsChinese || text[i - 1] == ' ')
                        stringBuilder.Clear();
                }
                stringBuilder.Append(text[i]);
                mainText.text = stringBuilder.ToString();
                yield return seconds;
            }
            callBack?.Invoke();
        }
        private void CreateOption(IOptionResolver resolver)
        {
            foreach (var option in resolver.DialogueOptions)
            {
                VITSOptionUI optionSlot = GetOption();
                optionSlots.Add(optionSlot);
                optionSlot.UpdateOption(option, (opt) => StartCoroutine(ClickOptionCoroutine(resolver, opt)));
            }
        }
        private IEnumerator ClickOptionCoroutine(IOptionResolver resolver, Option opt)
        {
            yield return resolver.ClickOption(opt);
            CleanUp();
        }
        private void CleanUp()
        {
            mainText.text = string.Empty;
            foreach (var slot in optionSlots) Destroy(slot.gameObject);
            optionSlots.Clear();
        }
        private VITSOptionUI GetOption()
        {
            return Instantiate(optionPrefab, optionPanel);
        }
    }
}
