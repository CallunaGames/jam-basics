using UnityEngine;

namespace Calluna.JamBasics
{
    public class QuitGame : MonoBehaviour
    {
        public static void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}