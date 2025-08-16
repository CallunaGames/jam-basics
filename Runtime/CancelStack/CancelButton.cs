using System;
using UnityEngine;
using UnityEngine.UI;

namespace Calluna.JamBasics
{
    public class CancelButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private void Start()
        {
            _button.onClick.AddListener(CancelStack.Instance.PopAndExecute);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(CancelStack.Instance.PopAndExecute);
        }
    }
}
