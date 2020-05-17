// This file is auto-generated. Modifications won't be saved, be cool.

// EntitySet is a static database of MonoBehaviour classes that are considered a
// Entity, classes with '// !Gigas' somewhere in their file.

// Refresh with the menu item 'Tools/Gigas/Generate EntitySet.cs'

using System;
using UnityEngine;
using System.Collections.Generic;

// namespace Gigas
// {
    public static class EntitySet
    {
        public static Arrayx<int> closestColliderId = new Arrayx<int>();
        public static Arrayx<ClosestCollider> closestCollider = new Arrayx<ClosestCollider>();
        public static Arrayx<int> eyeAwaySystemId = new Arrayx<int>();
        public static Arrayx<EyeAwaySystem> eyeAwaySystem = new Arrayx<EyeAwaySystem>();
        public static Arrayx<int> eyeTagId = new Arrayx<int>();
        public static Arrayx<EyeTag> eyeTag = new Arrayx<EyeTag>();
        public static Arrayx<int> flyingLightId = new Arrayx<int>();
        public static Arrayx<FlyingLight> flyingLight = new Arrayx<FlyingLight>();
        public static Arrayx<int> gunId = new Arrayx<int>();
        public static Arrayx<Gun> gun = new Arrayx<Gun>();
        public static Arrayx<int> lucyId = new Arrayx<int>();
        public static Arrayx<Lucy> lucy = new Arrayx<Lucy>();
        public static Arrayx<int> materialColorCycleId = new Arrayx<int>();
        public static Arrayx<MaterialColorCycle> materialColorCycle = new Arrayx<MaterialColorCycle>();
        public static Arrayx<int> onMultiVREventId = new Arrayx<int>();
        public static Arrayx<OnMultiVREvent> onMultiVREvent = new Arrayx<OnMultiVREvent>();
        public static Arrayx<int> orbBecomesAliveBehaviourId = new Arrayx<int>();
        public static Arrayx<OrbBecomesAliveBehaviour> orbBecomesAliveBehaviour = new Arrayx<OrbBecomesAliveBehaviour>();
        public static Arrayx<int> orbFlyToId = new Arrayx<int>();
        public static Arrayx<OrbFlyTo> orbFlyTo = new Arrayx<OrbFlyTo>();
        public static Arrayx<int> orbUpDownOscillationId = new Arrayx<int>();
        public static Arrayx<OrbUpDownOscillation> orbUpDownOscillation = new Arrayx<OrbUpDownOscillation>();
        public static Arrayx<int> randomInitialPositionId = new Arrayx<int>();
        public static Arrayx<RandomInitialPosition> randomInitialPosition = new Arrayx<RandomInitialPosition>();
        public static Arrayx<int> rotatorId = new Arrayx<int>();
        public static Arrayx<Rotator> rotator = new Arrayx<Rotator>();
        public static Arrayx<int> scalePunchTweenId = new Arrayx<int>();
        public static Arrayx<ScalePunchTween> scalePunchTween = new Arrayx<ScalePunchTween>();

        public static void AddClosestCollider(ClosestCollider component)
        {
            // Setup

            if (closestColliderId.Elements == null)
            {
                closestColliderId.Size = 8;
                closestColliderId.Elements = new int[closestColliderId.Size];
            }

            if (closestCollider.Elements == null)
            {
                closestCollider.Size = 8;
                closestCollider.Elements = new ClosestCollider[closestCollider.Size];
            }

            // Add

            closestColliderId.Elements[closestColliderId.Length++] = component.gameObject.GetInstanceID();
            closestCollider.Elements[closestCollider.Length++] = component;
            component.enabled = true;    

            // Resize check

            if (closestColliderId.Length >= closestColliderId.Size)
            {
                closestColliderId.Size *= 2;
                Array.Resize(ref closestColliderId.Elements, closestColliderId.Size);

                closestCollider.Size *= 2;
                Array.Resize(ref closestCollider.Elements, closestCollider.Size);
            }
        }

        public static void AddEyeAwaySystem(EyeAwaySystem component)
        {
            // Setup

            if (eyeAwaySystemId.Elements == null)
            {
                eyeAwaySystemId.Size = 8;
                eyeAwaySystemId.Elements = new int[eyeAwaySystemId.Size];
            }

            if (eyeAwaySystem.Elements == null)
            {
                eyeAwaySystem.Size = 8;
                eyeAwaySystem.Elements = new EyeAwaySystem[eyeAwaySystem.Size];
            }

            // Add

            eyeAwaySystemId.Elements[eyeAwaySystemId.Length++] = component.gameObject.GetInstanceID();
            eyeAwaySystem.Elements[eyeAwaySystem.Length++] = component;
            component.enabled = true;    

            // Resize check

            if (eyeAwaySystemId.Length >= eyeAwaySystemId.Size)
            {
                eyeAwaySystemId.Size *= 2;
                Array.Resize(ref eyeAwaySystemId.Elements, eyeAwaySystemId.Size);

                eyeAwaySystem.Size *= 2;
                Array.Resize(ref eyeAwaySystem.Elements, eyeAwaySystem.Size);
            }
        }

        public static void AddEyeTag(EyeTag component)
        {
            // Setup

            if (eyeTagId.Elements == null)
            {
                eyeTagId.Size = 8;
                eyeTagId.Elements = new int[eyeTagId.Size];
            }

            if (eyeTag.Elements == null)
            {
                eyeTag.Size = 8;
                eyeTag.Elements = new EyeTag[eyeTag.Size];
            }

            // Add

            eyeTagId.Elements[eyeTagId.Length++] = component.gameObject.GetInstanceID();
            eyeTag.Elements[eyeTag.Length++] = component;
            component.enabled = true;    

            // Resize check

            if (eyeTagId.Length >= eyeTagId.Size)
            {
                eyeTagId.Size *= 2;
                Array.Resize(ref eyeTagId.Elements, eyeTagId.Size);

                eyeTag.Size *= 2;
                Array.Resize(ref eyeTag.Elements, eyeTag.Size);
            }
        }

        public static void AddFlyingLight(FlyingLight component)
        {
            // Setup

            if (flyingLightId.Elements == null)
            {
                flyingLightId.Size = 8;
                flyingLightId.Elements = new int[flyingLightId.Size];
            }

            if (flyingLight.Elements == null)
            {
                flyingLight.Size = 8;
                flyingLight.Elements = new FlyingLight[flyingLight.Size];
            }

            // Add

            flyingLightId.Elements[flyingLightId.Length++] = component.gameObject.GetInstanceID();
            flyingLight.Elements[flyingLight.Length++] = component;
            component.enabled = true;    

            // Resize check

            if (flyingLightId.Length >= flyingLightId.Size)
            {
                flyingLightId.Size *= 2;
                Array.Resize(ref flyingLightId.Elements, flyingLightId.Size);

                flyingLight.Size *= 2;
                Array.Resize(ref flyingLight.Elements, flyingLight.Size);
            }
        }

        public static void AddGun(Gun component)
        {
            // Setup

            if (gunId.Elements == null)
            {
                gunId.Size = 8;
                gunId.Elements = new int[gunId.Size];
            }

            if (gun.Elements == null)
            {
                gun.Size = 8;
                gun.Elements = new Gun[gun.Size];
            }

            // Add

            gunId.Elements[gunId.Length++] = component.gameObject.GetInstanceID();
            gun.Elements[gun.Length++] = component;
            component.enabled = true;    

            // Resize check

            if (gunId.Length >= gunId.Size)
            {
                gunId.Size *= 2;
                Array.Resize(ref gunId.Elements, gunId.Size);

                gun.Size *= 2;
                Array.Resize(ref gun.Elements, gun.Size);
            }
        }

        public static void AddLucy(Lucy component)
        {
            // Setup

            if (lucyId.Elements == null)
            {
                lucyId.Size = 8;
                lucyId.Elements = new int[lucyId.Size];
            }

            if (lucy.Elements == null)
            {
                lucy.Size = 8;
                lucy.Elements = new Lucy[lucy.Size];
            }

            // Add

            lucyId.Elements[lucyId.Length++] = component.gameObject.GetInstanceID();
            lucy.Elements[lucy.Length++] = component;
            component.enabled = true;    

            // Resize check

            if (lucyId.Length >= lucyId.Size)
            {
                lucyId.Size *= 2;
                Array.Resize(ref lucyId.Elements, lucyId.Size);

                lucy.Size *= 2;
                Array.Resize(ref lucy.Elements, lucy.Size);
            }
        }

        public static void AddMaterialColorCycle(MaterialColorCycle component)
        {
            // Setup

            if (materialColorCycleId.Elements == null)
            {
                materialColorCycleId.Size = 8;
                materialColorCycleId.Elements = new int[materialColorCycleId.Size];
            }

            if (materialColorCycle.Elements == null)
            {
                materialColorCycle.Size = 8;
                materialColorCycle.Elements = new MaterialColorCycle[materialColorCycle.Size];
            }

            // Add

            materialColorCycleId.Elements[materialColorCycleId.Length++] = component.gameObject.GetInstanceID();
            materialColorCycle.Elements[materialColorCycle.Length++] = component;
            component.enabled = true;    

            // Resize check

            if (materialColorCycleId.Length >= materialColorCycleId.Size)
            {
                materialColorCycleId.Size *= 2;
                Array.Resize(ref materialColorCycleId.Elements, materialColorCycleId.Size);

                materialColorCycle.Size *= 2;
                Array.Resize(ref materialColorCycle.Elements, materialColorCycle.Size);
            }
        }

        public static void AddOnMultiVREvent(OnMultiVREvent component)
        {
            // Setup

            if (onMultiVREventId.Elements == null)
            {
                onMultiVREventId.Size = 8;
                onMultiVREventId.Elements = new int[onMultiVREventId.Size];
            }

            if (onMultiVREvent.Elements == null)
            {
                onMultiVREvent.Size = 8;
                onMultiVREvent.Elements = new OnMultiVREvent[onMultiVREvent.Size];
            }

            // Add

            onMultiVREventId.Elements[onMultiVREventId.Length++] = component.gameObject.GetInstanceID();
            onMultiVREvent.Elements[onMultiVREvent.Length++] = component;
            component.enabled = true;    

            // Resize check

            if (onMultiVREventId.Length >= onMultiVREventId.Size)
            {
                onMultiVREventId.Size *= 2;
                Array.Resize(ref onMultiVREventId.Elements, onMultiVREventId.Size);

                onMultiVREvent.Size *= 2;
                Array.Resize(ref onMultiVREvent.Elements, onMultiVREvent.Size);
            }
        }

        public static void AddOrbBecomesAliveBehaviour(OrbBecomesAliveBehaviour component)
        {
            // Setup

            if (orbBecomesAliveBehaviourId.Elements == null)
            {
                orbBecomesAliveBehaviourId.Size = 8;
                orbBecomesAliveBehaviourId.Elements = new int[orbBecomesAliveBehaviourId.Size];
            }

            if (orbBecomesAliveBehaviour.Elements == null)
            {
                orbBecomesAliveBehaviour.Size = 8;
                orbBecomesAliveBehaviour.Elements = new OrbBecomesAliveBehaviour[orbBecomesAliveBehaviour.Size];
            }

            // Add

            orbBecomesAliveBehaviourId.Elements[orbBecomesAliveBehaviourId.Length++] = component.gameObject.GetInstanceID();
            orbBecomesAliveBehaviour.Elements[orbBecomesAliveBehaviour.Length++] = component;
            component.enabled = true;    

            // Resize check

            if (orbBecomesAliveBehaviourId.Length >= orbBecomesAliveBehaviourId.Size)
            {
                orbBecomesAliveBehaviourId.Size *= 2;
                Array.Resize(ref orbBecomesAliveBehaviourId.Elements, orbBecomesAliveBehaviourId.Size);

                orbBecomesAliveBehaviour.Size *= 2;
                Array.Resize(ref orbBecomesAliveBehaviour.Elements, orbBecomesAliveBehaviour.Size);
            }
        }

        public static void AddOrbFlyTo(OrbFlyTo component)
        {
            // Setup

            if (orbFlyToId.Elements == null)
            {
                orbFlyToId.Size = 8;
                orbFlyToId.Elements = new int[orbFlyToId.Size];
            }

            if (orbFlyTo.Elements == null)
            {
                orbFlyTo.Size = 8;
                orbFlyTo.Elements = new OrbFlyTo[orbFlyTo.Size];
            }

            // Add

            orbFlyToId.Elements[orbFlyToId.Length++] = component.gameObject.GetInstanceID();
            orbFlyTo.Elements[orbFlyTo.Length++] = component;
            component.enabled = true;    

            // Resize check

            if (orbFlyToId.Length >= orbFlyToId.Size)
            {
                orbFlyToId.Size *= 2;
                Array.Resize(ref orbFlyToId.Elements, orbFlyToId.Size);

                orbFlyTo.Size *= 2;
                Array.Resize(ref orbFlyTo.Elements, orbFlyTo.Size);
            }
        }

        public static void AddOrbUpDownOscillation(OrbUpDownOscillation component)
        {
            // Setup

            if (orbUpDownOscillationId.Elements == null)
            {
                orbUpDownOscillationId.Size = 8;
                orbUpDownOscillationId.Elements = new int[orbUpDownOscillationId.Size];
            }

            if (orbUpDownOscillation.Elements == null)
            {
                orbUpDownOscillation.Size = 8;
                orbUpDownOscillation.Elements = new OrbUpDownOscillation[orbUpDownOscillation.Size];
            }

            // Add

            orbUpDownOscillationId.Elements[orbUpDownOscillationId.Length++] = component.gameObject.GetInstanceID();
            orbUpDownOscillation.Elements[orbUpDownOscillation.Length++] = component;
            component.enabled = true;    

            // Resize check

            if (orbUpDownOscillationId.Length >= orbUpDownOscillationId.Size)
            {
                orbUpDownOscillationId.Size *= 2;
                Array.Resize(ref orbUpDownOscillationId.Elements, orbUpDownOscillationId.Size);

                orbUpDownOscillation.Size *= 2;
                Array.Resize(ref orbUpDownOscillation.Elements, orbUpDownOscillation.Size);
            }
        }

        public static void AddRandomInitialPosition(RandomInitialPosition component)
        {
            // Setup

            if (randomInitialPositionId.Elements == null)
            {
                randomInitialPositionId.Size = 8;
                randomInitialPositionId.Elements = new int[randomInitialPositionId.Size];
            }

            if (randomInitialPosition.Elements == null)
            {
                randomInitialPosition.Size = 8;
                randomInitialPosition.Elements = new RandomInitialPosition[randomInitialPosition.Size];
            }

            // Add

            randomInitialPositionId.Elements[randomInitialPositionId.Length++] = component.gameObject.GetInstanceID();
            randomInitialPosition.Elements[randomInitialPosition.Length++] = component;
            component.enabled = true;    

            // Resize check

            if (randomInitialPositionId.Length >= randomInitialPositionId.Size)
            {
                randomInitialPositionId.Size *= 2;
                Array.Resize(ref randomInitialPositionId.Elements, randomInitialPositionId.Size);

                randomInitialPosition.Size *= 2;
                Array.Resize(ref randomInitialPosition.Elements, randomInitialPosition.Size);
            }
        }

        public static void AddRotator(Rotator component)
        {
            // Setup

            if (rotatorId.Elements == null)
            {
                rotatorId.Size = 8;
                rotatorId.Elements = new int[rotatorId.Size];
            }

            if (rotator.Elements == null)
            {
                rotator.Size = 8;
                rotator.Elements = new Rotator[rotator.Size];
            }

            // Add

            rotatorId.Elements[rotatorId.Length++] = component.gameObject.GetInstanceID();
            rotator.Elements[rotator.Length++] = component;
            component.enabled = true;    

            // Resize check

            if (rotatorId.Length >= rotatorId.Size)
            {
                rotatorId.Size *= 2;
                Array.Resize(ref rotatorId.Elements, rotatorId.Size);

                rotator.Size *= 2;
                Array.Resize(ref rotator.Elements, rotator.Size);
            }
        }

        public static void AddScalePunchTween(ScalePunchTween component)
        {
            // Setup

            if (scalePunchTweenId.Elements == null)
            {
                scalePunchTweenId.Size = 8;
                scalePunchTweenId.Elements = new int[scalePunchTweenId.Size];
            }

            if (scalePunchTween.Elements == null)
            {
                scalePunchTween.Size = 8;
                scalePunchTween.Elements = new ScalePunchTween[scalePunchTween.Size];
            }

            // Add

            scalePunchTweenId.Elements[scalePunchTweenId.Length++] = component.gameObject.GetInstanceID();
            scalePunchTween.Elements[scalePunchTween.Length++] = component;
            component.enabled = true;    

            // Resize check

            if (scalePunchTweenId.Length >= scalePunchTweenId.Size)
            {
                scalePunchTweenId.Size *= 2;
                Array.Resize(ref scalePunchTweenId.Elements, scalePunchTweenId.Size);

                scalePunchTween.Size *= 2;
                Array.Resize(ref scalePunchTween.Elements, scalePunchTween.Size);
            }
        }

        public static void RemoveClosestCollider(GameObject gameObject)
        {
            // Finding the index

            var id = gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < closestColliderId.Length; i++)
            {
                if (closestColliderId.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                closestColliderId.Elements, indexToRemove + 1,
                closestColliderId.Elements, indexToRemove,
                closestColliderId.Length - indexToRemove - 1);
            closestColliderId.Length--;

            Array.Copy(
                closestCollider.Elements, indexToRemove + 1,
                closestCollider.Elements, indexToRemove,
                closestCollider.Length - indexToRemove - 1);
            closestCollider.Length--;

            // Component destruction

            if (gameObject != null)
                GameObject.Destroy(gameObject.GetComponent<ClosestCollider>());
        }

        public static void RemoveEyeAwaySystem(GameObject gameObject)
        {
            // Finding the index

            var id = gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < eyeAwaySystemId.Length; i++)
            {
                if (eyeAwaySystemId.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                eyeAwaySystemId.Elements, indexToRemove + 1,
                eyeAwaySystemId.Elements, indexToRemove,
                eyeAwaySystemId.Length - indexToRemove - 1);
            eyeAwaySystemId.Length--;

            Array.Copy(
                eyeAwaySystem.Elements, indexToRemove + 1,
                eyeAwaySystem.Elements, indexToRemove,
                eyeAwaySystem.Length - indexToRemove - 1);
            eyeAwaySystem.Length--;

            // Component destruction

            if (gameObject != null)
                GameObject.Destroy(gameObject.GetComponent<EyeAwaySystem>());
        }

        public static void RemoveEyeTag(GameObject gameObject)
        {
            // Finding the index

            var id = gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < eyeTagId.Length; i++)
            {
                if (eyeTagId.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                eyeTagId.Elements, indexToRemove + 1,
                eyeTagId.Elements, indexToRemove,
                eyeTagId.Length - indexToRemove - 1);
            eyeTagId.Length--;

            Array.Copy(
                eyeTag.Elements, indexToRemove + 1,
                eyeTag.Elements, indexToRemove,
                eyeTag.Length - indexToRemove - 1);
            eyeTag.Length--;

            // Component destruction

            if (gameObject != null)
                GameObject.Destroy(gameObject.GetComponent<EyeTag>());
        }

        public static void RemoveFlyingLight(GameObject gameObject)
        {
            // Finding the index

            var id = gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < flyingLightId.Length; i++)
            {
                if (flyingLightId.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                flyingLightId.Elements, indexToRemove + 1,
                flyingLightId.Elements, indexToRemove,
                flyingLightId.Length - indexToRemove - 1);
            flyingLightId.Length--;

            Array.Copy(
                flyingLight.Elements, indexToRemove + 1,
                flyingLight.Elements, indexToRemove,
                flyingLight.Length - indexToRemove - 1);
            flyingLight.Length--;

            // Component destruction

            if (gameObject != null)
                GameObject.Destroy(gameObject.GetComponent<FlyingLight>());
        }

        public static void RemoveGun(GameObject gameObject)
        {
            // Finding the index

            var id = gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < gunId.Length; i++)
            {
                if (gunId.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                gunId.Elements, indexToRemove + 1,
                gunId.Elements, indexToRemove,
                gunId.Length - indexToRemove - 1);
            gunId.Length--;

            Array.Copy(
                gun.Elements, indexToRemove + 1,
                gun.Elements, indexToRemove,
                gun.Length - indexToRemove - 1);
            gun.Length--;

            // Component destruction

            if (gameObject != null)
                GameObject.Destroy(gameObject.GetComponent<Gun>());
        }

        public static void RemoveLucy(GameObject gameObject)
        {
            // Finding the index

            var id = gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < lucyId.Length; i++)
            {
                if (lucyId.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                lucyId.Elements, indexToRemove + 1,
                lucyId.Elements, indexToRemove,
                lucyId.Length - indexToRemove - 1);
            lucyId.Length--;

            Array.Copy(
                lucy.Elements, indexToRemove + 1,
                lucy.Elements, indexToRemove,
                lucy.Length - indexToRemove - 1);
            lucy.Length--;

            // Component destruction

            if (gameObject != null)
                GameObject.Destroy(gameObject.GetComponent<Lucy>());
        }

        public static void RemoveMaterialColorCycle(GameObject gameObject)
        {
            // Finding the index

            var id = gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < materialColorCycleId.Length; i++)
            {
                if (materialColorCycleId.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                materialColorCycleId.Elements, indexToRemove + 1,
                materialColorCycleId.Elements, indexToRemove,
                materialColorCycleId.Length - indexToRemove - 1);
            materialColorCycleId.Length--;

            Array.Copy(
                materialColorCycle.Elements, indexToRemove + 1,
                materialColorCycle.Elements, indexToRemove,
                materialColorCycle.Length - indexToRemove - 1);
            materialColorCycle.Length--;

            // Component destruction

            if (gameObject != null)
                GameObject.Destroy(gameObject.GetComponent<MaterialColorCycle>());
        }

        public static void RemoveOnMultiVREvent(GameObject gameObject)
        {
            // Finding the index

            var id = gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < onMultiVREventId.Length; i++)
            {
                if (onMultiVREventId.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                onMultiVREventId.Elements, indexToRemove + 1,
                onMultiVREventId.Elements, indexToRemove,
                onMultiVREventId.Length - indexToRemove - 1);
            onMultiVREventId.Length--;

            Array.Copy(
                onMultiVREvent.Elements, indexToRemove + 1,
                onMultiVREvent.Elements, indexToRemove,
                onMultiVREvent.Length - indexToRemove - 1);
            onMultiVREvent.Length--;

            // Component destruction

            if (gameObject != null)
                GameObject.Destroy(gameObject.GetComponent<OnMultiVREvent>());
        }

        public static void RemoveOrbBecomesAliveBehaviour(GameObject gameObject)
        {
            // Finding the index

            var id = gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < orbBecomesAliveBehaviourId.Length; i++)
            {
                if (orbBecomesAliveBehaviourId.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                orbBecomesAliveBehaviourId.Elements, indexToRemove + 1,
                orbBecomesAliveBehaviourId.Elements, indexToRemove,
                orbBecomesAliveBehaviourId.Length - indexToRemove - 1);
            orbBecomesAliveBehaviourId.Length--;

            Array.Copy(
                orbBecomesAliveBehaviour.Elements, indexToRemove + 1,
                orbBecomesAliveBehaviour.Elements, indexToRemove,
                orbBecomesAliveBehaviour.Length - indexToRemove - 1);
            orbBecomesAliveBehaviour.Length--;

            // Component destruction

            if (gameObject != null)
                GameObject.Destroy(gameObject.GetComponent<OrbBecomesAliveBehaviour>());
        }

        public static void RemoveOrbFlyTo(GameObject gameObject)
        {
            // Finding the index

            var id = gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < orbFlyToId.Length; i++)
            {
                if (orbFlyToId.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                orbFlyToId.Elements, indexToRemove + 1,
                orbFlyToId.Elements, indexToRemove,
                orbFlyToId.Length - indexToRemove - 1);
            orbFlyToId.Length--;

            Array.Copy(
                orbFlyTo.Elements, indexToRemove + 1,
                orbFlyTo.Elements, indexToRemove,
                orbFlyTo.Length - indexToRemove - 1);
            orbFlyTo.Length--;

            // Component destruction

            if (gameObject != null)
                GameObject.Destroy(gameObject.GetComponent<OrbFlyTo>());
        }

        public static void RemoveOrbUpDownOscillation(GameObject gameObject)
        {
            // Finding the index

            var id = gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < orbUpDownOscillationId.Length; i++)
            {
                if (orbUpDownOscillationId.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                orbUpDownOscillationId.Elements, indexToRemove + 1,
                orbUpDownOscillationId.Elements, indexToRemove,
                orbUpDownOscillationId.Length - indexToRemove - 1);
            orbUpDownOscillationId.Length--;

            Array.Copy(
                orbUpDownOscillation.Elements, indexToRemove + 1,
                orbUpDownOscillation.Elements, indexToRemove,
                orbUpDownOscillation.Length - indexToRemove - 1);
            orbUpDownOscillation.Length--;

            // Component destruction

            if (gameObject != null)
                GameObject.Destroy(gameObject.GetComponent<OrbUpDownOscillation>());
        }

        public static void RemoveRandomInitialPosition(GameObject gameObject)
        {
            // Finding the index

            var id = gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < randomInitialPositionId.Length; i++)
            {
                if (randomInitialPositionId.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

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

            // Component destruction

            if (gameObject != null)
                GameObject.Destroy(gameObject.GetComponent<RandomInitialPosition>());
        }

        public static void RemoveRotator(GameObject gameObject)
        {
            // Finding the index

            var id = gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < rotatorId.Length; i++)
            {
                if (rotatorId.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                rotatorId.Elements, indexToRemove + 1,
                rotatorId.Elements, indexToRemove,
                rotatorId.Length - indexToRemove - 1);
            rotatorId.Length--;

            Array.Copy(
                rotator.Elements, indexToRemove + 1,
                rotator.Elements, indexToRemove,
                rotator.Length - indexToRemove - 1);
            rotator.Length--;

            // Component destruction

            if (gameObject != null)
                GameObject.Destroy(gameObject.GetComponent<Rotator>());
        }

        public static void RemoveScalePunchTween(GameObject gameObject)
        {
            // Finding the index

            var id = gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < scalePunchTweenId.Length; i++)
            {
                if (scalePunchTweenId.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                scalePunchTweenId.Elements, indexToRemove + 1,
                scalePunchTweenId.Elements, indexToRemove,
                scalePunchTweenId.Length - indexToRemove - 1);
            scalePunchTweenId.Length--;

            Array.Copy(
                scalePunchTween.Elements, indexToRemove + 1,
                scalePunchTween.Elements, indexToRemove,
                scalePunchTween.Length - indexToRemove - 1);
            scalePunchTween.Length--;

            // Component destruction

            if (gameObject != null)
                GameObject.Destroy(gameObject.GetComponent<ScalePunchTween>());
        }

        public static void RemoveClosestCollider(ClosestCollider component)
        {
            // Finding the index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < closestColliderId.Length; i++)
            {
                if (closestColliderId.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                closestColliderId.Elements, indexToRemove + 1,
                closestColliderId.Elements, indexToRemove,
                closestColliderId.Length - indexToRemove - 1);
            closestColliderId.Length--;

            Array.Copy(
                closestCollider.Elements, indexToRemove + 1,
                closestCollider.Elements, indexToRemove,
                closestCollider.Length - indexToRemove - 1);
            closestCollider.Length--;

            // Component destruction

            if (component != null)
                GameObject.Destroy(component);
        }

        public static void RemoveEyeAwaySystem(EyeAwaySystem component)
        {
            // Finding the index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < eyeAwaySystemId.Length; i++)
            {
                if (eyeAwaySystemId.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                eyeAwaySystemId.Elements, indexToRemove + 1,
                eyeAwaySystemId.Elements, indexToRemove,
                eyeAwaySystemId.Length - indexToRemove - 1);
            eyeAwaySystemId.Length--;

            Array.Copy(
                eyeAwaySystem.Elements, indexToRemove + 1,
                eyeAwaySystem.Elements, indexToRemove,
                eyeAwaySystem.Length - indexToRemove - 1);
            eyeAwaySystem.Length--;

            // Component destruction

            if (component != null)
                GameObject.Destroy(component);
        }

        public static void RemoveEyeTag(EyeTag component)
        {
            // Finding the index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < eyeTagId.Length; i++)
            {
                if (eyeTagId.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                eyeTagId.Elements, indexToRemove + 1,
                eyeTagId.Elements, indexToRemove,
                eyeTagId.Length - indexToRemove - 1);
            eyeTagId.Length--;

            Array.Copy(
                eyeTag.Elements, indexToRemove + 1,
                eyeTag.Elements, indexToRemove,
                eyeTag.Length - indexToRemove - 1);
            eyeTag.Length--;

            // Component destruction

            if (component != null)
                GameObject.Destroy(component);
        }

        public static void RemoveFlyingLight(FlyingLight component)
        {
            // Finding the index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < flyingLightId.Length; i++)
            {
                if (flyingLightId.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                flyingLightId.Elements, indexToRemove + 1,
                flyingLightId.Elements, indexToRemove,
                flyingLightId.Length - indexToRemove - 1);
            flyingLightId.Length--;

            Array.Copy(
                flyingLight.Elements, indexToRemove + 1,
                flyingLight.Elements, indexToRemove,
                flyingLight.Length - indexToRemove - 1);
            flyingLight.Length--;

            // Component destruction

            if (component != null)
                GameObject.Destroy(component);
        }

        public static void RemoveGun(Gun component)
        {
            // Finding the index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < gunId.Length; i++)
            {
                if (gunId.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                gunId.Elements, indexToRemove + 1,
                gunId.Elements, indexToRemove,
                gunId.Length - indexToRemove - 1);
            gunId.Length--;

            Array.Copy(
                gun.Elements, indexToRemove + 1,
                gun.Elements, indexToRemove,
                gun.Length - indexToRemove - 1);
            gun.Length--;

            // Component destruction

            if (component != null)
                GameObject.Destroy(component);
        }

        public static void RemoveLucy(Lucy component)
        {
            // Finding the index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < lucyId.Length; i++)
            {
                if (lucyId.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                lucyId.Elements, indexToRemove + 1,
                lucyId.Elements, indexToRemove,
                lucyId.Length - indexToRemove - 1);
            lucyId.Length--;

            Array.Copy(
                lucy.Elements, indexToRemove + 1,
                lucy.Elements, indexToRemove,
                lucy.Length - indexToRemove - 1);
            lucy.Length--;

            // Component destruction

            if (component != null)
                GameObject.Destroy(component);
        }

        public static void RemoveMaterialColorCycle(MaterialColorCycle component)
        {
            // Finding the index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < materialColorCycleId.Length; i++)
            {
                if (materialColorCycleId.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                materialColorCycleId.Elements, indexToRemove + 1,
                materialColorCycleId.Elements, indexToRemove,
                materialColorCycleId.Length - indexToRemove - 1);
            materialColorCycleId.Length--;

            Array.Copy(
                materialColorCycle.Elements, indexToRemove + 1,
                materialColorCycle.Elements, indexToRemove,
                materialColorCycle.Length - indexToRemove - 1);
            materialColorCycle.Length--;

            // Component destruction

            if (component != null)
                GameObject.Destroy(component);
        }

        public static void RemoveOnMultiVREvent(OnMultiVREvent component)
        {
            // Finding the index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < onMultiVREventId.Length; i++)
            {
                if (onMultiVREventId.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                onMultiVREventId.Elements, indexToRemove + 1,
                onMultiVREventId.Elements, indexToRemove,
                onMultiVREventId.Length - indexToRemove - 1);
            onMultiVREventId.Length--;

            Array.Copy(
                onMultiVREvent.Elements, indexToRemove + 1,
                onMultiVREvent.Elements, indexToRemove,
                onMultiVREvent.Length - indexToRemove - 1);
            onMultiVREvent.Length--;

            // Component destruction

            if (component != null)
                GameObject.Destroy(component);
        }

        public static void RemoveOrbBecomesAliveBehaviour(OrbBecomesAliveBehaviour component)
        {
            // Finding the index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < orbBecomesAliveBehaviourId.Length; i++)
            {
                if (orbBecomesAliveBehaviourId.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                orbBecomesAliveBehaviourId.Elements, indexToRemove + 1,
                orbBecomesAliveBehaviourId.Elements, indexToRemove,
                orbBecomesAliveBehaviourId.Length - indexToRemove - 1);
            orbBecomesAliveBehaviourId.Length--;

            Array.Copy(
                orbBecomesAliveBehaviour.Elements, indexToRemove + 1,
                orbBecomesAliveBehaviour.Elements, indexToRemove,
                orbBecomesAliveBehaviour.Length - indexToRemove - 1);
            orbBecomesAliveBehaviour.Length--;

            // Component destruction

            if (component != null)
                GameObject.Destroy(component);
        }

        public static void RemoveOrbFlyTo(OrbFlyTo component)
        {
            // Finding the index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < orbFlyToId.Length; i++)
            {
                if (orbFlyToId.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                orbFlyToId.Elements, indexToRemove + 1,
                orbFlyToId.Elements, indexToRemove,
                orbFlyToId.Length - indexToRemove - 1);
            orbFlyToId.Length--;

            Array.Copy(
                orbFlyTo.Elements, indexToRemove + 1,
                orbFlyTo.Elements, indexToRemove,
                orbFlyTo.Length - indexToRemove - 1);
            orbFlyTo.Length--;

            // Component destruction

            if (component != null)
                GameObject.Destroy(component);
        }

        public static void RemoveOrbUpDownOscillation(OrbUpDownOscillation component)
        {
            // Finding the index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < orbUpDownOscillationId.Length; i++)
            {
                if (orbUpDownOscillationId.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                orbUpDownOscillationId.Elements, indexToRemove + 1,
                orbUpDownOscillationId.Elements, indexToRemove,
                orbUpDownOscillationId.Length - indexToRemove - 1);
            orbUpDownOscillationId.Length--;

            Array.Copy(
                orbUpDownOscillation.Elements, indexToRemove + 1,
                orbUpDownOscillation.Elements, indexToRemove,
                orbUpDownOscillation.Length - indexToRemove - 1);
            orbUpDownOscillation.Length--;

            // Component destruction

            if (component != null)
                GameObject.Destroy(component);
        }

        public static void RemoveRandomInitialPosition(RandomInitialPosition component)
        {
            // Finding the index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < randomInitialPositionId.Length; i++)
            {
                if (randomInitialPositionId.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

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

            // Component destruction

            if (component != null)
                GameObject.Destroy(component);
        }

        public static void RemoveRotator(Rotator component)
        {
            // Finding the index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < rotatorId.Length; i++)
            {
                if (rotatorId.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                rotatorId.Elements, indexToRemove + 1,
                rotatorId.Elements, indexToRemove,
                rotatorId.Length - indexToRemove - 1);
            rotatorId.Length--;

            Array.Copy(
                rotator.Elements, indexToRemove + 1,
                rotator.Elements, indexToRemove,
                rotator.Length - indexToRemove - 1);
            rotator.Length--;

            // Component destruction

            if (component != null)
                GameObject.Destroy(component);
        }

        public static void RemoveScalePunchTween(ScalePunchTween component)
        {
            // Finding the index

            var id = component.gameObject.GetInstanceID();
            var indexToRemove = -1;
            for (int i = 0; i < scalePunchTweenId.Length; i++)
            {
                if (scalePunchTweenId.Elements[i] == id)
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Overwrite

            Array.Copy(
                scalePunchTweenId.Elements, indexToRemove + 1,
                scalePunchTweenId.Elements, indexToRemove,
                scalePunchTweenId.Length - indexToRemove - 1);
            scalePunchTweenId.Length--;

            Array.Copy(
                scalePunchTween.Elements, indexToRemove + 1,
                scalePunchTween.Elements, indexToRemove,
                scalePunchTween.Length - indexToRemove - 1);
            scalePunchTween.Length--;

            // Component destruction

            if (component != null)
                GameObject.Destroy(component);
        }

        public static Arrayx<ClosestCollider> GetClosestCollider(params Arrayx<int>[] ids)
        {
            // closestColliderId needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] idsWithClosestCollider = new Arrayx<int>[ids.Length + 1];
            idsWithClosestCollider[0] = closestColliderId;
            Array.Copy(ids, 0, idsWithClosestCollider, 1, ids.Length);

            return Gigas.Get<ClosestCollider>(idsWithClosestCollider, EntitySet.closestCollider);
        }

        public static Arrayx<EyeAwaySystem> GetEyeAwaySystem(params Arrayx<int>[] ids)
        {
            // eyeAwaySystemId needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] idsWithEyeAwaySystem = new Arrayx<int>[ids.Length + 1];
            idsWithEyeAwaySystem[0] = eyeAwaySystemId;
            Array.Copy(ids, 0, idsWithEyeAwaySystem, 1, ids.Length);

            return Gigas.Get<EyeAwaySystem>(idsWithEyeAwaySystem, EntitySet.eyeAwaySystem);
        }

        public static Arrayx<EyeTag> GetEyeTag(params Arrayx<int>[] ids)
        {
            // eyeTagId needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] idsWithEyeTag = new Arrayx<int>[ids.Length + 1];
            idsWithEyeTag[0] = eyeTagId;
            Array.Copy(ids, 0, idsWithEyeTag, 1, ids.Length);

            return Gigas.Get<EyeTag>(idsWithEyeTag, EntitySet.eyeTag);
        }

        public static Arrayx<FlyingLight> GetFlyingLight(params Arrayx<int>[] ids)
        {
            // flyingLightId needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] idsWithFlyingLight = new Arrayx<int>[ids.Length + 1];
            idsWithFlyingLight[0] = flyingLightId;
            Array.Copy(ids, 0, idsWithFlyingLight, 1, ids.Length);

            return Gigas.Get<FlyingLight>(idsWithFlyingLight, EntitySet.flyingLight);
        }

        public static Arrayx<Gun> GetGun(params Arrayx<int>[] ids)
        {
            // gunId needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] idsWithGun = new Arrayx<int>[ids.Length + 1];
            idsWithGun[0] = gunId;
            Array.Copy(ids, 0, idsWithGun, 1, ids.Length);

            return Gigas.Get<Gun>(idsWithGun, EntitySet.gun);
        }

        public static Arrayx<Lucy> GetLucy(params Arrayx<int>[] ids)
        {
            // lucyId needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] idsWithLucy = new Arrayx<int>[ids.Length + 1];
            idsWithLucy[0] = lucyId;
            Array.Copy(ids, 0, idsWithLucy, 1, ids.Length);

            return Gigas.Get<Lucy>(idsWithLucy, EntitySet.lucy);
        }

        public static Arrayx<MaterialColorCycle> GetMaterialColorCycle(params Arrayx<int>[] ids)
        {
            // materialColorCycleId needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] idsWithMaterialColorCycle = new Arrayx<int>[ids.Length + 1];
            idsWithMaterialColorCycle[0] = materialColorCycleId;
            Array.Copy(ids, 0, idsWithMaterialColorCycle, 1, ids.Length);

            return Gigas.Get<MaterialColorCycle>(idsWithMaterialColorCycle, EntitySet.materialColorCycle);
        }

        public static Arrayx<OnMultiVREvent> GetOnMultiVREvent(params Arrayx<int>[] ids)
        {
            // onMultiVREventId needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] idsWithOnMultiVREvent = new Arrayx<int>[ids.Length + 1];
            idsWithOnMultiVREvent[0] = onMultiVREventId;
            Array.Copy(ids, 0, idsWithOnMultiVREvent, 1, ids.Length);

            return Gigas.Get<OnMultiVREvent>(idsWithOnMultiVREvent, EntitySet.onMultiVREvent);
        }

        public static Arrayx<OrbBecomesAliveBehaviour> GetOrbBecomesAliveBehaviour(params Arrayx<int>[] ids)
        {
            // orbBecomesAliveBehaviourId needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] idsWithOrbBecomesAliveBehaviour = new Arrayx<int>[ids.Length + 1];
            idsWithOrbBecomesAliveBehaviour[0] = orbBecomesAliveBehaviourId;
            Array.Copy(ids, 0, idsWithOrbBecomesAliveBehaviour, 1, ids.Length);

            return Gigas.Get<OrbBecomesAliveBehaviour>(idsWithOrbBecomesAliveBehaviour, EntitySet.orbBecomesAliveBehaviour);
        }

        public static Arrayx<OrbFlyTo> GetOrbFlyTo(params Arrayx<int>[] ids)
        {
            // orbFlyToId needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] idsWithOrbFlyTo = new Arrayx<int>[ids.Length + 1];
            idsWithOrbFlyTo[0] = orbFlyToId;
            Array.Copy(ids, 0, idsWithOrbFlyTo, 1, ids.Length);

            return Gigas.Get<OrbFlyTo>(idsWithOrbFlyTo, EntitySet.orbFlyTo);
        }

        public static Arrayx<OrbUpDownOscillation> GetOrbUpDownOscillation(params Arrayx<int>[] ids)
        {
            // orbUpDownOscillationId needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] idsWithOrbUpDownOscillation = new Arrayx<int>[ids.Length + 1];
            idsWithOrbUpDownOscillation[0] = orbUpDownOscillationId;
            Array.Copy(ids, 0, idsWithOrbUpDownOscillation, 1, ids.Length);

            return Gigas.Get<OrbUpDownOscillation>(idsWithOrbUpDownOscillation, EntitySet.orbUpDownOscillation);
        }

        public static Arrayx<RandomInitialPosition> GetRandomInitialPosition(params Arrayx<int>[] ids)
        {
            // randomInitialPositionId needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] idsWithRandomInitialPosition = new Arrayx<int>[ids.Length + 1];
            idsWithRandomInitialPosition[0] = randomInitialPositionId;
            Array.Copy(ids, 0, idsWithRandomInitialPosition, 1, ids.Length);

            return Gigas.Get<RandomInitialPosition>(idsWithRandomInitialPosition, EntitySet.randomInitialPosition);
        }

        public static Arrayx<Rotator> GetRotator(params Arrayx<int>[] ids)
        {
            // rotatorId needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] idsWithRotator = new Arrayx<int>[ids.Length + 1];
            idsWithRotator[0] = rotatorId;
            Array.Copy(ids, 0, idsWithRotator, 1, ids.Length);

            return Gigas.Get<Rotator>(idsWithRotator, EntitySet.rotator);
        }

        public static Arrayx<ScalePunchTween> GetScalePunchTween(params Arrayx<int>[] ids)
        {
            // scalePunchTweenId needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] idsWithScalePunchTween = new Arrayx<int>[ids.Length + 1];
            idsWithScalePunchTween[0] = scalePunchTweenId;
            Array.Copy(ids, 0, idsWithScalePunchTween, 1, ids.Length);

            return Gigas.Get<ScalePunchTween>(idsWithScalePunchTween, EntitySet.scalePunchTween);
        }

        public static Dictionary<int, int> closestColliderIndex = new Dictionary<int, int>();
        public static ClosestCollider GetClosestCollider(GameObject gameObject)
        {
            var id = gameObject.GetInstanceID();

            // Cache

            if (closestColliderIndex.ContainsKey(id))
                return closestCollider.Elements[closestColliderIndex[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < closestColliderId.Length; i++)
            {
                if (closestColliderId.Elements[i] == id)
                {
                    index = i;
                    closestColliderIndex[id] = i; // Cache
                    break;
                }
            }

            return closestCollider.Elements[index];
        }

        public static Dictionary<int, int> eyeAwaySystemIndex = new Dictionary<int, int>();
        public static EyeAwaySystem GetEyeAwaySystem(GameObject gameObject)
        {
            var id = gameObject.GetInstanceID();

            // Cache

            if (eyeAwaySystemIndex.ContainsKey(id))
                return eyeAwaySystem.Elements[eyeAwaySystemIndex[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < eyeAwaySystemId.Length; i++)
            {
                if (eyeAwaySystemId.Elements[i] == id)
                {
                    index = i;
                    eyeAwaySystemIndex[id] = i; // Cache
                    break;
                }
            }

            return eyeAwaySystem.Elements[index];
        }

        public static Dictionary<int, int> eyeTagIndex = new Dictionary<int, int>();
        public static EyeTag GetEyeTag(GameObject gameObject)
        {
            var id = gameObject.GetInstanceID();

            // Cache

            if (eyeTagIndex.ContainsKey(id))
                return eyeTag.Elements[eyeTagIndex[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < eyeTagId.Length; i++)
            {
                if (eyeTagId.Elements[i] == id)
                {
                    index = i;
                    eyeTagIndex[id] = i; // Cache
                    break;
                }
            }

            return eyeTag.Elements[index];
        }

        public static Dictionary<int, int> flyingLightIndex = new Dictionary<int, int>();
        public static FlyingLight GetFlyingLight(GameObject gameObject)
        {
            var id = gameObject.GetInstanceID();

            // Cache

            if (flyingLightIndex.ContainsKey(id))
                return flyingLight.Elements[flyingLightIndex[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < flyingLightId.Length; i++)
            {
                if (flyingLightId.Elements[i] == id)
                {
                    index = i;
                    flyingLightIndex[id] = i; // Cache
                    break;
                }
            }

            return flyingLight.Elements[index];
        }

        public static Dictionary<int, int> gunIndex = new Dictionary<int, int>();
        public static Gun GetGun(GameObject gameObject)
        {
            var id = gameObject.GetInstanceID();

            // Cache

            if (gunIndex.ContainsKey(id))
                return gun.Elements[gunIndex[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < gunId.Length; i++)
            {
                if (gunId.Elements[i] == id)
                {
                    index = i;
                    gunIndex[id] = i; // Cache
                    break;
                }
            }

            return gun.Elements[index];
        }

        public static Dictionary<int, int> lucyIndex = new Dictionary<int, int>();
        public static Lucy GetLucy(GameObject gameObject)
        {
            var id = gameObject.GetInstanceID();

            // Cache

            if (lucyIndex.ContainsKey(id))
                return lucy.Elements[lucyIndex[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < lucyId.Length; i++)
            {
                if (lucyId.Elements[i] == id)
                {
                    index = i;
                    lucyIndex[id] = i; // Cache
                    break;
                }
            }

            return lucy.Elements[index];
        }

        public static Dictionary<int, int> materialColorCycleIndex = new Dictionary<int, int>();
        public static MaterialColorCycle GetMaterialColorCycle(GameObject gameObject)
        {
            var id = gameObject.GetInstanceID();

            // Cache

            if (materialColorCycleIndex.ContainsKey(id))
                return materialColorCycle.Elements[materialColorCycleIndex[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < materialColorCycleId.Length; i++)
            {
                if (materialColorCycleId.Elements[i] == id)
                {
                    index = i;
                    materialColorCycleIndex[id] = i; // Cache
                    break;
                }
            }

            return materialColorCycle.Elements[index];
        }

        public static Dictionary<int, int> onMultiVREventIndex = new Dictionary<int, int>();
        public static OnMultiVREvent GetOnMultiVREvent(GameObject gameObject)
        {
            var id = gameObject.GetInstanceID();

            // Cache

            if (onMultiVREventIndex.ContainsKey(id))
                return onMultiVREvent.Elements[onMultiVREventIndex[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < onMultiVREventId.Length; i++)
            {
                if (onMultiVREventId.Elements[i] == id)
                {
                    index = i;
                    onMultiVREventIndex[id] = i; // Cache
                    break;
                }
            }

            return onMultiVREvent.Elements[index];
        }

        public static Dictionary<int, int> orbBecomesAliveBehaviourIndex = new Dictionary<int, int>();
        public static OrbBecomesAliveBehaviour GetOrbBecomesAliveBehaviour(GameObject gameObject)
        {
            var id = gameObject.GetInstanceID();

            // Cache

            if (orbBecomesAliveBehaviourIndex.ContainsKey(id))
                return orbBecomesAliveBehaviour.Elements[orbBecomesAliveBehaviourIndex[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < orbBecomesAliveBehaviourId.Length; i++)
            {
                if (orbBecomesAliveBehaviourId.Elements[i] == id)
                {
                    index = i;
                    orbBecomesAliveBehaviourIndex[id] = i; // Cache
                    break;
                }
            }

            return orbBecomesAliveBehaviour.Elements[index];
        }

        public static Dictionary<int, int> orbFlyToIndex = new Dictionary<int, int>();
        public static OrbFlyTo GetOrbFlyTo(GameObject gameObject)
        {
            var id = gameObject.GetInstanceID();

            // Cache

            if (orbFlyToIndex.ContainsKey(id))
                return orbFlyTo.Elements[orbFlyToIndex[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < orbFlyToId.Length; i++)
            {
                if (orbFlyToId.Elements[i] == id)
                {
                    index = i;
                    orbFlyToIndex[id] = i; // Cache
                    break;
                }
            }

            return orbFlyTo.Elements[index];
        }

        public static Dictionary<int, int> orbUpDownOscillationIndex = new Dictionary<int, int>();
        public static OrbUpDownOscillation GetOrbUpDownOscillation(GameObject gameObject)
        {
            var id = gameObject.GetInstanceID();

            // Cache

            if (orbUpDownOscillationIndex.ContainsKey(id))
                return orbUpDownOscillation.Elements[orbUpDownOscillationIndex[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < orbUpDownOscillationId.Length; i++)
            {
                if (orbUpDownOscillationId.Elements[i] == id)
                {
                    index = i;
                    orbUpDownOscillationIndex[id] = i; // Cache
                    break;
                }
            }

            return orbUpDownOscillation.Elements[index];
        }

        public static Dictionary<int, int> randomInitialPositionIndex = new Dictionary<int, int>();
        public static RandomInitialPosition GetRandomInitialPosition(GameObject gameObject)
        {
            var id = gameObject.GetInstanceID();

            // Cache

            if (randomInitialPositionIndex.ContainsKey(id))
                return randomInitialPosition.Elements[randomInitialPositionIndex[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < randomInitialPositionId.Length; i++)
            {
                if (randomInitialPositionId.Elements[i] == id)
                {
                    index = i;
                    randomInitialPositionIndex[id] = i; // Cache
                    break;
                }
            }

            return randomInitialPosition.Elements[index];
        }

        public static Dictionary<int, int> rotatorIndex = new Dictionary<int, int>();
        public static Rotator GetRotator(GameObject gameObject)
        {
            var id = gameObject.GetInstanceID();

            // Cache

            if (rotatorIndex.ContainsKey(id))
                return rotator.Elements[rotatorIndex[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < rotatorId.Length; i++)
            {
                if (rotatorId.Elements[i] == id)
                {
                    index = i;
                    rotatorIndex[id] = i; // Cache
                    break;
                }
            }

            return rotator.Elements[index];
        }

        public static Dictionary<int, int> scalePunchTweenIndex = new Dictionary<int, int>();
        public static ScalePunchTween GetScalePunchTween(GameObject gameObject)
        {
            var id = gameObject.GetInstanceID();

            // Cache

            if (scalePunchTweenIndex.ContainsKey(id))
                return scalePunchTween.Elements[scalePunchTweenIndex[id]];

            // Index of

            var index = -1;
            for (int i = 0; i < scalePunchTweenId.Length; i++)
            {
                if (scalePunchTweenId.Elements[i] == id)
                {
                    index = i;
                    scalePunchTweenIndex[id] = i; // Cache
                    break;
                }
            }

            return scalePunchTween.Elements[index];
        }
    }
// }
