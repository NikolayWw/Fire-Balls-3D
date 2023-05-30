using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Logic.Pool
{
    public abstract class BaseObjectPoolHandler<TKey, TObjectPool>
        where TKey : Enum
        where TObjectPool : class, IObjectPool
    {
        public class PoolObjectData
        {
            public TObjectPool ObjectPool { get; }
            private readonly Dictionary<Type, MonoBehaviour> _components;

            public PoolObjectData(TObjectPool objectPool, params MonoBehaviour[] components)
            {
                ObjectPool = objectPool;
                _components = new Dictionary<Type, MonoBehaviour>(components.Length);
                InitDictionary(components);
            }

            public MonoBehaviour GetComponent(Type key) =>
                _components.TryGetValue(key, out MonoBehaviour component) ? component : null;

            private void InitDictionary(MonoBehaviour[] components)
            {
                foreach (MonoBehaviour component in components)
                    _components.Add(component.GetType(), component);
            }
        }

        private readonly Dictionary<TKey, Queue<PoolObjectData>> _objectsDictionary = new();

        protected PoolObjectData GetData(TKey id)
        {
            GetQueue(id, out Queue<PoolObjectData> queue);
            return TryGetObjectPool(queue, out PoolObjectData objectPool) ? objectPool : InitNewObjectPool(queue, id);
        }

        protected abstract PoolObjectData NewObjectPoolData(TKey id);

        private PoolObjectData InitNewObjectPool(Queue<PoolObjectData> queue, TKey id)
        {
            PoolObjectData newObjectPool = NewObjectPoolData(id);
            queue.Enqueue(newObjectPool);
            return newObjectPool;
        }

        private static bool TryGetObjectPool(Queue<PoolObjectData> queue, out PoolObjectData poolData)
        {
            for (int i = 0; i < queue.Count; i++)
            {
                poolData = queue.Dequeue();
                queue.Enqueue(poolData);

                if (poolData.ObjectPool.IsReady())
                    return true;
            }

            poolData = null;
            return false;
        }

        private void GetQueue(TKey id, out Queue<PoolObjectData> queue)
        {
            if (_objectsDictionary.TryGetValue(id, out queue) == false)
            {
                queue = new Queue<PoolObjectData>();
                _objectsDictionary.Add(id, queue);
            }
        }
    }
}