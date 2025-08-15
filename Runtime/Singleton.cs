using UnityEngine;

namespace Calluna.JamBasics
{
    public class Singleton<TInstance> : MonoBehaviour where TInstance : MonoBehaviour
    {
        [SerializeField, Header("Singleton")] private bool _dontDestroyOnLoad = false;
        
        public static TInstance Instance
        {
            get
            {
                if (_instance)
                {
                    return _instance;
                }

                TInstance[] instances =
                    GameObject.FindObjectsByType<TInstance>(FindObjectsInactive.Include, FindObjectsSortMode.None);

                switch (instances.Length)
                {
                    case > 1:
                        throw SingletonException.CreateMultipleInstancesException(typeof(TInstance));
                    case 0:
                        throw SingletonException.CreateNoInstanceException(typeof(TInstance));
                    default:
                        _instance = instances[0];
                        return _instance;
                }
            }
        }

        public static bool HasInstance => _instance != null;

        private static TInstance _instance;

        protected virtual void Awake()
        {
            if (_dontDestroyOnLoad)
            {
                DontDestroyOnLoad(this);
            }
            SetInstance();
        }

        protected virtual void OnDestroy()
        {
            if (_instance == this)
            {
                _instance = null;
            }
        }

        private void SetInstance()
        {
            if (this is not TInstance instance)
            {
                return;
            }
            
            if (_instance != null && _instance != this)
            {
                Destroy(this);
                return;
            }
            
            _instance = instance;
        }
    }
}
