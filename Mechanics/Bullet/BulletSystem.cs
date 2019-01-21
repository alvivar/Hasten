// Andrés Villalobos * twitter.com/matnesis * andresalvivar@gmail.com
// 2018/06/02 04:03 pm

using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class BulletSystem : ComponentSystem
{
    struct Data
    {
        public ComponentArray<Bullet> bullet;
        public ComponentArray<Rigidbody2D> rigidbody;
        public ComponentArray<BulletCollision> collisions;
        public readonly int Length;
    }

    [Inject] readonly Data data;
    static List<Bullet> unused = new List<Bullet>();

    override protected void OnUpdate()
    {
        for (int i = 0; i < data.Length; i++)
        {
            var bullet = data.bullet[i];
            var rigidbody = data.rigidbody[i];
            var collisions = data.collisions[i];

            // Unused

            if (bullet.direction.magnitude == 0 && bullet.target == null)
            {
                if (!unused.Contains(bullet))
                    unused.Add(bullet);
            }

            // Motion

            var dir = bullet.direction.normalized;
            if (bullet.target) dir = (bullet.target.position - bullet.transform.position).normalized;
            rigidbody.velocity = dir * bullet.speed * Time.deltaTime;

            if (dir.magnitude != 0)
                bullet.timer += Time.deltaTime;

            // Clean up old bullets data

            if (bullet.timer > 20)
                bullet.Clean();

            // Collision

            for (int j = 0; j < collisions.detected.Count; j++)
            {
                var collision = collisions.detected[j];
                if (bullet.onCollision != null)
                    bullet.onCollision(collision, bullet);
            }
            collisions.detected.Clear();
        }
    }

    public static Bullet FireBullet(Vector3 position, Transform target, Vector3 direction, float speed, System.Action<Collision2D, Bullet> onCollision)
    {
        if (BulletSystem.unused.Count < 1) return null;

        // #hack Clean up static leftovers
        while (BulletSystem.unused.Count > 0 && BulletSystem.unused[0] == null)
            BulletSystem.unused.RemoveAt(0);

        var bullet = BulletSystem.unused[0];
        BulletSystem.unused.RemoveAt(0);

        bullet.Clean();
        bullet.transform.position = position;
        bullet.target = target;
        bullet.direction = direction;
        bullet.speed = speed;
        bullet.onCollision = onCollision;

        return bullet;
    }
}