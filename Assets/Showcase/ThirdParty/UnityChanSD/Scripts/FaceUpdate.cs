using UnityEngine;
namespace UnityChan
{
	public class FaceUpdate : MonoBehaviour
	{
		public AnimationClip[] animations;
		private Animator anim;
		public bool isGUI = true;
		private void Start()
		{
			anim = GetComponent<Animator>();
		}

		private void OnGUI()
		{
			if (isGUI)
			{
				GUILayout.Box("Face Update", GUILayout.Width(170), GUILayout.Height(25 * (animations.Length + 2)));
				Rect screenRect = new(10, 25, 150, 25 * (animations.Length + 1));
				GUILayout.BeginArea(screenRect);
				foreach (var animation in animations)
				{
					if (GUILayout.RepeatButton(animation.name))
					{
						anim.CrossFade(animation.name, 0);
					}
				}
				GUILayout.EndArea();
			}
		}

		//アニメーションEvents側につける表情切り替え用イベントコール
		public void OnCallChangeFace(string str)
		{
			int ichecked = 0;
			foreach (var animation in animations)
			{
				if (str == animation.name)
				{
					ChangeFace(str);
					break;
				}
				else if (ichecked <= animations.Length)
				{
					ichecked++;
				}
				else
				{
					//str指定が間違っている時にはデフォルトで
					str = "default@unitychan";
					ChangeFace(str);
				}
			}
		}

		private void ChangeFace(string str)
		{
			anim.CrossFade(str, 0);
		}
	}
}
