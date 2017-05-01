
// Reactive Properties!

// There is a ReactiveBool, Float, Int, String, Vector2, and Vector3. You can
// .Subscribe Actions to the Property and they will be called when his .Value
// changes.


// @matnesis
// 2015/12/12 02:40 PM


namespace matnesis.Reactive
{
    using System;
    using UnityEngine;


    [Serializable]
    public class ReactiveProp<T>
    {
        Action<T> subscribers;
        T callValue = default(T);

        [SerializeField]
        T value = default(T);
        public T Value
        {
            get { return value; }

            set
            {
                // Avoid if it's the same value
                if (this.value != null && this.value.Equals(value)) return;

                this.value = value;

                CallSubscribers();
            }
        }


        public ReactiveProp(T initialValue)
        {
            Value = initialValue;
        }


        /// <summary>
        /// Subscribes the callback to Value changes, returns an Action that
        /// unsubscribes it.
        /// </summary>
        public Action Subscribe(Action<T> callback, bool callOnSubscribe = true)
        {
            subscribers += callback;

            // What does is this callValue validation?
            if (callOnSubscribe && callValue != null) callback(value);

            return new Action(() => subscribers -= callback);
        }


        public void Unsubscribe(Action<T> callback)
        {
            subscribers -= callback;
        }


        public T CallSubscribers()
        {
            // Avoid if it's the same value
            if (callValue != null && callValue.Equals(value)) return default(T);

            // Send
            callValue = value;
            if (subscribers != null) subscribers(callValue);

            return callValue;
        }
    }


    // Specialized properties that can be seeing on the Unity inspector.

    [Serializable]
    public class ReactiveBool : ReactiveProp<bool>
    {
        public ReactiveBool(bool value) : base(value) { }
    }


    [Serializable]
    public class ReactiveString : ReactiveProp<string>
    {
        public ReactiveString(string value) : base(value) { }
    }


    [Serializable]
    public class ReactiveInt : ReactiveProp<int>
    {
        public ReactiveInt(int value) : base(value) { }
    }


    [Serializable]
    public class ReactiveFloat : ReactiveProp<float>
    {
        public ReactiveFloat(float value) : base(value) { }
    }


    [Serializable]
    public class ReactiveVector3 : ReactiveProp<Vector3>
    {
        public ReactiveVector3(Vector3 value) : base(value) { }
    }


    [Serializable]
    public class ReactiveVector2 : ReactiveProp<Vector2>
    {
        public ReactiveVector2(Vector2 value) : base(value) { }
    }
}
