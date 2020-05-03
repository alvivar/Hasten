using UnityEngine;

namespace Hasten2.Entidades
{
    [System.Serializable]
    public struct Entidad
    {
        public System.Type type;
        public Object obj;
    }

    public class Entidades : MonoBehaviour
    {
        public static int[] entityKeys = new int[0];
        public static Entidad[][] entityValues = new Entidad[0][];

        private static int initialArrayCount = 1000;

        public static void Add(int id, Object obj)
        {
            if (entityKeys == null)
            {
                entityKeys = new int[0];
                entityValues = new Entidad[0][];
                entityValues[0] = new Entidad[0];
            }

            int entityIndex = entityKeys.IndexOf(id);

            if (entityKeys.IndexOf(id) < 0)
            {
                System.Array.Resize<int>(ref entityKeys, entityKeys.Length + 1);
                System.Array.Resize<Entidad[]>(ref entityValues, entityKeys.Length + 1);

                entityIndex = entityKeys.Length - 1;

                entityKeys[entityIndex] = id;
                entityValues[entityIndex] = new Entidad[0];
            }

            // Validate that only exists once
            bool exists = false;
            if (entityValues[entityIndex].Length > 0)
            {
                for (int i = 0; i < entityValues[entityIndex].Length; i++)
                {
                    if (entityValues[entityIndex][i].type == obj.GetType())
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    System.Array.Resize(ref entityValues[entityIndex], entityValues[entityIndex].Length + 1);
                    entityValues[entityIndex][entityValues[entityIndex].Length - 1] = new Entidad() { type = obj.GetType(), obj = obj };
                }
            }
            else
            {
                entityValues[entityIndex] = new Entidad[1] { new Entidad() { type = obj.GetType(), obj = obj } };
            }
        }

        public static void Add(int id, GameObject obj, System.Type type)
        {
            if (entityKeys == null)
            {
                entityKeys = new int[0];
                entityValues = new Entidad[0][];
                entityValues[0] = new Entidad[0];
            }

            int entityIndex = entityKeys.IndexOf(id);

            if (entityIndex < 0)
            {
                System.Array.Resize<int>(ref entityKeys, entityKeys.Length + 1);
                System.Array.Resize<Entidad[]>(ref entityValues, entityKeys.Length + 1);

                entityIndex = entityKeys.Length - 1;

                entityKeys[entityIndex] = id;
                entityValues[entityIndex] = new Entidad[0];
            }

            var objType = obj.AddComponent(type);

            // Validate that only exists once
            bool exists = false;
            if (entityValues[entityIndex].Length > 0)
            {
                for (int i = 0; i < entityValues[entityIndex].Length; i++)
                {
                    if (entityValues[entityIndex][i].type == type)
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    System.Array.Resize(ref entityValues[entityIndex], entityValues[entityIndex].Length + 1);
                    entityValues[entityIndex][entityValues[entityIndex].Length - 1] = new Entidad() { type = type, obj = objType };
                }
            }
            else
            {
                entityValues[entityIndex] = new Entidad[1] { new Entidad() { type = type, obj = objType } };
            }
        }

        public static void Remove(int id, Object obj)
        {
            if (entityKeys == null)
            {
                entityKeys = new int[0];
                entityValues = new Entidad[0][];
                entityValues[0] = new Entidad[0];
            }

            int entityIndex = entityKeys.IndexOf(id);

            if (entityIndex < 0)
            {
                System.Array.Resize<int>(ref entityKeys, entityKeys.Length + 1);
                System.Array.Resize<Entidad[]>(ref entityValues, entityKeys.Length + 1);

                entityIndex = entityKeys.Length - 1;

                entityKeys[entityIndex] = id;
                entityValues[entityIndex] = new Entidad[0];

                return;
            }

            int indexToRemove = -1;
            if (entityValues[entityIndex].Length > 0)
            {
                for (int i = 0; i < entityValues[entityIndex].Length; i++)
                {
                    if (entityValues[entityIndex][i].type == obj.GetType())
                    {
                        indexToRemove = i;
                        break;
                    }
                }

                if (indexToRemove >= 0)
                {
                    for (int i = indexToRemove; i < entityValues[entityIndex].Length - 1; i++)
                    {
                        entityValues[entityIndex][i] = entityValues[entityIndex][i + 1];
                    }

                    System.Array.Resize(ref entityValues[entityIndex], entityValues[entityIndex].Length - 1);
                }
            }
        }

