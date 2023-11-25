using UnityEngine;
using UnityEngine.AddressableAssets;
namespace Kurisu.NGDS.Example
{
    public class Launcher : MonoBehaviour
    {
        [SerializeField]
        private AssetReference mainSceneReference;
        private void Awake()
        {
            Addressables.LoadSceneAsync(mainSceneReference, UnityEngine.SceneManagement.LoadSceneMode.Single);
        }
    }
}
