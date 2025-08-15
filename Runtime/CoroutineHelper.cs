using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Calluna.JamBasics
{
    public class CoroutineHelper : Singleton<CoroutineHelper>
    {
        private Dictionary<string, Coroutine> _coroutines = new Dictionary<string, Coroutine>();
        private Dictionary<string, Coroutine> _stopCoroutines = new Dictionary<string, Coroutine>();
        
        protected override void OnDestroy()
        {
            base.OnDestroy();
            StopAllCoroutines();
        }

        public void StartWithID(IEnumerator enumerator, string id)
        {
            if (_coroutines.ContainsKey(id) && _coroutines[id] != null)
            {
                throw new ArgumentException($"A routine with id {id} has already been started.");
            }

            _coroutines[id] = null;
            Coroutine coroutine = StartCoroutine(StartWithRemove(enumerator, id));
            if (_coroutines.ContainsKey(id))
            {
                _stopCoroutines[id] = coroutine;
            }
        }

        public bool StopWithID(string id)
        {
            if (!_coroutines.TryGetValue(id, out Coroutine coroutine))
            {
                return false;
            }

            if (coroutine != null)
            {
                StopCoroutine(_coroutines[id]);
                StopCoroutine(_stopCoroutines[id]);
                _coroutines.Remove(id);
                _stopCoroutines.Remove(id);
                return true;
            }
            
            _coroutines.Remove(id);
            _stopCoroutines.Remove(id);
            return false;
        }

        public void ReplaceWithID(IEnumerator enumerator, string id)
        {
            StopWithID(id);
            StartWithID(enumerator, id);
        }

        private IEnumerator StartWithRemove(IEnumerator enumerator, string id)
        {
            Coroutine coroutine = StartCoroutine(enumerator);
            _coroutines[id] = coroutine;
            yield return coroutine;
            StopWithID(id);
        }
    }
}
