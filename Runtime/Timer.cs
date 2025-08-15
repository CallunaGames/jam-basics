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
        public bool Running => _coroutine != null;
        
        private Coroutine _coroutine;
        private float _duration;
        
        public static Timer Create(string name, Transform parent = null)
        {
            GameObject timerObject = new GameObject(name);
            timerObject.transform.SetParent(parent, false);
            Timer result = timerObject.AddComponent<Timer>();
            return result;
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
            Time = 0;
            _duration = seconds;
            _coroutine = StartCoroutine(StartTimer());
            return this;
        }

        public void StopTimer()
        {
            if (_coroutine == null)
            {
                return;
            }
            
            StopCoroutine(_coroutine);
            _coroutine = null;
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
              
            _coroutine = null;  
            OnDone?.Invoke();
        }
    }
}
