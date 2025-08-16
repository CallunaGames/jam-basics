using System;
using UnityEngine;

namespace Calluna.JamBasics
{
    public class PerformCancelOnKey : MonoBehaviour
    {
        [SerializeField] private KeyCode _cancelKey = KeyCode.Escape;

        private void Update()
        {
            if (Input.GetKeyDown(_cancelKey))
            {
                CancelStack.Instance.PopAndExecute();
            }
        }
    }
}
