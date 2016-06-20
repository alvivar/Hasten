
// Lambda Condition/Reaction Queue, powered by TeaTime.

// @matnesis
// 2016/06/17 11:27 PM


using UnityEngine;
using System;
using System.Collections.Generic;

namespace matnesis.TeaTime.Reaction
{
    /// <summary>
    /// Used to create a singleton Monobehaviour to handle the internal TeaTime
    /// algorithm.
    /// </summary>
    public class ReactionCore : MonoBehaviour { }


    /// <summary>
    /// Reaction Queue Data.
    /// </summary>
    internal class ReactionData
    {
        internal Func<bool> condition;
        internal Action reaction;
        internal TeaTime tt;


        public ReactionData(Func<bool> condition, Action reaction, TeaTime tt)
        {
            this.condition = condition;
            this.reaction = reaction;
            this.tt = tt;
        }
    }


    /// <summary>
    /// Lambda Condition/Reaction Queue, powered by TeaTime.
    /// </summary>
    public class Reaction
    {
        private List<ReactionData> queue = new List<ReactionData>();
        private float tick = 0.1f; // Time between every check

        private TeaTime ttReaction;

        private static MonoBehaviour mono;


        public Reaction()
        {
            // ^
            // Global manager

            if (mono == null)
            {
                string coreName = "[@Reaction]";
                GameObject core = GameObject.Find(coreName);
                if (core == null)
                    core = new GameObject(coreName);

                mono = core.AddComponent<ReactionCore>();
            }


            // @
            // CORE algorithm

            // Checks in order every queue element until a condition is true,
            // then executes the reaction/TeaTime associated and waits until the
            // condition changes back, and restarts.
            {
                int index = 0;

                ttReaction = mono.tt().Add(() => tick).If(() => queue.Count > 0).Add((ttHandler t) =>
                {
                    // Restart the queue and check next, until a true condition
                    if (!queue[index].condition())
                    {
                        index = ++index % queue.Count;
                        t.self.Restart();
                    }
                })

                // Condition fullfilled!
                .Add((ttHandler t) =>
                {
                    // Execute!

                    // The callback
                    if (queue[index].reaction != null) queue[index].reaction();

                    // TeaTime!
                    if (queue[index].tt != null) t.Wait(queue[index].tt.Play());
                })

                // Let's wait until the condition goes back to normal?
                // .Wait(() => !queue[index].condition(), 0)

                // Restart the queue
                .Add(() => index = 0).Repeat();
            }
        }


        /// <summary>
        /// Set the time to wait between conditions check in the queue.
        /// </summary>
        public Reaction Tick(float tick)
        {
            this.tick = tick;

            return this;
        }


        /// <summary>
        /// Appends a boolean condition, associated to an Action. To be
        /// evaluated and executed in their respective turn in the queue.
        /// </summary>
        public Reaction On(Func<bool> condition, Action reaction)
        {
            queue.Add(new ReactionData(
                condition,
                reaction,
                null
            ));

            return this;
        }


        /// <summary>
        /// Appends a boolean condition, associated to a TeaTime. To be
        /// evaluated and executed in their respective turn in the queue.
        /// </summary>
        public Reaction On(Func<bool> condition, TeaTime tt)
        {
            queue.Add(new ReactionData(
                condition,
                null,
                tt.Pause().Immutable()
            ));

            return this;
        }
    }
}
