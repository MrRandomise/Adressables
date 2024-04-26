using SampleGame;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace Game.Scripts.UI
{
    public class MenuScreenController : MonoBehaviour
    {
        private ApplicationExiter _applicationExiter;
        private GameLoader _gameLoader;
        private MenuScreen _menuScreen;
        private const string _menuUI = "MenuScreen";
        private AsyncOperationHandle<GameObject> _menuHandle;
        
        [Inject]
        public void Construct(ApplicationExiter applicationFinisher, GameLoader gmLoader)
        {
            _gameLoader = gmLoader;
            _applicationExiter = applicationFinisher;
        }

        private async void OnEnable()
        {
            _menuHandle = Addressables.LoadAssetAsync<GameObject>(_menuUI);
            var menuUI =  await _menuHandle.Task;
            _menuScreen = Instantiate(menuUI, gameObject.transform).GetComponent<MenuScreen>();
            _menuScreen.StartButton.onClick.AddListener(_gameLoader.LoadGame);
            _menuScreen.ExitButton.onClick.AddListener(_applicationExiter.ExitApp);
        }

        private void OnDisable()
        {
            _menuScreen.StartButton.onClick.RemoveListener(_gameLoader.LoadGame);
            _menuScreen.ExitButton.onClick.RemoveListener(_applicationExiter.ExitApp);
            
            if (_menuHandle.IsValid())
            {
                Addressables.Release(_menuHandle);
            }
        }
    }
}
