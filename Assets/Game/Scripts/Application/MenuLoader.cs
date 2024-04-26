using UnityEngine.SceneManagement;

namespace SampleGame
{
    public sealed class MenuLoader
    {
        private const string _menuScene = "Menu";

        public void LoadMenu()
        {
            SceneManager.LoadScene(_menuScene);
        }
    }
}