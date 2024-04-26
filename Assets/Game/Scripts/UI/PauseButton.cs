using Game.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace SampleGame
{
    public sealed class PauseButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        
        [SerializeField] private PauseScreenController _pauseScreenController;

        private void OnEnable()
        {
            _button.onClick.AddListener(_pauseScreenController.Show);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(_pauseScreenController.Show);
        }
    }
}