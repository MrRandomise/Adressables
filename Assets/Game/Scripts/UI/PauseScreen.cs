using UnityEngine;
using UnityEngine.UI;

namespace SampleGame
{
    public sealed class PauseScreen : MonoBehaviour
    {
        [SerializeField] private Button _resume;
        
        [SerializeField] private Button _exit;

        public Button ResumeButton => _resume;

        public Button ExitButton => _exit;
    }
}