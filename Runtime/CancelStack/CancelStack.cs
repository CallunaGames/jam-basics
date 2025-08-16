using System;
using System.Collections.Generic;

namespace Calluna.JamBasics
{
    public class CancelStack : Singleton<CancelStack>
    {
        private Action _defaultAction;
        private List<Action> _actions = new List<Action>();
        
        public void PopAndExecute()
        {
            if (_actions.Count > 0)
            {
                Action action = _actions[^1];
                _actions.RemoveAt(_actions.Count - 1);
                action?.Invoke();
            }
            else
            {
                _defaultAction?.Invoke();
            }
        }

        public void SetDefaultAction(Action defaultAction)
        {
            _defaultAction = defaultAction;
        }

        public void Push(Action action)
        {
            _actions.Add(action);
        }

        public void TryRemove(Action action)
        {
            if (_actions.Contains(action))
            {
                _actions.Remove(action);
            }
        }
    }
}
