// This file is auto-generated. Modifications won't be saved, be cool.

// EntitySet is a static database of GameObjects (Entities) and MonoBehaviour
// classes (Components). Check out 'Femto.cs' for more information about the
// code generated.

// Refresh with the menu item 'Tools/Gigas/Generate EntitySet.cs'

using System;
using System.Collections.Generic;
using UnityEngine;

//  namespace Gigas
//  {
    public static class EntitySet
    {
        // AluminonAgent

        public static Arrayx<int> AluminonAgentIds = Arrayx<int>.New();
        public static Arrayx<AluminonAgent> AluminonAgents = Arrayx<AluminonAgent>.New();

        public static void AddAluminonAgent(AluminonAgent component)
        {
            AluminonAgentIds.Add(component.gameObject.GetInstanceID());
            AluminonAgents.Add(component);
        }

        public static void RemoveAluminonAgent(AluminonAgent component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = AluminonAgentIds.IndexOf(id);

            AluminonAgentIds.RemoveAt(index);
            AluminonAgents.RemoveAt(index);

            AluminonAgentIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<AluminonAgent> AluminonAgentResult = Arrayx<AluminonAgent>.New();
        public static Arrayx<AluminonAgent> GetAluminonAgent(params Arrayx<int>[] ids)
        {
            // AluminonAgentIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] AluminonAgentPlusIds = new Arrayx<int>[ids.Length + 1];
            AluminonAgentPlusIds[0] = AluminonAgentIds;
            Array.Copy(ids, 0, AluminonAgentPlusIds, 1, ids.Length);

            return Gigas.Get<AluminonAgent>(AluminonAgentPlusIds, EntitySet.AluminonAgents, AluminonAgentResult);
        }

        public static AluminonAgent GetAluminonAgent(MonoBehaviour component)
        {
            return GetAluminonAgent(component.gameObject.GetInstanceID());
        }

        public static AluminonAgent GetAluminonAgent(GameObject gameobject)
        {
            return GetAluminonAgent(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> AluminonAgentIdCache = new Dictionary<int, int>();
        public static AluminonAgent GetAluminonAgent(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (AluminonAgentIdCache.TryGetValue(id, out cacheId))
                return AluminonAgents.Elements[cacheId];

            var index = AluminonAgentIds.IndexOf(id);

            if (index < 0)
                return null;

            AluminonAgentIdCache[id] = index; // Cache

            return AluminonAgents.Elements[index];
        }

        // Boxel

        public static Arrayx<int> BoxelIds = Arrayx<int>.New();
        public static Arrayx<Boxel> Boxels = Arrayx<Boxel>.New();

        public static void AddBoxel(Boxel component)
        {
            BoxelIds.Add(component.gameObject.GetInstanceID());
            Boxels.Add(component);
        }

        public static void RemoveBoxel(Boxel component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = BoxelIds.IndexOf(id);

            BoxelIds.RemoveAt(index);
            Boxels.RemoveAt(index);

            BoxelIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<Boxel> BoxelResult = Arrayx<Boxel>.New();
        public static Arrayx<Boxel> GetBoxel(params Arrayx<int>[] ids)
        {
            // BoxelIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] BoxelPlusIds = new Arrayx<int>[ids.Length + 1];
            BoxelPlusIds[0] = BoxelIds;
            Array.Copy(ids, 0, BoxelPlusIds, 1, ids.Length);

            return Gigas.Get<Boxel>(BoxelPlusIds, EntitySet.Boxels, BoxelResult);
        }

        public static Boxel GetBoxel(MonoBehaviour component)
        {
            return GetBoxel(component.gameObject.GetInstanceID());
        }

        public static Boxel GetBoxel(GameObject gameobject)
        {
            return GetBoxel(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> BoxelIdCache = new Dictionary<int, int>();
        public static Boxel GetBoxel(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (BoxelIdCache.TryGetValue(id, out cacheId))
                return Boxels.Elements[cacheId];

            var index = BoxelIds.IndexOf(id);

            if (index < 0)
                return null;

            BoxelIdCache[id] = index; // Cache

            return Boxels.Elements[index];
        }

        // BoxelByClick

        public static Arrayx<int> BoxelByClickIds = Arrayx<int>.New();
        public static Arrayx<BoxelByClick> BoxelByClicks = Arrayx<BoxelByClick>.New();

        public static void AddBoxelByClick(BoxelByClick component)
        {
            BoxelByClickIds.Add(component.gameObject.GetInstanceID());
            BoxelByClicks.Add(component);
        }

        public static void RemoveBoxelByClick(BoxelByClick component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = BoxelByClickIds.IndexOf(id);

            BoxelByClickIds.RemoveAt(index);
            BoxelByClicks.RemoveAt(index);

            BoxelByClickIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<BoxelByClick> BoxelByClickResult = Arrayx<BoxelByClick>.New();
        public static Arrayx<BoxelByClick> GetBoxelByClick(params Arrayx<int>[] ids)
        {
            // BoxelByClickIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] BoxelByClickPlusIds = new Arrayx<int>[ids.Length + 1];
            BoxelByClickPlusIds[0] = BoxelByClickIds;
            Array.Copy(ids, 0, BoxelByClickPlusIds, 1, ids.Length);

            return Gigas.Get<BoxelByClick>(BoxelByClickPlusIds, EntitySet.BoxelByClicks, BoxelByClickResult);
        }

        public static BoxelByClick GetBoxelByClick(MonoBehaviour component)
        {
            return GetBoxelByClick(component.gameObject.GetInstanceID());
        }

        public static BoxelByClick GetBoxelByClick(GameObject gameobject)
        {
            return GetBoxelByClick(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> BoxelByClickIdCache = new Dictionary<int, int>();
        public static BoxelByClick GetBoxelByClick(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (BoxelByClickIdCache.TryGetValue(id, out cacheId))
                return BoxelByClicks.Elements[cacheId];

            var index = BoxelByClickIds.IndexOf(id);

            if (index < 0)
                return null;

            BoxelByClickIdCache[id] = index; // Cache

            return BoxelByClicks.Elements[index];
        }

        // BoxelCache

        public static Arrayx<int> BoxelCacheIds = Arrayx<int>.New();
        public static Arrayx<BoxelCache> BoxelCaches = Arrayx<BoxelCache>.New();

        public static void AddBoxelCache(BoxelCache component)
        {
            BoxelCacheIds.Add(component.gameObject.GetInstanceID());
            BoxelCaches.Add(component);
        }

        public static void RemoveBoxelCache(BoxelCache component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = BoxelCacheIds.IndexOf(id);

            BoxelCacheIds.RemoveAt(index);
            BoxelCaches.RemoveAt(index);

            BoxelCacheIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<BoxelCache> BoxelCacheResult = Arrayx<BoxelCache>.New();
        public static Arrayx<BoxelCache> GetBoxelCache(params Arrayx<int>[] ids)
        {
            // BoxelCacheIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] BoxelCachePlusIds = new Arrayx<int>[ids.Length + 1];
            BoxelCachePlusIds[0] = BoxelCacheIds;
            Array.Copy(ids, 0, BoxelCachePlusIds, 1, ids.Length);

            return Gigas.Get<BoxelCache>(BoxelCachePlusIds, EntitySet.BoxelCaches, BoxelCacheResult);
        }

        public static BoxelCache GetBoxelCache(MonoBehaviour component)
        {
            return GetBoxelCache(component.gameObject.GetInstanceID());
        }

        public static BoxelCache GetBoxelCache(GameObject gameobject)
        {
            return GetBoxelCache(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> BoxelCacheIdCache = new Dictionary<int, int>();
        public static BoxelCache GetBoxelCache(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (BoxelCacheIdCache.TryGetValue(id, out cacheId))
                return BoxelCaches.Elements[cacheId];

            var index = BoxelCacheIds.IndexOf(id);

            if (index < 0)
                return null;

            BoxelCacheIdCache[id] = index; // Cache

            return BoxelCaches.Elements[index];
        }

        // BoxelCreator

        public static Arrayx<int> BoxelCreatorIds = Arrayx<int>.New();
        public static Arrayx<BoxelCreator> BoxelCreators = Arrayx<BoxelCreator>.New();

        public static void AddBoxelCreator(BoxelCreator component)
        {
            BoxelCreatorIds.Add(component.gameObject.GetInstanceID());
            BoxelCreators.Add(component);
        }

        public static void RemoveBoxelCreator(BoxelCreator component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = BoxelCreatorIds.IndexOf(id);

            BoxelCreatorIds.RemoveAt(index);
            BoxelCreators.RemoveAt(index);

            BoxelCreatorIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<BoxelCreator> BoxelCreatorResult = Arrayx<BoxelCreator>.New();
        public static Arrayx<BoxelCreator> GetBoxelCreator(params Arrayx<int>[] ids)
        {
            // BoxelCreatorIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] BoxelCreatorPlusIds = new Arrayx<int>[ids.Length + 1];
            BoxelCreatorPlusIds[0] = BoxelCreatorIds;
            Array.Copy(ids, 0, BoxelCreatorPlusIds, 1, ids.Length);

            return Gigas.Get<BoxelCreator>(BoxelCreatorPlusIds, EntitySet.BoxelCreators, BoxelCreatorResult);
        }

        public static BoxelCreator GetBoxelCreator(MonoBehaviour component)
        {
            return GetBoxelCreator(component.gameObject.GetInstanceID());
        }

        public static BoxelCreator GetBoxelCreator(GameObject gameobject)
        {
            return GetBoxelCreator(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> BoxelCreatorIdCache = new Dictionary<int, int>();
        public static BoxelCreator GetBoxelCreator(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (BoxelCreatorIdCache.TryGetValue(id, out cacheId))
                return BoxelCreators.Elements[cacheId];

            var index = BoxelCreatorIds.IndexOf(id);

            if (index < 0)
                return null;

            BoxelCreatorIdCache[id] = index; // Cache

            return BoxelCreators.Elements[index];
        }

        // BoxelMap

        public static Arrayx<int> BoxelMapIds = Arrayx<int>.New();
        public static Arrayx<BoxelMap> BoxelMaps = Arrayx<BoxelMap>.New();

        public static void AddBoxelMap(BoxelMap component)
        {
            BoxelMapIds.Add(component.gameObject.GetInstanceID());
            BoxelMaps.Add(component);
        }

        public static void RemoveBoxelMap(BoxelMap component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = BoxelMapIds.IndexOf(id);

            BoxelMapIds.RemoveAt(index);
            BoxelMaps.RemoveAt(index);

            BoxelMapIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<BoxelMap> BoxelMapResult = Arrayx<BoxelMap>.New();
        public static Arrayx<BoxelMap> GetBoxelMap(params Arrayx<int>[] ids)
        {
            // BoxelMapIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] BoxelMapPlusIds = new Arrayx<int>[ids.Length + 1];
            BoxelMapPlusIds[0] = BoxelMapIds;
            Array.Copy(ids, 0, BoxelMapPlusIds, 1, ids.Length);

            return Gigas.Get<BoxelMap>(BoxelMapPlusIds, EntitySet.BoxelMaps, BoxelMapResult);
        }

        public static BoxelMap GetBoxelMap(MonoBehaviour component)
        {
            return GetBoxelMap(component.gameObject.GetInstanceID());
        }

        public static BoxelMap GetBoxelMap(GameObject gameobject)
        {
            return GetBoxelMap(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> BoxelMapIdCache = new Dictionary<int, int>();
        public static BoxelMap GetBoxelMap(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (BoxelMapIdCache.TryGetValue(id, out cacheId))
                return BoxelMaps.Elements[cacheId];

            var index = BoxelMapIds.IndexOf(id);

            if (index < 0)
                return null;

            BoxelMapIdCache[id] = index; // Cache

            return BoxelMaps.Elements[index];
        }

        // BoxelMapColorScroll

        public static Arrayx<int> BoxelMapColorScrollIds = Arrayx<int>.New();
        public static Arrayx<BoxelMapColorScroll> BoxelMapColorScrolls = Arrayx<BoxelMapColorScroll>.New();

        public static void AddBoxelMapColorScroll(BoxelMapColorScroll component)
        {
            BoxelMapColorScrollIds.Add(component.gameObject.GetInstanceID());
            BoxelMapColorScrolls.Add(component);
        }

        public static void RemoveBoxelMapColorScroll(BoxelMapColorScroll component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = BoxelMapColorScrollIds.IndexOf(id);

            BoxelMapColorScrollIds.RemoveAt(index);
            BoxelMapColorScrolls.RemoveAt(index);

            BoxelMapColorScrollIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<BoxelMapColorScroll> BoxelMapColorScrollResult = Arrayx<BoxelMapColorScroll>.New();
        public static Arrayx<BoxelMapColorScroll> GetBoxelMapColorScroll(params Arrayx<int>[] ids)
        {
            // BoxelMapColorScrollIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] BoxelMapColorScrollPlusIds = new Arrayx<int>[ids.Length + 1];
            BoxelMapColorScrollPlusIds[0] = BoxelMapColorScrollIds;
            Array.Copy(ids, 0, BoxelMapColorScrollPlusIds, 1, ids.Length);

            return Gigas.Get<BoxelMapColorScroll>(BoxelMapColorScrollPlusIds, EntitySet.BoxelMapColorScrolls, BoxelMapColorScrollResult);
        }

        public static BoxelMapColorScroll GetBoxelMapColorScroll(MonoBehaviour component)
        {
            return GetBoxelMapColorScroll(component.gameObject.GetInstanceID());
        }

        public static BoxelMapColorScroll GetBoxelMapColorScroll(GameObject gameobject)
        {
            return GetBoxelMapColorScroll(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> BoxelMapColorScrollIdCache = new Dictionary<int, int>();
        public static BoxelMapColorScroll GetBoxelMapColorScroll(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (BoxelMapColorScrollIdCache.TryGetValue(id, out cacheId))
                return BoxelMapColorScrolls.Elements[cacheId];

            var index = BoxelMapColorScrollIds.IndexOf(id);

            if (index < 0)
                return null;

            BoxelMapColorScrollIdCache[id] = index; // Cache

            return BoxelMapColorScrolls.Elements[index];
        }

        // BoxelMapPainter

        public static Arrayx<int> BoxelMapPainterIds = Arrayx<int>.New();
        public static Arrayx<BoxelMapPainter> BoxelMapPainters = Arrayx<BoxelMapPainter>.New();

        public static void AddBoxelMapPainter(BoxelMapPainter component)
        {
            BoxelMapPainterIds.Add(component.gameObject.GetInstanceID());
            BoxelMapPainters.Add(component);
        }

        public static void RemoveBoxelMapPainter(BoxelMapPainter component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = BoxelMapPainterIds.IndexOf(id);

            BoxelMapPainterIds.RemoveAt(index);
            BoxelMapPainters.RemoveAt(index);

            BoxelMapPainterIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<BoxelMapPainter> BoxelMapPainterResult = Arrayx<BoxelMapPainter>.New();
        public static Arrayx<BoxelMapPainter> GetBoxelMapPainter(params Arrayx<int>[] ids)
        {
            // BoxelMapPainterIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] BoxelMapPainterPlusIds = new Arrayx<int>[ids.Length + 1];
            BoxelMapPainterPlusIds[0] = BoxelMapPainterIds;
            Array.Copy(ids, 0, BoxelMapPainterPlusIds, 1, ids.Length);

            return Gigas.Get<BoxelMapPainter>(BoxelMapPainterPlusIds, EntitySet.BoxelMapPainters, BoxelMapPainterResult);
        }

        public static BoxelMapPainter GetBoxelMapPainter(MonoBehaviour component)
        {
            return GetBoxelMapPainter(component.gameObject.GetInstanceID());
        }

        public static BoxelMapPainter GetBoxelMapPainter(GameObject gameobject)
        {
            return GetBoxelMapPainter(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> BoxelMapPainterIdCache = new Dictionary<int, int>();
        public static BoxelMapPainter GetBoxelMapPainter(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (BoxelMapPainterIdCache.TryGetValue(id, out cacheId))
                return BoxelMapPainters.Elements[cacheId];

            var index = BoxelMapPainterIds.IndexOf(id);

            if (index < 0)
                return null;

            BoxelMapPainterIdCache[id] = index; // Cache

            return BoxelMapPainters.Elements[index];
        }

        // BoxelMapRegion

        public static Arrayx<int> BoxelMapRegionIds = Arrayx<int>.New();
        public static Arrayx<BoxelMapRegion> BoxelMapRegions = Arrayx<BoxelMapRegion>.New();

        public static void AddBoxelMapRegion(BoxelMapRegion component)
        {
            BoxelMapRegionIds.Add(component.gameObject.GetInstanceID());
            BoxelMapRegions.Add(component);
        }

        public static void RemoveBoxelMapRegion(BoxelMapRegion component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = BoxelMapRegionIds.IndexOf(id);

            BoxelMapRegionIds.RemoveAt(index);
            BoxelMapRegions.RemoveAt(index);

            BoxelMapRegionIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<BoxelMapRegion> BoxelMapRegionResult = Arrayx<BoxelMapRegion>.New();
        public static Arrayx<BoxelMapRegion> GetBoxelMapRegion(params Arrayx<int>[] ids)
        {
            // BoxelMapRegionIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] BoxelMapRegionPlusIds = new Arrayx<int>[ids.Length + 1];
            BoxelMapRegionPlusIds[0] = BoxelMapRegionIds;
            Array.Copy(ids, 0, BoxelMapRegionPlusIds, 1, ids.Length);

            return Gigas.Get<BoxelMapRegion>(BoxelMapRegionPlusIds, EntitySet.BoxelMapRegions, BoxelMapRegionResult);
        }

        public static BoxelMapRegion GetBoxelMapRegion(MonoBehaviour component)
        {
            return GetBoxelMapRegion(component.gameObject.GetInstanceID());
        }

        public static BoxelMapRegion GetBoxelMapRegion(GameObject gameobject)
        {
            return GetBoxelMapRegion(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> BoxelMapRegionIdCache = new Dictionary<int, int>();
        public static BoxelMapRegion GetBoxelMapRegion(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (BoxelMapRegionIdCache.TryGetValue(id, out cacheId))
                return BoxelMapRegions.Elements[cacheId];

            var index = BoxelMapRegionIds.IndexOf(id);

            if (index < 0)
                return null;

            BoxelMapRegionIdCache[id] = index; // Cache

            return BoxelMapRegions.Elements[index];
        }

        // BoxelMapRegionPlayer

        public static Arrayx<int> BoxelMapRegionPlayerIds = Arrayx<int>.New();
        public static Arrayx<BoxelMapRegionPlayer> BoxelMapRegionPlayers = Arrayx<BoxelMapRegionPlayer>.New();

        public static void AddBoxelMapRegionPlayer(BoxelMapRegionPlayer component)
        {
            BoxelMapRegionPlayerIds.Add(component.gameObject.GetInstanceID());
            BoxelMapRegionPlayers.Add(component);
        }

        public static void RemoveBoxelMapRegionPlayer(BoxelMapRegionPlayer component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = BoxelMapRegionPlayerIds.IndexOf(id);

            BoxelMapRegionPlayerIds.RemoveAt(index);
            BoxelMapRegionPlayers.RemoveAt(index);

            BoxelMapRegionPlayerIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<BoxelMapRegionPlayer> BoxelMapRegionPlayerResult = Arrayx<BoxelMapRegionPlayer>.New();
        public static Arrayx<BoxelMapRegionPlayer> GetBoxelMapRegionPlayer(params Arrayx<int>[] ids)
        {
            // BoxelMapRegionPlayerIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] BoxelMapRegionPlayerPlusIds = new Arrayx<int>[ids.Length + 1];
            BoxelMapRegionPlayerPlusIds[0] = BoxelMapRegionPlayerIds;
            Array.Copy(ids, 0, BoxelMapRegionPlayerPlusIds, 1, ids.Length);

            return Gigas.Get<BoxelMapRegionPlayer>(BoxelMapRegionPlayerPlusIds, EntitySet.BoxelMapRegionPlayers, BoxelMapRegionPlayerResult);
        }

        public static BoxelMapRegionPlayer GetBoxelMapRegionPlayer(MonoBehaviour component)
        {
            return GetBoxelMapRegionPlayer(component.gameObject.GetInstanceID());
        }

        public static BoxelMapRegionPlayer GetBoxelMapRegionPlayer(GameObject gameobject)
        {
            return GetBoxelMapRegionPlayer(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> BoxelMapRegionPlayerIdCache = new Dictionary<int, int>();
        public static BoxelMapRegionPlayer GetBoxelMapRegionPlayer(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (BoxelMapRegionPlayerIdCache.TryGetValue(id, out cacheId))
                return BoxelMapRegionPlayers.Elements[cacheId];

            var index = BoxelMapRegionPlayerIds.IndexOf(id);

            if (index < 0)
                return null;

            BoxelMapRegionPlayerIdCache[id] = index; // Cache

            return BoxelMapRegionPlayers.Elements[index];
        }

        // BoxelPopUp

        public static Arrayx<int> BoxelPopUpIds = Arrayx<int>.New();
        public static Arrayx<BoxelPopUp> BoxelPopUps = Arrayx<BoxelPopUp>.New();

        public static void AddBoxelPopUp(BoxelPopUp component)
        {
            BoxelPopUpIds.Add(component.gameObject.GetInstanceID());
            BoxelPopUps.Add(component);
        }

        public static void RemoveBoxelPopUp(BoxelPopUp component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = BoxelPopUpIds.IndexOf(id);

            BoxelPopUpIds.RemoveAt(index);
            BoxelPopUps.RemoveAt(index);

            BoxelPopUpIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<BoxelPopUp> BoxelPopUpResult = Arrayx<BoxelPopUp>.New();
        public static Arrayx<BoxelPopUp> GetBoxelPopUp(params Arrayx<int>[] ids)
        {
            // BoxelPopUpIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] BoxelPopUpPlusIds = new Arrayx<int>[ids.Length + 1];
            BoxelPopUpPlusIds[0] = BoxelPopUpIds;
            Array.Copy(ids, 0, BoxelPopUpPlusIds, 1, ids.Length);

            return Gigas.Get<BoxelPopUp>(BoxelPopUpPlusIds, EntitySet.BoxelPopUps, BoxelPopUpResult);
        }

        public static BoxelPopUp GetBoxelPopUp(MonoBehaviour component)
        {
            return GetBoxelPopUp(component.gameObject.GetInstanceID());
        }

        public static BoxelPopUp GetBoxelPopUp(GameObject gameobject)
        {
            return GetBoxelPopUp(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> BoxelPopUpIdCache = new Dictionary<int, int>();
        public static BoxelPopUp GetBoxelPopUp(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (BoxelPopUpIdCache.TryGetValue(id, out cacheId))
                return BoxelPopUps.Elements[cacheId];

            var index = BoxelPopUpIds.IndexOf(id);

            if (index < 0)
                return null;

            BoxelPopUpIdCache[id] = index; // Cache

            return BoxelPopUps.Elements[index];
        }

        // BulletFactory

        public static Arrayx<int> BulletFactoryIds = Arrayx<int>.New();
        public static Arrayx<BulletFactory> BulletFactorys = Arrayx<BulletFactory>.New();

        public static void AddBulletFactory(BulletFactory component)
        {
            BulletFactoryIds.Add(component.gameObject.GetInstanceID());
            BulletFactorys.Add(component);
        }

        public static void RemoveBulletFactory(BulletFactory component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = BulletFactoryIds.IndexOf(id);

            BulletFactoryIds.RemoveAt(index);
            BulletFactorys.RemoveAt(index);

            BulletFactoryIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<BulletFactory> BulletFactoryResult = Arrayx<BulletFactory>.New();
        public static Arrayx<BulletFactory> GetBulletFactory(params Arrayx<int>[] ids)
        {
            // BulletFactoryIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] BulletFactoryPlusIds = new Arrayx<int>[ids.Length + 1];
            BulletFactoryPlusIds[0] = BulletFactoryIds;
            Array.Copy(ids, 0, BulletFactoryPlusIds, 1, ids.Length);

            return Gigas.Get<BulletFactory>(BulletFactoryPlusIds, EntitySet.BulletFactorys, BulletFactoryResult);
        }

        public static BulletFactory GetBulletFactory(MonoBehaviour component)
        {
            return GetBulletFactory(component.gameObject.GetInstanceID());
        }

        public static BulletFactory GetBulletFactory(GameObject gameobject)
        {
            return GetBulletFactory(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> BulletFactoryIdCache = new Dictionary<int, int>();
        public static BulletFactory GetBulletFactory(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (BulletFactoryIdCache.TryGetValue(id, out cacheId))
                return BulletFactorys.Elements[cacheId];

            var index = BulletFactoryIds.IndexOf(id);

            if (index < 0)
                return null;

            BulletFactoryIdCache[id] = index; // Cache

            return BulletFactorys.Elements[index];
        }

        // BulletGun

        public static Arrayx<int> BulletGunIds = Arrayx<int>.New();
        public static Arrayx<BulletGun> BulletGuns = Arrayx<BulletGun>.New();

        public static void AddBulletGun(BulletGun component)
        {
            BulletGunIds.Add(component.gameObject.GetInstanceID());
            BulletGuns.Add(component);
        }

        public static void RemoveBulletGun(BulletGun component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = BulletGunIds.IndexOf(id);

            BulletGunIds.RemoveAt(index);
            BulletGuns.RemoveAt(index);

            BulletGunIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<BulletGun> BulletGunResult = Arrayx<BulletGun>.New();
        public static Arrayx<BulletGun> GetBulletGun(params Arrayx<int>[] ids)
        {
            // BulletGunIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] BulletGunPlusIds = new Arrayx<int>[ids.Length + 1];
            BulletGunPlusIds[0] = BulletGunIds;
            Array.Copy(ids, 0, BulletGunPlusIds, 1, ids.Length);

            return Gigas.Get<BulletGun>(BulletGunPlusIds, EntitySet.BulletGuns, BulletGunResult);
        }

        public static BulletGun GetBulletGun(MonoBehaviour component)
        {
            return GetBulletGun(component.gameObject.GetInstanceID());
        }

        public static BulletGun GetBulletGun(GameObject gameobject)
        {
            return GetBulletGun(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> BulletGunIdCache = new Dictionary<int, int>();
        public static BulletGun GetBulletGun(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (BulletGunIdCache.TryGetValue(id, out cacheId))
                return BulletGuns.Elements[cacheId];

            var index = BulletGunIds.IndexOf(id);

            if (index < 0)
                return null;

            BulletGunIdCache[id] = index; // Cache

            return BulletGuns.Elements[index];
        }

        // BulletMissile

        public static Arrayx<int> BulletMissileIds = Arrayx<int>.New();
        public static Arrayx<BulletMissile> BulletMissiles = Arrayx<BulletMissile>.New();

        public static void AddBulletMissile(BulletMissile component)
        {
            BulletMissileIds.Add(component.gameObject.GetInstanceID());
            BulletMissiles.Add(component);
        }

        public static void RemoveBulletMissile(BulletMissile component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = BulletMissileIds.IndexOf(id);

            BulletMissileIds.RemoveAt(index);
            BulletMissiles.RemoveAt(index);

            BulletMissileIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<BulletMissile> BulletMissileResult = Arrayx<BulletMissile>.New();
        public static Arrayx<BulletMissile> GetBulletMissile(params Arrayx<int>[] ids)
        {
            // BulletMissileIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] BulletMissilePlusIds = new Arrayx<int>[ids.Length + 1];
            BulletMissilePlusIds[0] = BulletMissileIds;
            Array.Copy(ids, 0, BulletMissilePlusIds, 1, ids.Length);

            return Gigas.Get<BulletMissile>(BulletMissilePlusIds, EntitySet.BulletMissiles, BulletMissileResult);
        }

        public static BulletMissile GetBulletMissile(MonoBehaviour component)
        {
            return GetBulletMissile(component.gameObject.GetInstanceID());
        }

        public static BulletMissile GetBulletMissile(GameObject gameobject)
        {
            return GetBulletMissile(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> BulletMissileIdCache = new Dictionary<int, int>();
        public static BulletMissile GetBulletMissile(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (BulletMissileIdCache.TryGetValue(id, out cacheId))
                return BulletMissiles.Elements[cacheId];

            var index = BulletMissileIds.IndexOf(id);

            if (index < 0)
                return null;

            BulletMissileIdCache[id] = index; // Cache

            return BulletMissiles.Elements[index];
        }

        // Cam

        public static Arrayx<int> CamIds = Arrayx<int>.New();
        public static Arrayx<Cam> Cams = Arrayx<Cam>.New();

        public static void AddCam(Cam component)
        {
            CamIds.Add(component.gameObject.GetInstanceID());
            Cams.Add(component);
        }

        public static void RemoveCam(Cam component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = CamIds.IndexOf(id);

            CamIds.RemoveAt(index);
            Cams.RemoveAt(index);

            CamIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<Cam> CamResult = Arrayx<Cam>.New();
        public static Arrayx<Cam> GetCam(params Arrayx<int>[] ids)
        {
            // CamIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] CamPlusIds = new Arrayx<int>[ids.Length + 1];
            CamPlusIds[0] = CamIds;
            Array.Copy(ids, 0, CamPlusIds, 1, ids.Length);

            return Gigas.Get<Cam>(CamPlusIds, EntitySet.Cams, CamResult);
        }

        public static Cam GetCam(MonoBehaviour component)
        {
            return GetCam(component.gameObject.GetInstanceID());
        }

        public static Cam GetCam(GameObject gameobject)
        {
            return GetCam(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> CamIdCache = new Dictionary<int, int>();
        public static Cam GetCam(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (CamIdCache.TryGetValue(id, out cacheId))
                return Cams.Elements[cacheId];

            var index = CamIds.IndexOf(id);

            if (index < 0)
                return null;

            CamIdCache[id] = index; // Cache

            return Cams.Elements[index];
        }

        // CamAutoZoomTarget

        public static Arrayx<int> CamAutoZoomTargetIds = Arrayx<int>.New();
        public static Arrayx<CamAutoZoomTarget> CamAutoZoomTargets = Arrayx<CamAutoZoomTarget>.New();

        public static void AddCamAutoZoomTarget(CamAutoZoomTarget component)
        {
            CamAutoZoomTargetIds.Add(component.gameObject.GetInstanceID());
            CamAutoZoomTargets.Add(component);
        }

        public static void RemoveCamAutoZoomTarget(CamAutoZoomTarget component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = CamAutoZoomTargetIds.IndexOf(id);

            CamAutoZoomTargetIds.RemoveAt(index);
            CamAutoZoomTargets.RemoveAt(index);

            CamAutoZoomTargetIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<CamAutoZoomTarget> CamAutoZoomTargetResult = Arrayx<CamAutoZoomTarget>.New();
        public static Arrayx<CamAutoZoomTarget> GetCamAutoZoomTarget(params Arrayx<int>[] ids)
        {
            // CamAutoZoomTargetIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] CamAutoZoomTargetPlusIds = new Arrayx<int>[ids.Length + 1];
            CamAutoZoomTargetPlusIds[0] = CamAutoZoomTargetIds;
            Array.Copy(ids, 0, CamAutoZoomTargetPlusIds, 1, ids.Length);

            return Gigas.Get<CamAutoZoomTarget>(CamAutoZoomTargetPlusIds, EntitySet.CamAutoZoomTargets, CamAutoZoomTargetResult);
        }

        public static CamAutoZoomTarget GetCamAutoZoomTarget(MonoBehaviour component)
        {
            return GetCamAutoZoomTarget(component.gameObject.GetInstanceID());
        }

        public static CamAutoZoomTarget GetCamAutoZoomTarget(GameObject gameobject)
        {
            return GetCamAutoZoomTarget(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> CamAutoZoomTargetIdCache = new Dictionary<int, int>();
        public static CamAutoZoomTarget GetCamAutoZoomTarget(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (CamAutoZoomTargetIdCache.TryGetValue(id, out cacheId))
                return CamAutoZoomTargets.Elements[cacheId];

            var index = CamAutoZoomTargetIds.IndexOf(id);

            if (index < 0)
                return null;

            CamAutoZoomTargetIdCache[id] = index; // Cache

            return CamAutoZoomTargets.Elements[index];
        }

        // CamTarget

        public static Arrayx<int> CamTargetIds = Arrayx<int>.New();
        public static Arrayx<CamTarget> CamTargets = Arrayx<CamTarget>.New();

        public static void AddCamTarget(CamTarget component)
        {
            CamTargetIds.Add(component.gameObject.GetInstanceID());
            CamTargets.Add(component);
        }

        public static void RemoveCamTarget(CamTarget component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = CamTargetIds.IndexOf(id);

            CamTargetIds.RemoveAt(index);
            CamTargets.RemoveAt(index);

            CamTargetIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<CamTarget> CamTargetResult = Arrayx<CamTarget>.New();
        public static Arrayx<CamTarget> GetCamTarget(params Arrayx<int>[] ids)
        {
            // CamTargetIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] CamTargetPlusIds = new Arrayx<int>[ids.Length + 1];
            CamTargetPlusIds[0] = CamTargetIds;
            Array.Copy(ids, 0, CamTargetPlusIds, 1, ids.Length);

            return Gigas.Get<CamTarget>(CamTargetPlusIds, EntitySet.CamTargets, CamTargetResult);
        }

        public static CamTarget GetCamTarget(MonoBehaviour component)
        {
            return GetCamTarget(component.gameObject.GetInstanceID());
        }

        public static CamTarget GetCamTarget(GameObject gameobject)
        {
            return GetCamTarget(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> CamTargetIdCache = new Dictionary<int, int>();
        public static CamTarget GetCamTarget(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (CamTargetIdCache.TryGetValue(id, out cacheId))
                return CamTargets.Elements[cacheId];

            var index = CamTargetIds.IndexOf(id);

            if (index < 0)
                return null;

            CamTargetIdCache[id] = index; // Cache

            return CamTargets.Elements[index];
        }

        // CamZoomByScroll

        public static Arrayx<int> CamZoomByScrollIds = Arrayx<int>.New();
        public static Arrayx<CamZoomByScroll> CamZoomByScrolls = Arrayx<CamZoomByScroll>.New();

        public static void AddCamZoomByScroll(CamZoomByScroll component)
        {
            CamZoomByScrollIds.Add(component.gameObject.GetInstanceID());
            CamZoomByScrolls.Add(component);
        }

        public static void RemoveCamZoomByScroll(CamZoomByScroll component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = CamZoomByScrollIds.IndexOf(id);

            CamZoomByScrollIds.RemoveAt(index);
            CamZoomByScrolls.RemoveAt(index);

            CamZoomByScrollIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<CamZoomByScroll> CamZoomByScrollResult = Arrayx<CamZoomByScroll>.New();
        public static Arrayx<CamZoomByScroll> GetCamZoomByScroll(params Arrayx<int>[] ids)
        {
            // CamZoomByScrollIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] CamZoomByScrollPlusIds = new Arrayx<int>[ids.Length + 1];
            CamZoomByScrollPlusIds[0] = CamZoomByScrollIds;
            Array.Copy(ids, 0, CamZoomByScrollPlusIds, 1, ids.Length);

            return Gigas.Get<CamZoomByScroll>(CamZoomByScrollPlusIds, EntitySet.CamZoomByScrolls, CamZoomByScrollResult);
        }

        public static CamZoomByScroll GetCamZoomByScroll(MonoBehaviour component)
        {
            return GetCamZoomByScroll(component.gameObject.GetInstanceID());
        }

        public static CamZoomByScroll GetCamZoomByScroll(GameObject gameobject)
        {
            return GetCamZoomByScroll(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> CamZoomByScrollIdCache = new Dictionary<int, int>();
        public static CamZoomByScroll GetCamZoomByScroll(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (CamZoomByScrollIdCache.TryGetValue(id, out cacheId))
                return CamZoomByScrolls.Elements[cacheId];

            var index = CamZoomByScrollIds.IndexOf(id);

            if (index < 0)
                return null;

            CamZoomByScrollIdCache[id] = index; // Cache

            return CamZoomByScrolls.Elements[index];
        }

        // CharacterMotion

        public static Arrayx<int> CharacterMotionIds = Arrayx<int>.New();
        public static Arrayx<CharacterMotion> CharacterMotions = Arrayx<CharacterMotion>.New();

        public static void AddCharacterMotion(CharacterMotion component)
        {
            CharacterMotionIds.Add(component.gameObject.GetInstanceID());
            CharacterMotions.Add(component);
        }

        public static void RemoveCharacterMotion(CharacterMotion component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = CharacterMotionIds.IndexOf(id);

            CharacterMotionIds.RemoveAt(index);
            CharacterMotions.RemoveAt(index);

            CharacterMotionIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<CharacterMotion> CharacterMotionResult = Arrayx<CharacterMotion>.New();
        public static Arrayx<CharacterMotion> GetCharacterMotion(params Arrayx<int>[] ids)
        {
            // CharacterMotionIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] CharacterMotionPlusIds = new Arrayx<int>[ids.Length + 1];
            CharacterMotionPlusIds[0] = CharacterMotionIds;
            Array.Copy(ids, 0, CharacterMotionPlusIds, 1, ids.Length);

            return Gigas.Get<CharacterMotion>(CharacterMotionPlusIds, EntitySet.CharacterMotions, CharacterMotionResult);
        }

        public static CharacterMotion GetCharacterMotion(MonoBehaviour component)
        {
            return GetCharacterMotion(component.gameObject.GetInstanceID());
        }

        public static CharacterMotion GetCharacterMotion(GameObject gameobject)
        {
            return GetCharacterMotion(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> CharacterMotionIdCache = new Dictionary<int, int>();
        public static CharacterMotion GetCharacterMotion(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (CharacterMotionIdCache.TryGetValue(id, out cacheId))
                return CharacterMotions.Elements[cacheId];

            var index = CharacterMotionIds.IndexOf(id);

            if (index < 0)
                return null;

            CharacterMotionIdCache[id] = index; // Cache

            return CharacterMotions.Elements[index];
        }

        // DamageGiver

        public static Arrayx<int> DamageGiverIds = Arrayx<int>.New();
        public static Arrayx<DamageGiver> DamageGivers = Arrayx<DamageGiver>.New();

        public static void AddDamageGiver(DamageGiver component)
        {
            DamageGiverIds.Add(component.gameObject.GetInstanceID());
            DamageGivers.Add(component);
        }

        public static void RemoveDamageGiver(DamageGiver component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = DamageGiverIds.IndexOf(id);

            DamageGiverIds.RemoveAt(index);
            DamageGivers.RemoveAt(index);

            DamageGiverIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<DamageGiver> DamageGiverResult = Arrayx<DamageGiver>.New();
        public static Arrayx<DamageGiver> GetDamageGiver(params Arrayx<int>[] ids)
        {
            // DamageGiverIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] DamageGiverPlusIds = new Arrayx<int>[ids.Length + 1];
            DamageGiverPlusIds[0] = DamageGiverIds;
            Array.Copy(ids, 0, DamageGiverPlusIds, 1, ids.Length);

            return Gigas.Get<DamageGiver>(DamageGiverPlusIds, EntitySet.DamageGivers, DamageGiverResult);
        }

        public static DamageGiver GetDamageGiver(MonoBehaviour component)
        {
            return GetDamageGiver(component.gameObject.GetInstanceID());
        }

        public static DamageGiver GetDamageGiver(GameObject gameobject)
        {
            return GetDamageGiver(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> DamageGiverIdCache = new Dictionary<int, int>();
        public static DamageGiver GetDamageGiver(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (DamageGiverIdCache.TryGetValue(id, out cacheId))
                return DamageGivers.Elements[cacheId];

            var index = DamageGiverIds.IndexOf(id);

            if (index < 0)
                return null;

            DamageGiverIdCache[id] = index; // Cache

            return DamageGivers.Elements[index];
        }

        // DamageReceiver

        public static Arrayx<int> DamageReceiverIds = Arrayx<int>.New();
        public static Arrayx<DamageReceiver> DamageReceivers = Arrayx<DamageReceiver>.New();

        public static void AddDamageReceiver(DamageReceiver component)
        {
            DamageReceiverIds.Add(component.gameObject.GetInstanceID());
            DamageReceivers.Add(component);
        }

        public static void RemoveDamageReceiver(DamageReceiver component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = DamageReceiverIds.IndexOf(id);

            DamageReceiverIds.RemoveAt(index);
            DamageReceivers.RemoveAt(index);

            DamageReceiverIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<DamageReceiver> DamageReceiverResult = Arrayx<DamageReceiver>.New();
        public static Arrayx<DamageReceiver> GetDamageReceiver(params Arrayx<int>[] ids)
        {
            // DamageReceiverIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] DamageReceiverPlusIds = new Arrayx<int>[ids.Length + 1];
            DamageReceiverPlusIds[0] = DamageReceiverIds;
            Array.Copy(ids, 0, DamageReceiverPlusIds, 1, ids.Length);

            return Gigas.Get<DamageReceiver>(DamageReceiverPlusIds, EntitySet.DamageReceivers, DamageReceiverResult);
        }

        public static DamageReceiver GetDamageReceiver(MonoBehaviour component)
        {
            return GetDamageReceiver(component.gameObject.GetInstanceID());
        }

        public static DamageReceiver GetDamageReceiver(GameObject gameobject)
        {
            return GetDamageReceiver(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> DamageReceiverIdCache = new Dictionary<int, int>();
        public static DamageReceiver GetDamageReceiver(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (DamageReceiverIdCache.TryGetValue(id, out cacheId))
                return DamageReceivers.Elements[cacheId];

            var index = DamageReceiverIds.IndexOf(id);

            if (index < 0)
                return null;

            DamageReceiverIdCache[id] = index; // Cache

            return DamageReceivers.Elements[index];
        }

        // Dash

        public static Arrayx<int> DashIds = Arrayx<int>.New();
        public static Arrayx<Dash> Dashs = Arrayx<Dash>.New();

        public static void AddDash(Dash component)
        {
            DashIds.Add(component.gameObject.GetInstanceID());
            Dashs.Add(component);
        }

        public static void RemoveDash(Dash component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = DashIds.IndexOf(id);

            DashIds.RemoveAt(index);
            Dashs.RemoveAt(index);

            DashIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<Dash> DashResult = Arrayx<Dash>.New();
        public static Arrayx<Dash> GetDash(params Arrayx<int>[] ids)
        {
            // DashIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] DashPlusIds = new Arrayx<int>[ids.Length + 1];
            DashPlusIds[0] = DashIds;
            Array.Copy(ids, 0, DashPlusIds, 1, ids.Length);

            return Gigas.Get<Dash>(DashPlusIds, EntitySet.Dashs, DashResult);
        }

        public static Dash GetDash(MonoBehaviour component)
        {
            return GetDash(component.gameObject.GetInstanceID());
        }

        public static Dash GetDash(GameObject gameobject)
        {
            return GetDash(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> DashIdCache = new Dictionary<int, int>();
        public static Dash GetDash(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (DashIdCache.TryGetValue(id, out cacheId))
                return Dashs.Elements[cacheId];

            var index = DashIds.IndexOf(id);

            if (index < 0)
                return null;

            DashIdCache[id] = index; // Cache

            return Dashs.Elements[index];
        }

        // DashToPlayerAction

        public static Arrayx<int> DashToPlayerActionIds = Arrayx<int>.New();
        public static Arrayx<DashToPlayerAction> DashToPlayerActions = Arrayx<DashToPlayerAction>.New();

        public static void AddDashToPlayerAction(DashToPlayerAction component)
        {
            DashToPlayerActionIds.Add(component.gameObject.GetInstanceID());
            DashToPlayerActions.Add(component);
        }

        public static void RemoveDashToPlayerAction(DashToPlayerAction component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = DashToPlayerActionIds.IndexOf(id);

            DashToPlayerActionIds.RemoveAt(index);
            DashToPlayerActions.RemoveAt(index);

            DashToPlayerActionIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<DashToPlayerAction> DashToPlayerActionResult = Arrayx<DashToPlayerAction>.New();
        public static Arrayx<DashToPlayerAction> GetDashToPlayerAction(params Arrayx<int>[] ids)
        {
            // DashToPlayerActionIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] DashToPlayerActionPlusIds = new Arrayx<int>[ids.Length + 1];
            DashToPlayerActionPlusIds[0] = DashToPlayerActionIds;
            Array.Copy(ids, 0, DashToPlayerActionPlusIds, 1, ids.Length);

            return Gigas.Get<DashToPlayerAction>(DashToPlayerActionPlusIds, EntitySet.DashToPlayerActions, DashToPlayerActionResult);
        }

        public static DashToPlayerAction GetDashToPlayerAction(MonoBehaviour component)
        {
            return GetDashToPlayerAction(component.gameObject.GetInstanceID());
        }

        public static DashToPlayerAction GetDashToPlayerAction(GameObject gameobject)
        {
            return GetDashToPlayerAction(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> DashToPlayerActionIdCache = new Dictionary<int, int>();
        public static DashToPlayerAction GetDashToPlayerAction(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (DashToPlayerActionIdCache.TryGetValue(id, out cacheId))
                return DashToPlayerActions.Elements[cacheId];

            var index = DashToPlayerActionIds.IndexOf(id);

            if (index < 0)
                return null;

            DashToPlayerActionIdCache[id] = index; // Cache

            return DashToPlayerActions.Elements[index];
        }

        // FlyByInput

        public static Arrayx<int> FlyByInputIds = Arrayx<int>.New();
        public static Arrayx<FlyByInput> FlyByInputs = Arrayx<FlyByInput>.New();

        public static void AddFlyByInput(FlyByInput component)
        {
            FlyByInputIds.Add(component.gameObject.GetInstanceID());
            FlyByInputs.Add(component);
        }

        public static void RemoveFlyByInput(FlyByInput component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = FlyByInputIds.IndexOf(id);

            FlyByInputIds.RemoveAt(index);
            FlyByInputs.RemoveAt(index);

            FlyByInputIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<FlyByInput> FlyByInputResult = Arrayx<FlyByInput>.New();
        public static Arrayx<FlyByInput> GetFlyByInput(params Arrayx<int>[] ids)
        {
            // FlyByInputIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] FlyByInputPlusIds = new Arrayx<int>[ids.Length + 1];
            FlyByInputPlusIds[0] = FlyByInputIds;
            Array.Copy(ids, 0, FlyByInputPlusIds, 1, ids.Length);

            return Gigas.Get<FlyByInput>(FlyByInputPlusIds, EntitySet.FlyByInputs, FlyByInputResult);
        }

        public static FlyByInput GetFlyByInput(MonoBehaviour component)
        {
            return GetFlyByInput(component.gameObject.GetInstanceID());
        }

        public static FlyByInput GetFlyByInput(GameObject gameobject)
        {
            return GetFlyByInput(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> FlyByInputIdCache = new Dictionary<int, int>();
        public static FlyByInput GetFlyByInput(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (FlyByInputIdCache.TryGetValue(id, out cacheId))
                return FlyByInputs.Elements[cacheId];

            var index = FlyByInputIds.IndexOf(id);

            if (index < 0)
                return null;

            FlyByInputIdCache[id] = index; // Cache

            return FlyByInputs.Elements[index];
        }

        // FlyMotion

        public static Arrayx<int> FlyMotionIds = Arrayx<int>.New();
        public static Arrayx<FlyMotion> FlyMotions = Arrayx<FlyMotion>.New();

        public static void AddFlyMotion(FlyMotion component)
        {
            FlyMotionIds.Add(component.gameObject.GetInstanceID());
            FlyMotions.Add(component);
        }

        public static void RemoveFlyMotion(FlyMotion component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = FlyMotionIds.IndexOf(id);

            FlyMotionIds.RemoveAt(index);
            FlyMotions.RemoveAt(index);

            FlyMotionIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<FlyMotion> FlyMotionResult = Arrayx<FlyMotion>.New();
        public static Arrayx<FlyMotion> GetFlyMotion(params Arrayx<int>[] ids)
        {
            // FlyMotionIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] FlyMotionPlusIds = new Arrayx<int>[ids.Length + 1];
            FlyMotionPlusIds[0] = FlyMotionIds;
            Array.Copy(ids, 0, FlyMotionPlusIds, 1, ids.Length);

            return Gigas.Get<FlyMotion>(FlyMotionPlusIds, EntitySet.FlyMotions, FlyMotionResult);
        }

        public static FlyMotion GetFlyMotion(MonoBehaviour component)
        {
            return GetFlyMotion(component.gameObject.GetInstanceID());
        }

        public static FlyMotion GetFlyMotion(GameObject gameobject)
        {
            return GetFlyMotion(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> FlyMotionIdCache = new Dictionary<int, int>();
        public static FlyMotion GetFlyMotion(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (FlyMotionIdCache.TryGetValue(id, out cacheId))
                return FlyMotions.Elements[cacheId];

            var index = FlyMotionIds.IndexOf(id);

            if (index < 0)
                return null;

            FlyMotionIdCache[id] = index; // Cache

            return FlyMotions.Elements[index];
        }

        // FlyTowardsPlayerAction

        public static Arrayx<int> FlyTowardsPlayerActionIds = Arrayx<int>.New();
        public static Arrayx<FlyTowardsPlayerAction> FlyTowardsPlayerActions = Arrayx<FlyTowardsPlayerAction>.New();

        public static void AddFlyTowardsPlayerAction(FlyTowardsPlayerAction component)
        {
            FlyTowardsPlayerActionIds.Add(component.gameObject.GetInstanceID());
            FlyTowardsPlayerActions.Add(component);
        }

        public static void RemoveFlyTowardsPlayerAction(FlyTowardsPlayerAction component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = FlyTowardsPlayerActionIds.IndexOf(id);

            FlyTowardsPlayerActionIds.RemoveAt(index);
            FlyTowardsPlayerActions.RemoveAt(index);

            FlyTowardsPlayerActionIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<FlyTowardsPlayerAction> FlyTowardsPlayerActionResult = Arrayx<FlyTowardsPlayerAction>.New();
        public static Arrayx<FlyTowardsPlayerAction> GetFlyTowardsPlayerAction(params Arrayx<int>[] ids)
        {
            // FlyTowardsPlayerActionIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] FlyTowardsPlayerActionPlusIds = new Arrayx<int>[ids.Length + 1];
            FlyTowardsPlayerActionPlusIds[0] = FlyTowardsPlayerActionIds;
            Array.Copy(ids, 0, FlyTowardsPlayerActionPlusIds, 1, ids.Length);

            return Gigas.Get<FlyTowardsPlayerAction>(FlyTowardsPlayerActionPlusIds, EntitySet.FlyTowardsPlayerActions, FlyTowardsPlayerActionResult);
        }

        public static FlyTowardsPlayerAction GetFlyTowardsPlayerAction(MonoBehaviour component)
        {
            return GetFlyTowardsPlayerAction(component.gameObject.GetInstanceID());
        }

        public static FlyTowardsPlayerAction GetFlyTowardsPlayerAction(GameObject gameobject)
        {
            return GetFlyTowardsPlayerAction(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> FlyTowardsPlayerActionIdCache = new Dictionary<int, int>();
        public static FlyTowardsPlayerAction GetFlyTowardsPlayerAction(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (FlyTowardsPlayerActionIdCache.TryGetValue(id, out cacheId))
                return FlyTowardsPlayerActions.Elements[cacheId];

            var index = FlyTowardsPlayerActionIds.IndexOf(id);

            if (index < 0)
                return null;

            FlyTowardsPlayerActionIdCache[id] = index; // Cache

            return FlyTowardsPlayerActions.Elements[index];
        }

        // FollowPlayer

        public static Arrayx<int> FollowPlayerIds = Arrayx<int>.New();
        public static Arrayx<FollowPlayer> FollowPlayers = Arrayx<FollowPlayer>.New();

        public static void AddFollowPlayer(FollowPlayer component)
        {
            FollowPlayerIds.Add(component.gameObject.GetInstanceID());
            FollowPlayers.Add(component);
        }

        public static void RemoveFollowPlayer(FollowPlayer component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = FollowPlayerIds.IndexOf(id);

            FollowPlayerIds.RemoveAt(index);
            FollowPlayers.RemoveAt(index);

            FollowPlayerIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<FollowPlayer> FollowPlayerResult = Arrayx<FollowPlayer>.New();
        public static Arrayx<FollowPlayer> GetFollowPlayer(params Arrayx<int>[] ids)
        {
            // FollowPlayerIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] FollowPlayerPlusIds = new Arrayx<int>[ids.Length + 1];
            FollowPlayerPlusIds[0] = FollowPlayerIds;
            Array.Copy(ids, 0, FollowPlayerPlusIds, 1, ids.Length);

            return Gigas.Get<FollowPlayer>(FollowPlayerPlusIds, EntitySet.FollowPlayers, FollowPlayerResult);
        }

        public static FollowPlayer GetFollowPlayer(MonoBehaviour component)
        {
            return GetFollowPlayer(component.gameObject.GetInstanceID());
        }

        public static FollowPlayer GetFollowPlayer(GameObject gameobject)
        {
            return GetFollowPlayer(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> FollowPlayerIdCache = new Dictionary<int, int>();
        public static FollowPlayer GetFollowPlayer(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (FollowPlayerIdCache.TryGetValue(id, out cacheId))
                return FollowPlayers.Elements[cacheId];

            var index = FollowPlayerIds.IndexOf(id);

            if (index < 0)
                return null;

            FollowPlayerIdCache[id] = index; // Cache

            return FollowPlayers.Elements[index];
        }

        // FreezeFrameOnKnockback

        public static Arrayx<int> FreezeFrameOnKnockbackIds = Arrayx<int>.New();
        public static Arrayx<FreezeFrameOnKnockback> FreezeFrameOnKnockbacks = Arrayx<FreezeFrameOnKnockback>.New();

        public static void AddFreezeFrameOnKnockback(FreezeFrameOnKnockback component)
        {
            FreezeFrameOnKnockbackIds.Add(component.gameObject.GetInstanceID());
            FreezeFrameOnKnockbacks.Add(component);
        }

        public static void RemoveFreezeFrameOnKnockback(FreezeFrameOnKnockback component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = FreezeFrameOnKnockbackIds.IndexOf(id);

            FreezeFrameOnKnockbackIds.RemoveAt(index);
            FreezeFrameOnKnockbacks.RemoveAt(index);

            FreezeFrameOnKnockbackIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<FreezeFrameOnKnockback> FreezeFrameOnKnockbackResult = Arrayx<FreezeFrameOnKnockback>.New();
        public static Arrayx<FreezeFrameOnKnockback> GetFreezeFrameOnKnockback(params Arrayx<int>[] ids)
        {
            // FreezeFrameOnKnockbackIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] FreezeFrameOnKnockbackPlusIds = new Arrayx<int>[ids.Length + 1];
            FreezeFrameOnKnockbackPlusIds[0] = FreezeFrameOnKnockbackIds;
            Array.Copy(ids, 0, FreezeFrameOnKnockbackPlusIds, 1, ids.Length);

            return Gigas.Get<FreezeFrameOnKnockback>(FreezeFrameOnKnockbackPlusIds, EntitySet.FreezeFrameOnKnockbacks, FreezeFrameOnKnockbackResult);
        }

        public static FreezeFrameOnKnockback GetFreezeFrameOnKnockback(MonoBehaviour component)
        {
            return GetFreezeFrameOnKnockback(component.gameObject.GetInstanceID());
        }

        public static FreezeFrameOnKnockback GetFreezeFrameOnKnockback(GameObject gameobject)
        {
            return GetFreezeFrameOnKnockback(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> FreezeFrameOnKnockbackIdCache = new Dictionary<int, int>();
        public static FreezeFrameOnKnockback GetFreezeFrameOnKnockback(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (FreezeFrameOnKnockbackIdCache.TryGetValue(id, out cacheId))
                return FreezeFrameOnKnockbacks.Elements[cacheId];

            var index = FreezeFrameOnKnockbackIds.IndexOf(id);

            if (index < 0)
                return null;

            FreezeFrameOnKnockbackIdCache[id] = index; // Cache

            return FreezeFrameOnKnockbacks.Elements[index];
        }

        // GroundDetection

        public static Arrayx<int> GroundDetectionIds = Arrayx<int>.New();
        public static Arrayx<GroundDetection> GroundDetections = Arrayx<GroundDetection>.New();

        public static void AddGroundDetection(GroundDetection component)
        {
            GroundDetectionIds.Add(component.gameObject.GetInstanceID());
            GroundDetections.Add(component);
        }

        public static void RemoveGroundDetection(GroundDetection component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = GroundDetectionIds.IndexOf(id);

            GroundDetectionIds.RemoveAt(index);
            GroundDetections.RemoveAt(index);

            GroundDetectionIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<GroundDetection> GroundDetectionResult = Arrayx<GroundDetection>.New();
        public static Arrayx<GroundDetection> GetGroundDetection(params Arrayx<int>[] ids)
        {
            // GroundDetectionIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] GroundDetectionPlusIds = new Arrayx<int>[ids.Length + 1];
            GroundDetectionPlusIds[0] = GroundDetectionIds;
            Array.Copy(ids, 0, GroundDetectionPlusIds, 1, ids.Length);

            return Gigas.Get<GroundDetection>(GroundDetectionPlusIds, EntitySet.GroundDetections, GroundDetectionResult);
        }

        public static GroundDetection GetGroundDetection(MonoBehaviour component)
        {
            return GetGroundDetection(component.gameObject.GetInstanceID());
        }

        public static GroundDetection GetGroundDetection(GameObject gameobject)
        {
            return GetGroundDetection(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> GroundDetectionIdCache = new Dictionary<int, int>();
        public static GroundDetection GetGroundDetection(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (GroundDetectionIdCache.TryGetValue(id, out cacheId))
                return GroundDetections.Elements[cacheId];

            var index = GroundDetectionIds.IndexOf(id);

            if (index < 0)
                return null;

            GroundDetectionIdCache[id] = index; // Cache

            return GroundDetections.Elements[index];
        }

        // IdBite

        public static Arrayx<int> IdBiteIds = Arrayx<int>.New();
        public static Arrayx<IdBite> IdBites = Arrayx<IdBite>.New();

        public static void AddIdBite(IdBite component)
        {
            IdBiteIds.Add(component.gameObject.GetInstanceID());
            IdBites.Add(component);
        }

        public static void RemoveIdBite(IdBite component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = IdBiteIds.IndexOf(id);

            IdBiteIds.RemoveAt(index);
            IdBites.RemoveAt(index);

            IdBiteIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<IdBite> IdBiteResult = Arrayx<IdBite>.New();
        public static Arrayx<IdBite> GetIdBite(params Arrayx<int>[] ids)
        {
            // IdBiteIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] IdBitePlusIds = new Arrayx<int>[ids.Length + 1];
            IdBitePlusIds[0] = IdBiteIds;
            Array.Copy(ids, 0, IdBitePlusIds, 1, ids.Length);

            return Gigas.Get<IdBite>(IdBitePlusIds, EntitySet.IdBites, IdBiteResult);
        }

        public static IdBite GetIdBite(MonoBehaviour component)
        {
            return GetIdBite(component.gameObject.GetInstanceID());
        }

        public static IdBite GetIdBite(GameObject gameobject)
        {
            return GetIdBite(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> IdBiteIdCache = new Dictionary<int, int>();
        public static IdBite GetIdBite(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (IdBiteIdCache.TryGetValue(id, out cacheId))
                return IdBites.Elements[cacheId];

            var index = IdBiteIds.IndexOf(id);

            if (index < 0)
                return null;

            IdBiteIdCache[id] = index; // Cache

            return IdBites.Elements[index];
        }

        // JumpByInput

        public static Arrayx<int> JumpByInputIds = Arrayx<int>.New();
        public static Arrayx<JumpByInput> JumpByInputs = Arrayx<JumpByInput>.New();

        public static void AddJumpByInput(JumpByInput component)
        {
            JumpByInputIds.Add(component.gameObject.GetInstanceID());
            JumpByInputs.Add(component);
        }

        public static void RemoveJumpByInput(JumpByInput component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = JumpByInputIds.IndexOf(id);

            JumpByInputIds.RemoveAt(index);
            JumpByInputs.RemoveAt(index);

            JumpByInputIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<JumpByInput> JumpByInputResult = Arrayx<JumpByInput>.New();
        public static Arrayx<JumpByInput> GetJumpByInput(params Arrayx<int>[] ids)
        {
            // JumpByInputIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] JumpByInputPlusIds = new Arrayx<int>[ids.Length + 1];
            JumpByInputPlusIds[0] = JumpByInputIds;
            Array.Copy(ids, 0, JumpByInputPlusIds, 1, ids.Length);

            return Gigas.Get<JumpByInput>(JumpByInputPlusIds, EntitySet.JumpByInputs, JumpByInputResult);
        }

        public static JumpByInput GetJumpByInput(MonoBehaviour component)
        {
            return GetJumpByInput(component.gameObject.GetInstanceID());
        }

        public static JumpByInput GetJumpByInput(GameObject gameobject)
        {
            return GetJumpByInput(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> JumpByInputIdCache = new Dictionary<int, int>();
        public static JumpByInput GetJumpByInput(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (JumpByInputIdCache.TryGetValue(id, out cacheId))
                return JumpByInputs.Elements[cacheId];

            var index = JumpByInputIds.IndexOf(id);

            if (index < 0)
                return null;

            JumpByInputIdCache[id] = index; // Cache

            return JumpByInputs.Elements[index];
        }

        // JumpCountLimit

        public static Arrayx<int> JumpCountLimitIds = Arrayx<int>.New();
        public static Arrayx<JumpCountLimit> JumpCountLimits = Arrayx<JumpCountLimit>.New();

        public static void AddJumpCountLimit(JumpCountLimit component)
        {
            JumpCountLimitIds.Add(component.gameObject.GetInstanceID());
            JumpCountLimits.Add(component);
        }

        public static void RemoveJumpCountLimit(JumpCountLimit component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = JumpCountLimitIds.IndexOf(id);

            JumpCountLimitIds.RemoveAt(index);
            JumpCountLimits.RemoveAt(index);

            JumpCountLimitIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<JumpCountLimit> JumpCountLimitResult = Arrayx<JumpCountLimit>.New();
        public static Arrayx<JumpCountLimit> GetJumpCountLimit(params Arrayx<int>[] ids)
        {
            // JumpCountLimitIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] JumpCountLimitPlusIds = new Arrayx<int>[ids.Length + 1];
            JumpCountLimitPlusIds[0] = JumpCountLimitIds;
            Array.Copy(ids, 0, JumpCountLimitPlusIds, 1, ids.Length);

            return Gigas.Get<JumpCountLimit>(JumpCountLimitPlusIds, EntitySet.JumpCountLimits, JumpCountLimitResult);
        }

        public static JumpCountLimit GetJumpCountLimit(MonoBehaviour component)
        {
            return GetJumpCountLimit(component.gameObject.GetInstanceID());
        }

        public static JumpCountLimit GetJumpCountLimit(GameObject gameobject)
        {
            return GetJumpCountLimit(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> JumpCountLimitIdCache = new Dictionary<int, int>();
        public static JumpCountLimit GetJumpCountLimit(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (JumpCountLimitIdCache.TryGetValue(id, out cacheId))
                return JumpCountLimits.Elements[cacheId];

            var index = JumpCountLimitIds.IndexOf(id);

            if (index < 0)
                return null;

            JumpCountLimitIdCache[id] = index; // Cache

            return JumpCountLimits.Elements[index];
        }

        // JumpRules

        public static Arrayx<int> JumpRulesIds = Arrayx<int>.New();
        public static Arrayx<JumpRules> JumpRuless = Arrayx<JumpRules>.New();

        public static void AddJumpRules(JumpRules component)
        {
            JumpRulesIds.Add(component.gameObject.GetInstanceID());
            JumpRuless.Add(component);
        }

        public static void RemoveJumpRules(JumpRules component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = JumpRulesIds.IndexOf(id);

            JumpRulesIds.RemoveAt(index);
            JumpRuless.RemoveAt(index);

            JumpRulesIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<JumpRules> JumpRulesResult = Arrayx<JumpRules>.New();
        public static Arrayx<JumpRules> GetJumpRules(params Arrayx<int>[] ids)
        {
            // JumpRulesIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] JumpRulesPlusIds = new Arrayx<int>[ids.Length + 1];
            JumpRulesPlusIds[0] = JumpRulesIds;
            Array.Copy(ids, 0, JumpRulesPlusIds, 1, ids.Length);

            return Gigas.Get<JumpRules>(JumpRulesPlusIds, EntitySet.JumpRuless, JumpRulesResult);
        }

        public static JumpRules GetJumpRules(MonoBehaviour component)
        {
            return GetJumpRules(component.gameObject.GetInstanceID());
        }

        public static JumpRules GetJumpRules(GameObject gameobject)
        {
            return GetJumpRules(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> JumpRulesIdCache = new Dictionary<int, int>();
        public static JumpRules GetJumpRules(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (JumpRulesIdCache.TryGetValue(id, out cacheId))
                return JumpRuless.Elements[cacheId];

            var index = JumpRulesIds.IndexOf(id);

            if (index < 0)
                return null;

            JumpRulesIdCache[id] = index; // Cache

            return JumpRuless.Elements[index];
        }

        // MotionByInput

        public static Arrayx<int> MotionByInputIds = Arrayx<int>.New();
        public static Arrayx<MotionByInput> MotionByInputs = Arrayx<MotionByInput>.New();

        public static void AddMotionByInput(MotionByInput component)
        {
            MotionByInputIds.Add(component.gameObject.GetInstanceID());
            MotionByInputs.Add(component);
        }

        public static void RemoveMotionByInput(MotionByInput component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = MotionByInputIds.IndexOf(id);

            MotionByInputIds.RemoveAt(index);
            MotionByInputs.RemoveAt(index);

            MotionByInputIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<MotionByInput> MotionByInputResult = Arrayx<MotionByInput>.New();
        public static Arrayx<MotionByInput> GetMotionByInput(params Arrayx<int>[] ids)
        {
            // MotionByInputIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] MotionByInputPlusIds = new Arrayx<int>[ids.Length + 1];
            MotionByInputPlusIds[0] = MotionByInputIds;
            Array.Copy(ids, 0, MotionByInputPlusIds, 1, ids.Length);

            return Gigas.Get<MotionByInput>(MotionByInputPlusIds, EntitySet.MotionByInputs, MotionByInputResult);
        }

        public static MotionByInput GetMotionByInput(MonoBehaviour component)
        {
            return GetMotionByInput(component.gameObject.GetInstanceID());
        }

        public static MotionByInput GetMotionByInput(GameObject gameobject)
        {
            return GetMotionByInput(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> MotionByInputIdCache = new Dictionary<int, int>();
        public static MotionByInput GetMotionByInput(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (MotionByInputIdCache.TryGetValue(id, out cacheId))
                return MotionByInputs.Elements[cacheId];

            var index = MotionByInputIds.IndexOf(id);

            if (index < 0)
                return null;

            MotionByInputIdCache[id] = index; // Cache

            return MotionByInputs.Elements[index];
        }

        // MotionKnockback

        public static Arrayx<int> MotionKnockbackIds = Arrayx<int>.New();
        public static Arrayx<MotionKnockback> MotionKnockbacks = Arrayx<MotionKnockback>.New();

        public static void AddMotionKnockback(MotionKnockback component)
        {
            MotionKnockbackIds.Add(component.gameObject.GetInstanceID());
            MotionKnockbacks.Add(component);
        }

        public static void RemoveMotionKnockback(MotionKnockback component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = MotionKnockbackIds.IndexOf(id);

            MotionKnockbackIds.RemoveAt(index);
            MotionKnockbacks.RemoveAt(index);

            MotionKnockbackIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<MotionKnockback> MotionKnockbackResult = Arrayx<MotionKnockback>.New();
        public static Arrayx<MotionKnockback> GetMotionKnockback(params Arrayx<int>[] ids)
        {
            // MotionKnockbackIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] MotionKnockbackPlusIds = new Arrayx<int>[ids.Length + 1];
            MotionKnockbackPlusIds[0] = MotionKnockbackIds;
            Array.Copy(ids, 0, MotionKnockbackPlusIds, 1, ids.Length);

            return Gigas.Get<MotionKnockback>(MotionKnockbackPlusIds, EntitySet.MotionKnockbacks, MotionKnockbackResult);
        }

        public static MotionKnockback GetMotionKnockback(MonoBehaviour component)
        {
            return GetMotionKnockback(component.gameObject.GetInstanceID());
        }

        public static MotionKnockback GetMotionKnockback(GameObject gameobject)
        {
            return GetMotionKnockback(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> MotionKnockbackIdCache = new Dictionary<int, int>();
        public static MotionKnockback GetMotionKnockback(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (MotionKnockbackIdCache.TryGetValue(id, out cacheId))
                return MotionKnockbacks.Elements[cacheId];

            var index = MotionKnockbackIds.IndexOf(id);

            if (index < 0)
                return null;

            MotionKnockbackIdCache[id] = index; // Cache

            return MotionKnockbacks.Elements[index];
        }

        // MotionKnockbackGiver

        public static Arrayx<int> MotionKnockbackGiverIds = Arrayx<int>.New();
        public static Arrayx<MotionKnockbackGiver> MotionKnockbackGivers = Arrayx<MotionKnockbackGiver>.New();

        public static void AddMotionKnockbackGiver(MotionKnockbackGiver component)
        {
            MotionKnockbackGiverIds.Add(component.gameObject.GetInstanceID());
            MotionKnockbackGivers.Add(component);
        }

        public static void RemoveMotionKnockbackGiver(MotionKnockbackGiver component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = MotionKnockbackGiverIds.IndexOf(id);

            MotionKnockbackGiverIds.RemoveAt(index);
            MotionKnockbackGivers.RemoveAt(index);

            MotionKnockbackGiverIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<MotionKnockbackGiver> MotionKnockbackGiverResult = Arrayx<MotionKnockbackGiver>.New();
        public static Arrayx<MotionKnockbackGiver> GetMotionKnockbackGiver(params Arrayx<int>[] ids)
        {
            // MotionKnockbackGiverIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] MotionKnockbackGiverPlusIds = new Arrayx<int>[ids.Length + 1];
            MotionKnockbackGiverPlusIds[0] = MotionKnockbackGiverIds;
            Array.Copy(ids, 0, MotionKnockbackGiverPlusIds, 1, ids.Length);

            return Gigas.Get<MotionKnockbackGiver>(MotionKnockbackGiverPlusIds, EntitySet.MotionKnockbackGivers, MotionKnockbackGiverResult);
        }

        public static MotionKnockbackGiver GetMotionKnockbackGiver(MonoBehaviour component)
        {
            return GetMotionKnockbackGiver(component.gameObject.GetInstanceID());
        }

        public static MotionKnockbackGiver GetMotionKnockbackGiver(GameObject gameobject)
        {
            return GetMotionKnockbackGiver(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> MotionKnockbackGiverIdCache = new Dictionary<int, int>();
        public static MotionKnockbackGiver GetMotionKnockbackGiver(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (MotionKnockbackGiverIdCache.TryGetValue(id, out cacheId))
                return MotionKnockbackGivers.Elements[cacheId];

            var index = MotionKnockbackGiverIds.IndexOf(id);

            if (index < 0)
                return null;

            MotionKnockbackGiverIdCache[id] = index; // Cache

            return MotionKnockbackGivers.Elements[index];
        }

        // MouseCursor

        public static Arrayx<int> MouseCursorIds = Arrayx<int>.New();
        public static Arrayx<MouseCursor> MouseCursors = Arrayx<MouseCursor>.New();

        public static void AddMouseCursor(MouseCursor component)
        {
            MouseCursorIds.Add(component.gameObject.GetInstanceID());
            MouseCursors.Add(component);
        }

        public static void RemoveMouseCursor(MouseCursor component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = MouseCursorIds.IndexOf(id);

            MouseCursorIds.RemoveAt(index);
            MouseCursors.RemoveAt(index);

            MouseCursorIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<MouseCursor> MouseCursorResult = Arrayx<MouseCursor>.New();
        public static Arrayx<MouseCursor> GetMouseCursor(params Arrayx<int>[] ids)
        {
            // MouseCursorIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] MouseCursorPlusIds = new Arrayx<int>[ids.Length + 1];
            MouseCursorPlusIds[0] = MouseCursorIds;
            Array.Copy(ids, 0, MouseCursorPlusIds, 1, ids.Length);

            return Gigas.Get<MouseCursor>(MouseCursorPlusIds, EntitySet.MouseCursors, MouseCursorResult);
        }

        public static MouseCursor GetMouseCursor(MonoBehaviour component)
        {
            return GetMouseCursor(component.gameObject.GetInstanceID());
        }

        public static MouseCursor GetMouseCursor(GameObject gameobject)
        {
            return GetMouseCursor(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> MouseCursorIdCache = new Dictionary<int, int>();
        public static MouseCursor GetMouseCursor(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (MouseCursorIdCache.TryGetValue(id, out cacheId))
                return MouseCursors.Elements[cacheId];

            var index = MouseCursorIds.IndexOf(id);

            if (index < 0)
                return null;

            MouseCursorIdCache[id] = index; // Cache

            return MouseCursors.Elements[index];
        }

        // MouseCursorColorByMap

        public static Arrayx<int> MouseCursorColorByMapIds = Arrayx<int>.New();
        public static Arrayx<MouseCursorColorByMap> MouseCursorColorByMaps = Arrayx<MouseCursorColorByMap>.New();

        public static void AddMouseCursorColorByMap(MouseCursorColorByMap component)
        {
            MouseCursorColorByMapIds.Add(component.gameObject.GetInstanceID());
            MouseCursorColorByMaps.Add(component);
        }

        public static void RemoveMouseCursorColorByMap(MouseCursorColorByMap component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = MouseCursorColorByMapIds.IndexOf(id);

            MouseCursorColorByMapIds.RemoveAt(index);
            MouseCursorColorByMaps.RemoveAt(index);

            MouseCursorColorByMapIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<MouseCursorColorByMap> MouseCursorColorByMapResult = Arrayx<MouseCursorColorByMap>.New();
        public static Arrayx<MouseCursorColorByMap> GetMouseCursorColorByMap(params Arrayx<int>[] ids)
        {
            // MouseCursorColorByMapIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] MouseCursorColorByMapPlusIds = new Arrayx<int>[ids.Length + 1];
            MouseCursorColorByMapPlusIds[0] = MouseCursorColorByMapIds;
            Array.Copy(ids, 0, MouseCursorColorByMapPlusIds, 1, ids.Length);

            return Gigas.Get<MouseCursorColorByMap>(MouseCursorColorByMapPlusIds, EntitySet.MouseCursorColorByMaps, MouseCursorColorByMapResult);
        }

        public static MouseCursorColorByMap GetMouseCursorColorByMap(MonoBehaviour component)
        {
            return GetMouseCursorColorByMap(component.gameObject.GetInstanceID());
        }

        public static MouseCursorColorByMap GetMouseCursorColorByMap(GameObject gameobject)
        {
            return GetMouseCursorColorByMap(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> MouseCursorColorByMapIdCache = new Dictionary<int, int>();
        public static MouseCursorColorByMap GetMouseCursorColorByMap(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (MouseCursorColorByMapIdCache.TryGetValue(id, out cacheId))
                return MouseCursorColorByMaps.Elements[cacheId];

            var index = MouseCursorColorByMapIds.IndexOf(id);

            if (index < 0)
                return null;

            MouseCursorColorByMapIdCache[id] = index; // Cache

            return MouseCursorColorByMaps.Elements[index];
        }

        // PlayerFarAxis

        public static Arrayx<int> PlayerFarAxisIds = Arrayx<int>.New();
        public static Arrayx<PlayerFarAxis> PlayerFarAxiss = Arrayx<PlayerFarAxis>.New();

        public static void AddPlayerFarAxis(PlayerFarAxis component)
        {
            PlayerFarAxisIds.Add(component.gameObject.GetInstanceID());
            PlayerFarAxiss.Add(component);
        }

        public static void RemovePlayerFarAxis(PlayerFarAxis component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = PlayerFarAxisIds.IndexOf(id);

            PlayerFarAxisIds.RemoveAt(index);
            PlayerFarAxiss.RemoveAt(index);

            PlayerFarAxisIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<PlayerFarAxis> PlayerFarAxisResult = Arrayx<PlayerFarAxis>.New();
        public static Arrayx<PlayerFarAxis> GetPlayerFarAxis(params Arrayx<int>[] ids)
        {
            // PlayerFarAxisIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] PlayerFarAxisPlusIds = new Arrayx<int>[ids.Length + 1];
            PlayerFarAxisPlusIds[0] = PlayerFarAxisIds;
            Array.Copy(ids, 0, PlayerFarAxisPlusIds, 1, ids.Length);

            return Gigas.Get<PlayerFarAxis>(PlayerFarAxisPlusIds, EntitySet.PlayerFarAxiss, PlayerFarAxisResult);
        }

        public static PlayerFarAxis GetPlayerFarAxis(MonoBehaviour component)
        {
            return GetPlayerFarAxis(component.gameObject.GetInstanceID());
        }

        public static PlayerFarAxis GetPlayerFarAxis(GameObject gameobject)
        {
            return GetPlayerFarAxis(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> PlayerFarAxisIdCache = new Dictionary<int, int>();
        public static PlayerFarAxis GetPlayerFarAxis(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (PlayerFarAxisIdCache.TryGetValue(id, out cacheId))
                return PlayerFarAxiss.Elements[cacheId];

            var index = PlayerFarAxisIds.IndexOf(id);

            if (index < 0)
                return null;

            PlayerFarAxisIdCache[id] = index; // Cache

            return PlayerFarAxiss.Elements[index];
        }

        // PlayerNearAxis

        public static Arrayx<int> PlayerNearAxisIds = Arrayx<int>.New();
        public static Arrayx<PlayerNearAxis> PlayerNearAxiss = Arrayx<PlayerNearAxis>.New();

        public static void AddPlayerNearAxis(PlayerNearAxis component)
        {
            PlayerNearAxisIds.Add(component.gameObject.GetInstanceID());
            PlayerNearAxiss.Add(component);
        }

        public static void RemovePlayerNearAxis(PlayerNearAxis component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = PlayerNearAxisIds.IndexOf(id);

            PlayerNearAxisIds.RemoveAt(index);
            PlayerNearAxiss.RemoveAt(index);

            PlayerNearAxisIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<PlayerNearAxis> PlayerNearAxisResult = Arrayx<PlayerNearAxis>.New();
        public static Arrayx<PlayerNearAxis> GetPlayerNearAxis(params Arrayx<int>[] ids)
        {
            // PlayerNearAxisIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] PlayerNearAxisPlusIds = new Arrayx<int>[ids.Length + 1];
            PlayerNearAxisPlusIds[0] = PlayerNearAxisIds;
            Array.Copy(ids, 0, PlayerNearAxisPlusIds, 1, ids.Length);

            return Gigas.Get<PlayerNearAxis>(PlayerNearAxisPlusIds, EntitySet.PlayerNearAxiss, PlayerNearAxisResult);
        }

        public static PlayerNearAxis GetPlayerNearAxis(MonoBehaviour component)
        {
            return GetPlayerNearAxis(component.gameObject.GetInstanceID());
        }

        public static PlayerNearAxis GetPlayerNearAxis(GameObject gameobject)
        {
            return GetPlayerNearAxis(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> PlayerNearAxisIdCache = new Dictionary<int, int>();
        public static PlayerNearAxis GetPlayerNearAxis(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (PlayerNearAxisIdCache.TryGetValue(id, out cacheId))
                return PlayerNearAxiss.Elements[cacheId];

            var index = PlayerNearAxisIds.IndexOf(id);

            if (index < 0)
                return null;

            PlayerNearAxisIdCache[id] = index; // Cache

            return PlayerNearAxiss.Elements[index];
        }

        // PlayerOne

        public static Arrayx<int> PlayerOneIds = Arrayx<int>.New();
        public static Arrayx<PlayerOne> PlayerOnes = Arrayx<PlayerOne>.New();

        public static void AddPlayerOne(PlayerOne component)
        {
            PlayerOneIds.Add(component.gameObject.GetInstanceID());
            PlayerOnes.Add(component);
        }

        public static void RemovePlayerOne(PlayerOne component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = PlayerOneIds.IndexOf(id);

            PlayerOneIds.RemoveAt(index);
            PlayerOnes.RemoveAt(index);

            PlayerOneIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<PlayerOne> PlayerOneResult = Arrayx<PlayerOne>.New();
        public static Arrayx<PlayerOne> GetPlayerOne(params Arrayx<int>[] ids)
        {
            // PlayerOneIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] PlayerOnePlusIds = new Arrayx<int>[ids.Length + 1];
            PlayerOnePlusIds[0] = PlayerOneIds;
            Array.Copy(ids, 0, PlayerOnePlusIds, 1, ids.Length);

            return Gigas.Get<PlayerOne>(PlayerOnePlusIds, EntitySet.PlayerOnes, PlayerOneResult);
        }

        public static PlayerOne GetPlayerOne(MonoBehaviour component)
        {
            return GetPlayerOne(component.gameObject.GetInstanceID());
        }

        public static PlayerOne GetPlayerOne(GameObject gameobject)
        {
            return GetPlayerOne(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> PlayerOneIdCache = new Dictionary<int, int>();
        public static PlayerOne GetPlayerOne(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (PlayerOneIdCache.TryGetValue(id, out cacheId))
                return PlayerOnes.Elements[cacheId];

            var index = PlayerOneIds.IndexOf(id);

            if (index < 0)
                return null;

            PlayerOneIdCache[id] = index; // Cache

            return PlayerOnes.Elements[index];
        }

        // PlayerPerception

        public static Arrayx<int> PlayerPerceptionIds = Arrayx<int>.New();
        public static Arrayx<PlayerPerception> PlayerPerceptions = Arrayx<PlayerPerception>.New();

        public static void AddPlayerPerception(PlayerPerception component)
        {
            PlayerPerceptionIds.Add(component.gameObject.GetInstanceID());
            PlayerPerceptions.Add(component);
        }

        public static void RemovePlayerPerception(PlayerPerception component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = PlayerPerceptionIds.IndexOf(id);

            PlayerPerceptionIds.RemoveAt(index);
            PlayerPerceptions.RemoveAt(index);

            PlayerPerceptionIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<PlayerPerception> PlayerPerceptionResult = Arrayx<PlayerPerception>.New();
        public static Arrayx<PlayerPerception> GetPlayerPerception(params Arrayx<int>[] ids)
        {
            // PlayerPerceptionIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] PlayerPerceptionPlusIds = new Arrayx<int>[ids.Length + 1];
            PlayerPerceptionPlusIds[0] = PlayerPerceptionIds;
            Array.Copy(ids, 0, PlayerPerceptionPlusIds, 1, ids.Length);

            return Gigas.Get<PlayerPerception>(PlayerPerceptionPlusIds, EntitySet.PlayerPerceptions, PlayerPerceptionResult);
        }

        public static PlayerPerception GetPlayerPerception(MonoBehaviour component)
        {
            return GetPlayerPerception(component.gameObject.GetInstanceID());
        }

        public static PlayerPerception GetPlayerPerception(GameObject gameobject)
        {
            return GetPlayerPerception(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> PlayerPerceptionIdCache = new Dictionary<int, int>();
        public static PlayerPerception GetPlayerPerception(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (PlayerPerceptionIdCache.TryGetValue(id, out cacheId))
                return PlayerPerceptions.Elements[cacheId];

            var index = PlayerPerceptionIds.IndexOf(id);

            if (index < 0)
                return null;

            PlayerPerceptionIdCache[id] = index; // Cache

            return PlayerPerceptions.Elements[index];
        }

        // PosBite

        public static Arrayx<int> PosBiteIds = Arrayx<int>.New();
        public static Arrayx<PosBite> PosBites = Arrayx<PosBite>.New();

        public static void AddPosBite(PosBite component)
        {
            PosBiteIds.Add(component.gameObject.GetInstanceID());
            PosBites.Add(component);
        }

        public static void RemovePosBite(PosBite component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = PosBiteIds.IndexOf(id);

            PosBiteIds.RemoveAt(index);
            PosBites.RemoveAt(index);

            PosBiteIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<PosBite> PosBiteResult = Arrayx<PosBite>.New();
        public static Arrayx<PosBite> GetPosBite(params Arrayx<int>[] ids)
        {
            // PosBiteIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] PosBitePlusIds = new Arrayx<int>[ids.Length + 1];
            PosBitePlusIds[0] = PosBiteIds;
            Array.Copy(ids, 0, PosBitePlusIds, 1, ids.Length);

            return Gigas.Get<PosBite>(PosBitePlusIds, EntitySet.PosBites, PosBiteResult);
        }

        public static PosBite GetPosBite(MonoBehaviour component)
        {
            return GetPosBite(component.gameObject.GetInstanceID());
        }

        public static PosBite GetPosBite(GameObject gameobject)
        {
            return GetPosBite(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> PosBiteIdCache = new Dictionary<int, int>();
        public static PosBite GetPosBite(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (PosBiteIdCache.TryGetValue(id, out cacheId))
                return PosBites.Elements[cacheId];

            var index = PosBiteIds.IndexOf(id);

            if (index < 0)
                return null;

            PosBiteIdCache[id] = index; // Cache

            return PosBites.Elements[index];
        }

        // PosPuppet

        public static Arrayx<int> PosPuppetIds = Arrayx<int>.New();
        public static Arrayx<PosPuppet> PosPuppets = Arrayx<PosPuppet>.New();

        public static void AddPosPuppet(PosPuppet component)
        {
            PosPuppetIds.Add(component.gameObject.GetInstanceID());
            PosPuppets.Add(component);
        }

        public static void RemovePosPuppet(PosPuppet component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = PosPuppetIds.IndexOf(id);

            PosPuppetIds.RemoveAt(index);
            PosPuppets.RemoveAt(index);

            PosPuppetIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<PosPuppet> PosPuppetResult = Arrayx<PosPuppet>.New();
        public static Arrayx<PosPuppet> GetPosPuppet(params Arrayx<int>[] ids)
        {
            // PosPuppetIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] PosPuppetPlusIds = new Arrayx<int>[ids.Length + 1];
            PosPuppetPlusIds[0] = PosPuppetIds;
            Array.Copy(ids, 0, PosPuppetPlusIds, 1, ids.Length);

            return Gigas.Get<PosPuppet>(PosPuppetPlusIds, EntitySet.PosPuppets, PosPuppetResult);
        }

        public static PosPuppet GetPosPuppet(MonoBehaviour component)
        {
            return GetPosPuppet(component.gameObject.GetInstanceID());
        }

        public static PosPuppet GetPosPuppet(GameObject gameobject)
        {
            return GetPosPuppet(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> PosPuppetIdCache = new Dictionary<int, int>();
        public static PosPuppet GetPosPuppet(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (PosPuppetIdCache.TryGetValue(id, out cacheId))
                return PosPuppets.Elements[cacheId];

            var index = PosPuppetIds.IndexOf(id);

            if (index < 0)
                return null;

            PosPuppetIdCache[id] = index; // Cache

            return PosPuppets.Elements[index];
        }

        // ShakeOnKnockback

        public static Arrayx<int> ShakeOnKnockbackIds = Arrayx<int>.New();
        public static Arrayx<ShakeOnKnockback> ShakeOnKnockbacks = Arrayx<ShakeOnKnockback>.New();

        public static void AddShakeOnKnockback(ShakeOnKnockback component)
        {
            ShakeOnKnockbackIds.Add(component.gameObject.GetInstanceID());
            ShakeOnKnockbacks.Add(component);
        }

        public static void RemoveShakeOnKnockback(ShakeOnKnockback component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = ShakeOnKnockbackIds.IndexOf(id);

            ShakeOnKnockbackIds.RemoveAt(index);
            ShakeOnKnockbacks.RemoveAt(index);

            ShakeOnKnockbackIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<ShakeOnKnockback> ShakeOnKnockbackResult = Arrayx<ShakeOnKnockback>.New();
        public static Arrayx<ShakeOnKnockback> GetShakeOnKnockback(params Arrayx<int>[] ids)
        {
            // ShakeOnKnockbackIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] ShakeOnKnockbackPlusIds = new Arrayx<int>[ids.Length + 1];
            ShakeOnKnockbackPlusIds[0] = ShakeOnKnockbackIds;
            Array.Copy(ids, 0, ShakeOnKnockbackPlusIds, 1, ids.Length);

            return Gigas.Get<ShakeOnKnockback>(ShakeOnKnockbackPlusIds, EntitySet.ShakeOnKnockbacks, ShakeOnKnockbackResult);
        }

        public static ShakeOnKnockback GetShakeOnKnockback(MonoBehaviour component)
        {
            return GetShakeOnKnockback(component.gameObject.GetInstanceID());
        }

        public static ShakeOnKnockback GetShakeOnKnockback(GameObject gameobject)
        {
            return GetShakeOnKnockback(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> ShakeOnKnockbackIdCache = new Dictionary<int, int>();
        public static ShakeOnKnockback GetShakeOnKnockback(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (ShakeOnKnockbackIdCache.TryGetValue(id, out cacheId))
                return ShakeOnKnockbacks.Elements[cacheId];

            var index = ShakeOnKnockbackIds.IndexOf(id);

            if (index < 0)
                return null;

            ShakeOnKnockbackIdCache[id] = index; // Cache

            return ShakeOnKnockbacks.Elements[index];
        }

        // SinglePlayerInput

        public static Arrayx<int> SinglePlayerInputIds = Arrayx<int>.New();
        public static Arrayx<SinglePlayerInput> SinglePlayerInputs = Arrayx<SinglePlayerInput>.New();

        public static void AddSinglePlayerInput(SinglePlayerInput component)
        {
            SinglePlayerInputIds.Add(component.gameObject.GetInstanceID());
            SinglePlayerInputs.Add(component);
        }

        public static void RemoveSinglePlayerInput(SinglePlayerInput component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = SinglePlayerInputIds.IndexOf(id);

            SinglePlayerInputIds.RemoveAt(index);
            SinglePlayerInputs.RemoveAt(index);

            SinglePlayerInputIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<SinglePlayerInput> SinglePlayerInputResult = Arrayx<SinglePlayerInput>.New();
        public static Arrayx<SinglePlayerInput> GetSinglePlayerInput(params Arrayx<int>[] ids)
        {
            // SinglePlayerInputIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] SinglePlayerInputPlusIds = new Arrayx<int>[ids.Length + 1];
            SinglePlayerInputPlusIds[0] = SinglePlayerInputIds;
            Array.Copy(ids, 0, SinglePlayerInputPlusIds, 1, ids.Length);

            return Gigas.Get<SinglePlayerInput>(SinglePlayerInputPlusIds, EntitySet.SinglePlayerInputs, SinglePlayerInputResult);
        }

        public static SinglePlayerInput GetSinglePlayerInput(MonoBehaviour component)
        {
            return GetSinglePlayerInput(component.gameObject.GetInstanceID());
        }

        public static SinglePlayerInput GetSinglePlayerInput(GameObject gameobject)
        {
            return GetSinglePlayerInput(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> SinglePlayerInputIdCache = new Dictionary<int, int>();
        public static SinglePlayerInput GetSinglePlayerInput(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (SinglePlayerInputIdCache.TryGetValue(id, out cacheId))
                return SinglePlayerInputs.Elements[cacheId];

            var index = SinglePlayerInputIds.IndexOf(id);

            if (index < 0)
                return null;

            SinglePlayerInputIdCache[id] = index; // Cache

            return SinglePlayerInputs.Elements[index];
        }

        // SinglePlayerKeyboard

        public static Arrayx<int> SinglePlayerKeyboardIds = Arrayx<int>.New();
        public static Arrayx<SinglePlayerKeyboard> SinglePlayerKeyboards = Arrayx<SinglePlayerKeyboard>.New();

        public static void AddSinglePlayerKeyboard(SinglePlayerKeyboard component)
        {
            SinglePlayerKeyboardIds.Add(component.gameObject.GetInstanceID());
            SinglePlayerKeyboards.Add(component);
        }

        public static void RemoveSinglePlayerKeyboard(SinglePlayerKeyboard component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = SinglePlayerKeyboardIds.IndexOf(id);

            SinglePlayerKeyboardIds.RemoveAt(index);
            SinglePlayerKeyboards.RemoveAt(index);

            SinglePlayerKeyboardIdCache.Clear(); // Removing the element changes the cache order
        }

        private static Arrayx<SinglePlayerKeyboard> SinglePlayerKeyboardResult = Arrayx<SinglePlayerKeyboard>.New();
        public static Arrayx<SinglePlayerKeyboard> GetSinglePlayerKeyboard(params Arrayx<int>[] ids)
        {
            // SinglePlayerKeyboardIds needs to be the first in the array parameter,
            // that's how Gigas.Get relates the ids to the components

            Arrayx<int>[] SinglePlayerKeyboardPlusIds = new Arrayx<int>[ids.Length + 1];
            SinglePlayerKeyboardPlusIds[0] = SinglePlayerKeyboardIds;
            Array.Copy(ids, 0, SinglePlayerKeyboardPlusIds, 1, ids.Length);

            return Gigas.Get<SinglePlayerKeyboard>(SinglePlayerKeyboardPlusIds, EntitySet.SinglePlayerKeyboards, SinglePlayerKeyboardResult);
        }

        public static SinglePlayerKeyboard GetSinglePlayerKeyboard(MonoBehaviour component)
        {
            return GetSinglePlayerKeyboard(component.gameObject.GetInstanceID());
        }

        public static SinglePlayerKeyboard GetSinglePlayerKeyboard(GameObject gameobject)
        {
            return GetSinglePlayerKeyboard(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> SinglePlayerKeyboardIdCache = new Dictionary<int, int>();
        public static SinglePlayerKeyboard GetSinglePlayerKeyboard(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (SinglePlayerKeyboardIdCache.TryGetValue(id, out cacheId))
                return SinglePlayerKeyboards.Elements[cacheId];

            var index = SinglePlayerKeyboardIds.IndexOf(id);

            if (index < 0)
                return null;

            SinglePlayerKeyboardIdCache[id] = index; // Cache

            return SinglePlayerKeyboards.Elements[index];
        }

        // Alt DashToPlayerAction

        public static Arrayx<int> AltDashToPlayerActionIds = Arrayx<int>.New();
        public static Arrayx<DashToPlayerAction> AltDashToPlayerActions = Arrayx<DashToPlayerAction>.New();

        public static void AddAltDashToPlayerAction(DashToPlayerAction component)
        {
            AltDashToPlayerActionIds.Add(component.gameObject.GetInstanceID());
            AltDashToPlayerActions.Add(component);
        }

        public static void RemoveAltDashToPlayerAction(DashToPlayerAction component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = AltDashToPlayerActionIds.IndexOf(id);

            AltDashToPlayerActionIds.RemoveAt(index);
            AltDashToPlayerActions.RemoveAt(index);

            AltDashToPlayerActionIdCache.Clear(); // Removing the element changes the cache order
        }

        public static DashToPlayerAction GetAltDashToPlayerAction(MonoBehaviour component)
        {
            return GetAltDashToPlayerAction(component.gameObject.GetInstanceID());
        }

        public static DashToPlayerAction GetAltDashToPlayerAction(GameObject gameobject)
        {
            return GetAltDashToPlayerAction(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> AltDashToPlayerActionIdCache = new Dictionary<int, int>();
        public static DashToPlayerAction GetAltDashToPlayerAction(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (AltDashToPlayerActionIdCache.TryGetValue(id, out cacheId))
                return AltDashToPlayerActions.Elements[cacheId];

            var index = AltDashToPlayerActionIds.IndexOf(id);

            if (index < 0)
                return null;

            AltDashToPlayerActionIdCache[id] = index; // Cache

            return AltDashToPlayerActions.Elements[index];
        }

        // Alt FlyTowardsPlayerAction

        public static Arrayx<int> AltFlyTowardsPlayerActionIds = Arrayx<int>.New();
        public static Arrayx<FlyTowardsPlayerAction> AltFlyTowardsPlayerActions = Arrayx<FlyTowardsPlayerAction>.New();

        public static void AddAltFlyTowardsPlayerAction(FlyTowardsPlayerAction component)
        {
            AltFlyTowardsPlayerActionIds.Add(component.gameObject.GetInstanceID());
            AltFlyTowardsPlayerActions.Add(component);
        }

        public static void RemoveAltFlyTowardsPlayerAction(FlyTowardsPlayerAction component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = AltFlyTowardsPlayerActionIds.IndexOf(id);

            AltFlyTowardsPlayerActionIds.RemoveAt(index);
            AltFlyTowardsPlayerActions.RemoveAt(index);

            AltFlyTowardsPlayerActionIdCache.Clear(); // Removing the element changes the cache order
        }

        public static FlyTowardsPlayerAction GetAltFlyTowardsPlayerAction(MonoBehaviour component)
        {
            return GetAltFlyTowardsPlayerAction(component.gameObject.GetInstanceID());
        }

        public static FlyTowardsPlayerAction GetAltFlyTowardsPlayerAction(GameObject gameobject)
        {
            return GetAltFlyTowardsPlayerAction(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> AltFlyTowardsPlayerActionIdCache = new Dictionary<int, int>();
        public static FlyTowardsPlayerAction GetAltFlyTowardsPlayerAction(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (AltFlyTowardsPlayerActionIdCache.TryGetValue(id, out cacheId))
                return AltFlyTowardsPlayerActions.Elements[cacheId];

            var index = AltFlyTowardsPlayerActionIds.IndexOf(id);

            if (index < 0)
                return null;

            AltFlyTowardsPlayerActionIdCache[id] = index; // Cache

            return AltFlyTowardsPlayerActions.Elements[index];
        }

        // Alt MotionByInput

        public static Arrayx<int> AltMotionByInputIds = Arrayx<int>.New();
        public static Arrayx<MotionByInput> AltMotionByInputs = Arrayx<MotionByInput>.New();

        public static void AddAltMotionByInput(MotionByInput component)
        {
            AltMotionByInputIds.Add(component.gameObject.GetInstanceID());
            AltMotionByInputs.Add(component);
        }

        public static void RemoveAltMotionByInput(MotionByInput component)
        {
            var id = component.gameObject.GetInstanceID();
            var index = AltMotionByInputIds.IndexOf(id);

            AltMotionByInputIds.RemoveAt(index);
            AltMotionByInputs.RemoveAt(index);

            AltMotionByInputIdCache.Clear(); // Removing the element changes the cache order
        }

        public static MotionByInput GetAltMotionByInput(MonoBehaviour component)
        {
            return GetAltMotionByInput(component.gameObject.GetInstanceID());
        }

        public static MotionByInput GetAltMotionByInput(GameObject gameobject)
        {
            return GetAltMotionByInput(gameobject.GetInstanceID());
        }

        private static Dictionary<int, int> AltMotionByInputIdCache = new Dictionary<int, int>();
        public static MotionByInput GetAltMotionByInput(int instanceID)
        {
            var id = instanceID;

            int cacheId;
            if (AltMotionByInputIdCache.TryGetValue(id, out cacheId))
                return AltMotionByInputs.Elements[cacheId];

            var index = AltMotionByInputIds.IndexOf(id);

            if (index < 0)
                return null;

            AltMotionByInputIdCache[id] = index; // Cache

            return AltMotionByInputs.Elements[index];
        }

        public static void Clear()
        {
            AluminonAgentIds.Length = 0;
            AluminonAgents.Length = 0;

            BoxelIds.Length = 0;
            Boxels.Length = 0;

            BoxelByClickIds.Length = 0;
            BoxelByClicks.Length = 0;

            BoxelCacheIds.Length = 0;
            BoxelCaches.Length = 0;

            BoxelCreatorIds.Length = 0;
            BoxelCreators.Length = 0;

            BoxelMapIds.Length = 0;
            BoxelMaps.Length = 0;

            BoxelMapColorScrollIds.Length = 0;
            BoxelMapColorScrolls.Length = 0;

            BoxelMapPainterIds.Length = 0;
            BoxelMapPainters.Length = 0;

            BoxelMapRegionIds.Length = 0;
            BoxelMapRegions.Length = 0;

            BoxelMapRegionPlayerIds.Length = 0;
            BoxelMapRegionPlayers.Length = 0;

            BoxelPopUpIds.Length = 0;
            BoxelPopUps.Length = 0;

            BulletFactoryIds.Length = 0;
            BulletFactorys.Length = 0;

            BulletGunIds.Length = 0;
            BulletGuns.Length = 0;

            BulletMissileIds.Length = 0;
            BulletMissiles.Length = 0;

            CamIds.Length = 0;
            Cams.Length = 0;

            CamAutoZoomTargetIds.Length = 0;
            CamAutoZoomTargets.Length = 0;

            CamTargetIds.Length = 0;
            CamTargets.Length = 0;

            CamZoomByScrollIds.Length = 0;
            CamZoomByScrolls.Length = 0;

            CharacterMotionIds.Length = 0;
            CharacterMotions.Length = 0;

            DamageGiverIds.Length = 0;
            DamageGivers.Length = 0;

            DamageReceiverIds.Length = 0;
            DamageReceivers.Length = 0;

            DashIds.Length = 0;
            Dashs.Length = 0;

            DashToPlayerActionIds.Length = 0;
            DashToPlayerActions.Length = 0;

            FlyByInputIds.Length = 0;
            FlyByInputs.Length = 0;

            FlyMotionIds.Length = 0;
            FlyMotions.Length = 0;

            FlyTowardsPlayerActionIds.Length = 0;
            FlyTowardsPlayerActions.Length = 0;

            FollowPlayerIds.Length = 0;
            FollowPlayers.Length = 0;

            FreezeFrameOnKnockbackIds.Length = 0;
            FreezeFrameOnKnockbacks.Length = 0;

            GroundDetectionIds.Length = 0;
            GroundDetections.Length = 0;

            IdBiteIds.Length = 0;
            IdBites.Length = 0;

            JumpByInputIds.Length = 0;
            JumpByInputs.Length = 0;

            JumpCountLimitIds.Length = 0;
            JumpCountLimits.Length = 0;

            JumpRulesIds.Length = 0;
            JumpRuless.Length = 0;

            MotionByInputIds.Length = 0;
            MotionByInputs.Length = 0;

            MotionKnockbackIds.Length = 0;
            MotionKnockbacks.Length = 0;

            MotionKnockbackGiverIds.Length = 0;
            MotionKnockbackGivers.Length = 0;

            MouseCursorIds.Length = 0;
            MouseCursors.Length = 0;

            MouseCursorColorByMapIds.Length = 0;
            MouseCursorColorByMaps.Length = 0;

            PlayerFarAxisIds.Length = 0;
            PlayerFarAxiss.Length = 0;

            PlayerNearAxisIds.Length = 0;
            PlayerNearAxiss.Length = 0;

            PlayerOneIds.Length = 0;
            PlayerOnes.Length = 0;

            PlayerPerceptionIds.Length = 0;
            PlayerPerceptions.Length = 0;

            PosBiteIds.Length = 0;
            PosBites.Length = 0;

            PosPuppetIds.Length = 0;
            PosPuppets.Length = 0;

            ShakeOnKnockbackIds.Length = 0;
            ShakeOnKnockbacks.Length = 0;

            SinglePlayerInputIds.Length = 0;
            SinglePlayerInputs.Length = 0;

            SinglePlayerKeyboardIds.Length = 0;
            SinglePlayerKeyboards.Length = 0;
        }

        public static void ClearAlt()
        {
            AltDashToPlayerActionIds.Length = 0;
            AltDashToPlayerActions.Length = 0;

            AltFlyTowardsPlayerActionIds.Length = 0;
            AltFlyTowardsPlayerActions.Length = 0;

            AltMotionByInputIds.Length = 0;
            AltMotionByInputs.Length = 0;
        }
    }
//  }
