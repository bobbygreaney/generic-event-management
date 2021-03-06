// --------------------------------------------------------------------------------------------------------------------
// Creation Date:	02/10/20
// Author:				Bobby Greaney
// Description:		Managed Events for better inspectors and debugging
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine.Events;

namespace LughNut.GEM
{
    /// <summary>
    /// Managed Events for better inspectors and debugging. No Parameters
    /// </summary>
    public class ManagedEvent : UnityEvent
    {
        private int _listenerCount;
        private List<object> objects = new List<object>();
        private List<string> methodNames = new List<string>();

        public int ListenerCount { get { return _listenerCount; } }
        public object[] TargetObjects { get { return objects.ToArray(); } }
        public string[] TargetMethods { get { return methodNames.ToArray(); } }


        new public void AddListener(UnityAction call)
        {
            base.AddListener(call);
            objects.Add(call.Target);
            methodNames.Add(call.Method.Name);
            _listenerCount++;
        }

        new public void RemoveListener(UnityAction call)
        {
            base.RemoveListener(call);
            objects.Remove(call.Target);
            methodNames.Remove(call.Method.Name);
            _listenerCount--;
        }
    }

    /// <summary>
    /// Managed Events for better inspectors and debugging. Single Parameter
    /// </summary>
    public class ManagedEvent_A<T> : UnityEvent<T>
    {
        private int _listenerCount;
        private List<object> objects = new List<object>();
        private List<string> methodNames = new List<string>();

        public int ListenerCount { get { return _listenerCount; } }
        public object[] TargetObjects { get { return objects.ToArray(); } }
        public string[] TargetMethods { get { return methodNames.ToArray(); } }
        public T lastValue;

        new public void Invoke(T arg0)
        {
            lastValue = arg0;
            base.Invoke(arg0);
        }

        new public void AddListener(UnityAction<T> call)
        {
            base.AddListener(call);
            objects.Add(call.Target);
            methodNames.Add(call.Method.Name);
            _listenerCount++;
        }

        new public void RemoveListener(UnityAction<T> call)
        {
            base.RemoveListener(call);
            objects.Remove(call.Target);
            methodNames.Remove(call.Method.Name);
            _listenerCount--;
        }
    }
}
