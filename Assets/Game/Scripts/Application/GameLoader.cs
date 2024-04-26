using UnityEngine.AddressableAssets;

namespace SampleGame
{
    public sealed class GameLoader
    {
        private const string _gameScene = "Game";

        public async void LoadGame()
        {
           var _ = await Addressables.LoadSceneAsync(_gameScene).Task;
        }
    }
}