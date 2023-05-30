using CodeBase.Bullet;
using CodeBase.Services.Factory;
using CodeBase.StaticData.Bullet;
using System;
using System.Collections.Generic;

namespace CodeBase.Infrastructure.Logic.Pool
{
    public abstract class BaseObjectPool<TKey, TObjectPool>
        where TKey : Enum
        where TObjectPool : class, IObjectPool
    {
        protected IGameFactory GameFactory { get; }
        private readonly Dictionary<TKey, Queue<TObjectPool>> _objectsDictionary = new();

        protected BaseObjectPool(IGameFactory gameFactory)
        {
            GameFactory = gameFactory;
        }

        protected TObjectPool Get(TKey id)
        {
            if (_objectsDictionary.TryGetValue(id, out Queue<TObjectPool> queue) == false)
            {
                queue = new Queue<TObjectPool>();
                _objectsDictionary.Add(id, queue);
            }

            for (int i = 0; i < queue.Count; i++)
            {
                TObjectPool dequeue = queue.Dequeue();
                queue.Enqueue(dequeue);

                if (dequeue.IsReady() == false)
                    continue;
                dequeue.Enable();
                return queue.Dequeue();
            }

            return queue.Dequeue();
        }
    }

    public class BulletObjectPool : BaseObjectPool<BulletId, BulletObjectPoolReporter>
    {
        public BulletObjectPool(IGameFactory gameFactory) : base(gameFactory)
        { }

        public BulletHit BulletHit(BulletId id)
        {
            Get(id);
            GameFactory.CreateBullet(id);
            return null;
        }
    }
}