using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Game.Scripts.Locations
{
    public class TriggerController : MonoBehaviour
    {
        [SerializeField] private string _path;
        [SerializeField] private Transform _worldTranform;
        private bool _isLoaded;
        private AsyncOperationHandle<GameObject> _locationHandle;

        private async void OnTriggerEnter(Collider other)
        {
            if (!_isLoaded)
            {
                _isLoaded = true;
                _locationHandle =  Addressables.LoadAssetAsync<GameObject>(_path);
                await _locationHandle.Task;
                Instantiate(_locationHandle.Result, _worldTranform);
            }
        }

        private void OnDisable()
        {
            if (_locationHandle.IsValid())
            {
                Addressables.Release(_locationHandle);
            }
        }
    }
}
