using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Calluna.JamBasics.CoroutineHelperExample
{
    public class CoroutineHelperTester : MonoBehaviour
    {
        [SerializeField] private Button _replaceButton;
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _stopButton;
        [SerializeField] private float _delay = 3f;
        [SerializeField] private string _id = "Id";

        private void Start()
        {
            _startButton.onClick.AddListener(OnStartButtonClicked);
            _replaceButton.onClick.AddListener(OnReplaceButtonClicked);
            _stopButton.onClick.AddListener(OnStopButtonClicked);
        }

        private void OnDestroy()
        {
            _startButton.onClick.RemoveListener(OnStartButtonClicked);
            _replaceButton.onClick.RemoveListener(OnReplaceButtonClicked);
            _stopButton.onClick.RemoveListener(OnStopButtonClicked);
        }

        private void OnStartButtonClicked()
        {
            CoroutineHelper.Instance.StartWithID(Routine(), _id);
        }

        private void OnReplaceButtonClicked()
        {
            CoroutineHelper.Instance.ReplaceWithID(Routine(), _id);
        }

        private void OnStopButtonClicked()
        {
            string success = CoroutineHelper.Instance.StopWithID(_id) ? "Success" : "Failed";
            Debug.Log($"Tried to stop routine: {success}");
        }

        private IEnumerator Routine()
        {
            Debug.Log("Start Routine");
            yield return new WaitForSeconds(_delay);
            Debug.Log("End Routine");
        }
    }
}
