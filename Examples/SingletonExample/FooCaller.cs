using System;
using UnityEngine;

namespace Calluna.JamBasics.SingletonExample
{
    public class FooCaller : MonoBehaviour
    {
        private void Start()
        {
            Debug.Log($"Foos Name: {Foo.Instance.Name}");
        }
    }
}
