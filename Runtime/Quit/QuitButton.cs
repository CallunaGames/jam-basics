using UnityEngine;
using UnityEngine.UI;

namespace Calluna.JamBasics
{
    public class QuitButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        public void Start()
        {
            _button.onClick.AddListener(QuitGame.Quit);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(QuitGame.Quit);
        }
    }
}
