using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Hasten2.Entidades
{
    public class Entidades : MonoBehaviour
    {
        private struct Entidad
        {
            public System.Type type;
            public Object obj;
        }

        private static Dictionary<int, List<Entidad>> entities;

        public static void Add(int id, Object obj)
        {
            if (entities == null)
                entities = new Dictionary<int, List<Entidad>>();

            if (!entities.ContainsKey(id))
                entities[id] = new List<Entidad>();

            // @todo Validate that only exists once

            entities[id].Add(new Entidad() { type = obj.GetType(), obj = obj });
        }

        public static void Add(int id, GameObject obj, System.Type type)
        {
            if (entities == null)
                entities = new Dictionary<int, List<Entidad>>();

            if (!entities.ContainsKey(id))
                entities[id] = new List<Entidad>();

            // @todo Validate that only exists once

            var objType = obj.AddComponent(type);

            entities[id].Add(new Entidad() { type = type, obj = objType });
        }

        public static void Remove(int id, Object obj)
        {
            if (entities == null)
                entities = new Dictionary<int, List<Entidad>>();

            if (!entities.ContainsKey(id))
            {
                entities[id] = new List<Entidad>();
                return;
            }

            int chosen = -1;
            for (var i = 0; i < entities[id].Count; i += 1)
            {
                if (entities[id][i].obj == obj)
                    chosen = i;
            }

            if (chosen >= 0)
                entities[id].RemoveAt(chosen);
        }

        public static void Remove(int id, GameObject obj, System.Type type)
        {
            if (entities == null)
                entities = new Dictionary<int, List<Entidad>>();

            if (!entities.ContainsKey(id))
            {
                entities[id] = new List<Entidad>();
                return;
            }

            var objType = obj.GetComponent(type);

            int chosen = -1;
            for (var i = 0; i < entities[id].Count; i += 1)
            {
                if (entities[id][i].obj == objType)
                    chosen = i;
            }

            if (chosen >= 0)
                entities[id].RemoveAt(chosen);

            Destroy(objType);
        }

        public static IEnumerable<T> Get<T>()
        {
            if (entities == null)
                entities = new Dictionary<int, List<Entidad>>();

            var result = new List<Object>();
            foreach (var keyValue in entities)
            {
                int typeIndex = -1;
                for (var i = 0; i < keyValue.Value.Count; i += 1)
                {
                    if (keyValue.Value[i].type == typeof(T))
                        typeIndex = i;
                }

                if (typeIndex >= 0)
                    result.Add(keyValue.Value[typeIndex].obj);
            }

            return result.Cast<T>();
        }

        public static IEnumerable<T> Get<T>(params System.Type[] types)
        {
            if (entities == null)
                entities = new Dictionary<int, List<Entidad>>();

            var result = new List<Object>();

            // Entities dictionary
            foreach (var keyValue in entities)
            {
                var objIndex = 0;
                var typeMatches = 0;
                var matchedEntityIndex = -1;

                // Entity component list
                foreach (var obj in keyValue.Value)
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
                    result.Add(keyValue.Value[matchedEntityIndex].obj);
            }

            return result.Cast<T>();
        }
    }
}

// TO DO
// Jobs & Burst
// Replace everything to array
// Read me tutorial
// Check this out tailDrops = Entidades.Get<GridData>(typeof(TailDrop)); Make sure you understand why this works.
// Validate that you cannot add more of the same components (?)
// Query a singleton
// Query support Entitades.GetAll(typeof(SnakeInput), typeof(GridData)).Not(typeof(Tail));
//
// DONE
// x GetAll completely generic, without casting
// x Query support Entitades.GetAll(typeof(SnakeInput), typeof(GridData));
// x GetAll should return the object already converted, not as object