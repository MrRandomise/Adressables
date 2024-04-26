using UnityEngine;
using UnityEngine.UI;

namespace SampleGame
{
    public sealed class MenuScreen : MonoBehaviour
    {
        [SerializeField] private Button _start;
        [SerializeField] private Button _exit;

        public Button StartButton => _start;
        public Button ExitButton => _exit;

    }
}