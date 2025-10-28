using System;
using System.Collections;
using UnityEngine;

namespace Calluna.JamBasics
{
    public class Timer : MonoBehaviour
    {
        public event Action OnDone;
        public float Percentage => Running ? Mathf.Clamp01(Time / _duration) : 1f;
        public float Time { get; private set; }
        public bool Running => CoroutineHelper.Instance.HasRoutineWith(_instanceId);
        
        private float _duration;
        private string _instanceId;
        
        public static Timer Create(string name, Transform parent = null)
        {
            GameObject timerObject = new GameObject(name);
            timerObject.transform.SetParent(parent, false);
            Timer result = timerObject.AddComponent<Timer>();
            return result;
        }

        private void Awake()
        {
            _instanceId = GetInstanceID().ToString();
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }

        public Timer StartWith(float seconds)
        {
            if (seconds <= 0)
            {
                throw new ArgumentException("Seconds must be greater than 0.");
            }
            
            StopTimer();
            _duration = seconds;
            CoroutineHelper.Instance.StartWithID(StartTimer(), _instanceId);
            return this;
        }

        public void StopTimer()
        {
            CoroutineHelper.Instance.StopWithID(_instanceId);
            _duration = 0;
            Time = 0;
        }

        private IEnumerator StartTimer()
        {
            while (Time < _duration)
            {
                Time += UnityEngine.Time.deltaTime;
                yield return null;
            }
            
            OnDone?.Invoke();
        }
    }
}
