using SampleGame;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace Game.Scripts.UI
{
    public class PauseScreenController : MonoBehaviour
    {
        private MenuLoader _menuLoader;
        private PauseScreen _pauseScreen;
        private const string _pauseUI = "PauseScreen";
        private AsyncOperationHandle<GameObject> _menuHandle;

        [Inject]
        public void Construct(MenuLoader mnLoader)
        {
            _menuLoader = mnLoader;
        }

        private async void OnEnable()
        {
            _menuHandle = Addressables.LoadAssetAsync<GameObject>(_pauseUI);
            var pauseUI = await _menuHandle.Task;
            _pauseScreen = Instantiate(pauseUI, gameObject.transform).GetComponent<PauseScreen>();
            _pauseScreen.gameObject.SetActive(false);
            _pauseScreen.ResumeButton.onClick.AddListener(Hide);
            _pauseScreen.ExitButton.onClick.AddListener(_menuLoader.LoadMenu);
        }

        private void OnDisable()
        {
            _pauseScreen.ResumeButton.onClick.RemoveListener(Hide);
            _pauseScreen.ExitButton.onClick.RemoveListener(_menuLoader.LoadMenu);
            
            if (_menuHandle.IsValid())
            {
                Addressables.Release(_menuHandle);
            }
        }
        
        public void Show()
        {
            Time.timeScale = 0; //KISS
            _pauseScreen.gameObject.SetActive(true);
        }

        private void Hide()
        {
            Time.timeScale = 1; //KISS
            _pauseScreen.gameObject.SetActive(false);
        }
    }
}
