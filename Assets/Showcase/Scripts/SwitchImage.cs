using Ceres.Graph.Flow.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class SwitchImage : MonoBehaviour
{
    public RawImage[] images;

    /// <summary>
    /// Switch displayed image by index
    /// </summary>
    /// <param name="index"></param>
    [ExecutableFunction]
    public void SwitchByIndex(int index)
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].enabled = i == index;
        }
    }
}
