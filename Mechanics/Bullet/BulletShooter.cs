
// @matnesis
// 2017/03/27 12:11 pm


using UnityEngine;
using matnesis.TeaTime;
using matnesis.Liteprint;

public class BulletShooter : MonoBehaviour
{
    [Header("Required")]
    public Transform bulletPrefab;

    [Header("Config")]
    public LayerMask collisionLayer;

    [Header("Particles")]
    public ParticleSystem ignitionParticles;
    public ParticleSystem collisionParticles;


    Transform GetBullet(Vector3 originPos)
    {
        return bulletPrefab.liteInstantiate(originPos, Quaternion.identity);
    }


    public void DirectShoot(Vector3 originPos, Vector3 direction, float speed)
    {
        var bullet = GetBullet(originPos).GetComponent<Bullet>();
        bullet.direction = direction;
        bullet.speed = speed;


        // Collision handler
        bullet.OnCollision = x =>
        {
            // Get out of here
            bullet.transform.position = new Vector3(-999, -999, -999);
            bullet.direction = Vector2.zero;
            bullet.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            bullet.transform.liteRecycle();
        };
    }


    public void FollowerShoot(Vector3 originPos, Transform target, float speed, float refreshRate)
    {
        var bullet = GetBullet(originPos).GetComponent<Bullet>();
        bullet.speed = speed;


        // Sequence that follows
        Vector3 targetDir = Vector3.zero;
        var follower = this.tt(bullet.GetInstanceID() + "").Loop(refreshRate, t =>
        {
            bullet.direction = (target.position - transform.position).normalized;
        });


        // Collision handler
        bullet.OnCollision = x =>
        {
            follower.Reset();
        };
    }
}
