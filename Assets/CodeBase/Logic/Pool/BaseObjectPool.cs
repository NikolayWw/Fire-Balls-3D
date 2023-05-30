using CodeBase.Bullet;
using CodeBase.Services.Factory;
using CodeBase.StaticData.Bullet;
using System;
using System.Collections.Generic;

namespace CodeBase.Logic.Pool
{
    public abstract class BaseObjectPool<TKey, TObjectPool>
        where TKey : Enum
        where TObjectPool : class, IObjectPool
    {
        private readonly Dictionary<TKey, Queue<TObjectPool>> _objectsDictionary = new();

        public TObjectPool Get(TKey id)
        {
            GetQueue(id, out Queue<TObjectPool> queue);

            if (TryGetObjectPool(queue, out var objectPool))
                return objectPool;

            return InitNewObjectPool(queue, id);
        }

        protected abstract TObjectPool NewObjectPool(TKey id);

        private TObjectPool InitNewObjectPool(Queue<TObjectPool> queue, TKey id)
        {
            TObjectPool newObjectPool = NewObjectPool(id);
            queue.Enqueue(newObjectPool);
            return newObjectPool;
        }

        private static bool TryGetObjectPool(Queue<TObjectPool> queue, out TObjectPool objectPool)
        {
            for (int i = 0; i < queue.Count; i++)
            {
                TObjectPool dequeue = queue.Dequeue();
                queue.Enqueue(dequeue);

                if (dequeue.IsReady() == false)
                    continue;

                dequeue.Enable();
                objectPool = dequeue;
                return true;
            }

            objectPool = null;
            return false;
        }

        private void GetQueue(TKey id, out Queue<TObjectPool> queue)
        {
            if (_objectsDictionary.TryGetValue(id, out queue) == false)
            {
                queue = new Queue<TObjectPool>();
                _objectsDictionary.Add(id, queue);
            }
        }
    }

    public class BulletObjectPool : BaseObjectPool<BulletId, BulletMove>
    {
        private readonly IGameFactory _gameFactory;

        public BulletObjectPool(IGameFactory gameFactory) => 
            _gameFactory = gameFactory;

        protected override BulletMove NewObjectPool(BulletId id) => 
            _gameFactory.CreateBullet(id).GetComponent<BulletMove>();
    }
}