using System;

public static class Dataset
{
    public static Arrayx<int> eyeTagId = new Arrayx<int>();
    public static Arrayx<EyeTag> eyeTag = new Arrayx<EyeTag>();
    public static Arrayx<int> closestColliderId = new Arrayx<int>();
    public static Arrayx<ClosestCollider> closestCollider = new Arrayx<ClosestCollider>();
    public static Arrayx<int> randomInitialPositionId = new Arrayx<int>();
    public static Arrayx<RandomInitialPosition> randomInitialPosition = new Arrayx<RandomInitialPosition>();
    public static Arrayx<int> gunId = new Arrayx<int>();
    public static Arrayx<Gun> gun = new Arrayx<Gun>();

    public static void AddEyeTag(int id, EyeTag obj)
    {
        // Setup

        if (eyeTagId.Elements == null)
        {
            eyeTagId.Size = 1000;
            eyeTagId.Elements = new int[eyeTagId.Size];
        }

        if (eyeTag.Elements == null)
        {
            eyeTag.Size = 1000;
            eyeTag.Elements = new EyeTag[eyeTag.Size];
        }

        // Add

        eyeTagId.Elements[eyeTagId.Length++] = id;
        eyeTag.Elements[eyeTag.Length++] = obj;

        // Resize check

        if (eyeTagId.Length >= eyeTagId.Size)
        {
            eyeTagId.Size *= 2;
            Array.Resize(ref eyeTagId.Elements, eyeTagId.Size);

            eyeTag.Size *= 2;
            Array.Resize(ref eyeTag.Elements, eyeTag.Size);
        }
    }

    public static void AddGun(int id, Gun obj)
    {
        // Setup

        if (gunId.Elements == null)
        {
            gunId.Size = 1000;
            gunId.Elements = new int[gunId.Size];
        }

        if (gun.Elements == null)
        {
            gun.Size = 1000;
            gun.Elements = new Gun[gun.Size];
        }

        // Add

        gunId.Elements[gunId.Length++] = id;
        gun.Elements[gun.Length++] = obj;

        // Resize check

        if (gunId.Length >= gunId.Size)
        {
            gunId.Size *= 2;
            Array.Resize(ref gunId.Elements, gunId.Size);

            gun.Size *= 2;
            Array.Resize(ref gun.Elements, gun.Size);
        }
    }

    public static void AddClosestCollider(int id, ClosestCollider obj)
    {
        // Setup

        if (closestColliderId.Elements == null)
        {
            closestColliderId.Size = 1000;
            closestColliderId.Elements = new int[closestColliderId.Size];
        }

        if (closestCollider.Elements == null)
        {
            closestCollider.Size = 1000;
            closestCollider.Elements = new ClosestCollider[closestCollider.Size];
        }

        // Add

        closestColliderId.Elements[closestColliderId.Length++] = id;
        closestCollider.Elements[closestCollider.Length++] = obj;

        // Resize check

        if (closestColliderId.Length >= closestColliderId.Size)
        {
            closestColliderId.Size *= 2;
            Array.Resize(ref closestColliderId.Elements, closestColliderId.Size);

            closestCollider.Size *= 2;
            Array.Resize(ref closestCollider.Elements, closestCollider.Size);
        }
    }

    public static void AddRandomInitialPosition(int id, RandomInitialPosition obj)
    {
        // Setup

        if (randomInitialPositionId.Elements == null)
        {
            randomInitialPositionId.Size = 1000;
            randomInitialPositionId.Elements = new int[randomInitialPositionId.Size];
        }

        if (randomInitialPosition.Elements == null)
        {
            randomInitialPosition.Size = 1000;
            randomInitialPosition.Elements = new RandomInitialPosition[randomInitialPosition.Size];
        }

        // Add

        randomInitialPositionId.Elements[randomInitialPositionId.Length++] = id;
        randomInitialPosition.Elements[randomInitialPosition.Length++] = obj;

        // Resize check

        if (randomInitialPositionId.Length >= randomInitialPositionId.Size)
        {
            randomInitialPositionId.Size *= 2;
            Array.Resize(ref randomInitialPositionId.Elements, randomInitialPositionId.Size);

            randomInitialPosition.Size *= 2;
            Array.Resize(ref randomInitialPosition.Elements, randomInitialPosition.Size);
        }
    }

    public static void RemoveRandomInitialPosition<T>(int id, UnityEngine.GameObject obj)
    {
        var indexToRemove = -1;
        for (int i = 0; i < randomInitialPositionId.Length; i++)
        {
            if (randomInitialPositionId.Elements[i] == id)
            {
                indexToRemove = i;
                break;
            }
        }

        Array.Copy(
            randomInitialPositionId.Elements, indexToRemove + 1,
            randomInitialPositionId.Elements, indexToRemove,
            randomInitialPositionId.Length - indexToRemove - 1);
        randomInitialPositionId.Length--;

        Array.Copy(
            randomInitialPosition.Elements, indexToRemove + 1,
            randomInitialPosition.Elements, indexToRemove,
            randomInitialPosition.Length - indexToRemove - 1);
        randomInitialPosition.Length--;

        if (obj != null)
        {
            var objComp = obj.GetComponent(typeof(T));
            UnityEngine.Object.Destroy(objComp);
        }
    }
}