
// Configurable Motion2D & TeaTime behaviours.

// @matnesis
// 2015/12/13 06:11 PM


using UnityEngine;
using matnesis.TeaTime;
using matnesis.Reactive;

[ReactiveInEditMode]
[RequireComponent(typeof(Motion2D))]
public class Motion2DActions : MonoBehaviour
{
    [Header("Config")]
    public Transform target;
    public ReactiveBool doFollow = new ReactiveBool(false);
    public ReactiveBool doRunAway = new ReactiveBool(false);

    // TeaTime
    private TeaTime followTarget;
    private TeaTime runAwayFromTarget;

    private Motion2D motion;


    void Start()
    {
        motion = GetComponent<Motion2D>();


        // ^
        // Follow

        followTarget = this.tt().Pause().Add(0.10f, (ttHandler t) =>
        {
            Vector3 dirToTarget = target.position - transform.position;
            dirToTarget.z = 0;

            motion.direction = dirToTarget.normalized;
        })
        .Repeat();

        doFollow.Subscribe(x =>
        {
            if (x) followTarget.Play();
            else followTarget.Stop();
        });



        // ^
        // Run away

        runAwayFromTarget = this.tt().Pause().Add(0.10f, (ttHandler t) =>
        {
            Vector3 dirToTarget = transform.position - target.position;
            dirToTarget.z = 0;

            motion.direction = dirToTarget.normalized;
        })
        .Repeat();

        doRunAway.Subscribe(x =>
        {
            if (x) runAwayFromTarget.Play();
            else runAwayFromTarget.Stop();
        });
    }
}