        public static void Remove(int id, GameObject obj, System.Type type)
        {
            if (entityKeys == null)
            {
                entityKeys = new int[0];
                entityValues = new Entidad[0][];
                entityValues[0] = new Entidad[0];
            }

            int entityIndex = entityKeys.IndexOf(id);

            if (entityIndex < 0)
            {
                System.Array.Resize<int>(ref entityKeys, entityKeys.Length + 1);
                System.Array.Resize<Entidad[]>(ref entityValues, entityKeys.Length + 1);

                entityIndex = entityKeys.Length - 1;

                entityKeys[entityIndex] = id;
                entityValues[entityIndex] = new Entidad[0];

                return;
            }

            int indexToRemove = -1;
            if (entityValues[entityIndex].Length > 0)
            {
                for (int i = 0; i < entityValues[entityIndex].Length; i++)
                {
                    if (entityValues[entityIndex][i].type == type)
                    {
                        indexToRemove = i;
                        break;
                    }
                }

                if (indexToRemove >= 0)
                {
                    for (int i = indexToRemove; i < entityValues[entityIndex].Length - 1; i++)
                    {
                        entityValues[entityIndex][i] = entityValues[entityIndex][i + 1];
                    }

                    System.Array.Resize(ref entityValues[entityIndex], entityValues[entityIndex].Length - 1);
                }
            }

            var objType = obj.GetComponent(type);
            Destroy(objType);
        }

        public static T[] Get<T>() where T : MonoBehaviour
        {
            if (entityKeys == null)
            {
                entityKeys = new int[0];
                entityValues = new Entidad[0][];
                entityValues[0] = new Entidad[0];
            }

            var result = new T[initialArrayCount];
            int resultCount = 0;
            int arrayIncreasedTimes = 1;

            foreach (var value in entityValues)
            {
                if (value != null)
                {
                    for (var i = 0; i < value.Length; i += 1)
                    {
                        if (value[i].type == typeof(T))
                        {
                            // System.Array.Resize(ref result, result.Length + 1);
                            // result[result.Length - 1] = (T)value[i].obj;
                            if (resultCount < arrayIncreasedTimes * initialArrayCount)
                            {
                                result[resultCount] = (T) value[i].obj;
                                resultCount++;
                            }
                            else
                            {
                                arrayIncreasedTimes++;
                                System.Array.Resize(ref result, arrayIncreasedTimes * initialArrayCount);

                                result[resultCount] = (T) value[i].obj;
                                resultCount++;
                            }
                        }
                    }
                }
            }

            System.Array.Resize(ref result, resultCount);

            return result;
        }

        public static T[] Get<T>(params System.Type[] types) where T : MonoBehaviour
        {
            if (entityKeys == null)
            {
                entityKeys = new int[0];
                entityValues = new Entidad[0][];
                entityValues[0] = new Entidad[0];
            }

            var result = new T[initialArrayCount];
            int resultCount = 0;
            int arrayIncreasedTimes = 1;

            // Entities Entidad[][]
            foreach (var value in entityValues)
            {
                var objIndex = 0;
                var typeMatches = 0;
                var matchedEntityIndex = -1;

                if (value != null)
                {
                    // Entity component list
                    foreach (var obj in value)
                    {
                        // Types comparison
                        foreach (var type in types)
                        {
                            // Get index of the element that matches the type
                            if (obj.type == typeof(T))
                                matchedEntityIndex = objIndex;

                            // Comparing if we have all components
                            if (obj.type == type)
                            {
                                typeMatches++;
                                break;
                            }
                        }

                        objIndex++;
                    }

                    if (typeMatches >= types.Length)
                    {
                        // System.Array.Resize(ref result, result.Length + 1);
                        // result[result.Length - 1] = (T) value[matchedEntityIndex].obj;
                        if (resultCount < arrayIncreasedTimes * initialArrayCount)
                        {
                            result[resultCount] = (T) value[matchedEntityIndex].obj;
                            resultCount++;
                        }
                        else
                        {
                            arrayIncreasedTimes++;
                            System.Array.Resize(ref result, arrayIncreasedTimes * initialArrayCount);

                            result[resultCount] = (T) value[matchedEntityIndex].obj;
                            resultCount++;
                        }
                    }
                }
            }

            System.Array.Resize(ref result, resultCount);

            return result;
        }
    }
}

public static class EntidadesExtension
{
    public static int IndexOf(this int[] array, int id)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == id)
                return i;
        }

        return -1;
    }
}

// TO DO
// Jobs & Burst
// Read me tutorial
// Check this out tailDrops = Entidades.Get<GridData>(typeof(TailDrop)); Make sure you understand why this works.
// Validate that you cannot add more of the same components (?)
// Query a singleton
// Query support Entitades.GetAll(typeof(SnakeInput), typeof(GridData)).Not(typeof(Tail));
//
// DONE
// x Replace everything to array
// x GetAll completely generic, without casting
// x Query support Entitades.GetAll(typeof(SnakeInput), typeof(GridData));
// x GetAll should return the object already converted, not as object

// Experimental

// var resulto = CuteArray.New<T>(initialArrayCount);
// resulto.Add();
// resulto.ToArray();
// result.Value[index]
// resulto.Dispose();