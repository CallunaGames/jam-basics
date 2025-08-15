using System;
using UnityEngine;
using UnityEngine.UI;

namespace Calluna.JamBasics.TimerExample
{
    public class TimerStarter : MonoBehaviour
    {
        [SerializeField] private float _timerDuration = 2.0f;
        [SerializeField] private Image _timerImage;
        
        private Timer _timer;
        private int _callCounter;
        
        private void Start()
        {
            _timer = Timer.Create("MyTimer", transform).StartWith(_timerDuration);
            _timer.OnDone += OnDone;
        }

        private void Update()
        {
            _timerImage.fillAmount = _timer.Percentage;
        }

        private void OnDestroy()
        {
            _timer.OnDone -= OnDone;
        }

        private void OnDone()
        {
            _callCounter++;
            Debug.Log($"Timer done for the {_callCounter} time");
            _timer.StartWith(_timerDuration);
        }
    }
}
