// Timeline animation flow using TeaTime.

// 2016/08/29 03:17 PM

using UnityEngine;

[RequireComponent(typeof(Timeline))]
public class TimelineLinear : MonoBehaviour
{
    public int index = 0;
    public float speed = 5;
    public float proximityValidation = 1; // How close we need to be to change to the next position?

    Timeline timeline;
    TeaTime linearMove;

    void Start()
    {
        timeline = GetComponent<Timeline>();

        // Sequence that moves continuous from a position to another.
        {
            Vector3 dir = Vector3.zero;

            linearMove = this.tt().Pause().Loop((ttHandler t) =>
                {
                    // Go slow
                    dir = (timeline.positions[index] - transform.position).normalized;
                    transform.Translate(dir * Time.deltaTime * speed);

                    // Next
                    if (Vector3.Distance(transform.position, timeline.positions[index]) < proximityValidation)
                        index = ++index % timeline.positions.Count;
                })
                .Repeat();
        }
    }

    public void Stop()
    {
        linearMove.Stop();
    }

    public void Play()
    {
        linearMove.Play();
    }
}