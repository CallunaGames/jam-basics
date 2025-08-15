using UnityEngine;

namespace Calluna.JamBasics.SingletonExample
{
    public class Foo : Singleton<Foo>
    {
        [field: SerializeField] public string Name { get; private set; }
    }
}
