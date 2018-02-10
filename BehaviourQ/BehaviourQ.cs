
// Simplest behaviour queue ever!

// For any state in the queue, If Condition() then Action() while calling Stop()
// on the rest of the queue!


// @matnesis
// 2017/03/21 09:38 PM


namespace matnesis.BehaviourQ
{
    using System;
    using System.Collections.Generic;

    public class BehaviourQ
    {
        public class BehaviourState
        {
            public Func<bool> Condition { get; set; }
            public Action Reaction { get; set; }
            public Action Stop { get; set; }
        }


        List<BehaviourState> queue = new List<BehaviourState>();
        int index = 0;
        bool active = true;


        BehaviourQ Add(BehaviourState state)
        {
            queue.Add(state);

            return this;
        }

        public BehaviourQ Add(Func<bool> condition, Action reaction, Action stop)
        {
            var state = new BehaviourState();
            state.Condition = condition;
            state.Reaction = reaction;
            state.Stop = stop;

            return Add(state);
        }

        public BehaviourQ Add(Func<bool> condition, Action reaction)
        {
            var state = new BehaviourState();
            state.Condition = condition;
            state.Reaction = reaction;
            state.Stop = null;

            return Add(state);
        }

        public BehaviourQ Add(Func<bool> condition)
        {
            var state = new BehaviourState();
            state.Condition = condition;
            state.Reaction = null;
            state.Stop = null;

            return Add(state);
        }


        public void Update()
        {
            if (!active) return;


            var chosen = queue[index];

            if (chosen.Condition())
            {
                // Stop the rest
                for (int i = index + 1, len = queue.Count; i < len; i++)
                    if (queue[i].Stop != null) queue[i].Stop();

                // React and start over
                if (chosen.Reaction != null) chosen.Reaction();
                index = 0;
            }
            else
            {
                // Next
                index = ++index % queue.Count;

                // Maybe the current chosen was previouly active
                if (chosen.Stop != null) chosen.Stop();
            }
        }


        public void Pause()
        {
            active = false;
        }


        public void Play()
        {
            active = true;
        }
    }
}
