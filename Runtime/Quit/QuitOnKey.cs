using System;
using UnityEngine;

namespace Calluna.JamBasics
{
    public class QuitOnKey : MonoBehaviour
    {
        [SerializeField] private KeyCode _quitKey = KeyCode.Escape;

        private void Update()
        {
            if (Input.GetKeyDown(_quitKey))
            {
                QuitGame.Quit();
            }
        }
    }
}
