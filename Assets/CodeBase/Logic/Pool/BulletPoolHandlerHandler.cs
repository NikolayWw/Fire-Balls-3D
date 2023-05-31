using CodeBase.Bullet;
using CodeBase.Services.Factory;
using CodeBase.StaticData.Bullet;
using UnityEngine;

namespace CodeBase.Logic.Pool
{
    public class BulletPoolHandlerHandler : BaseObjectPoolHandler<BulletId, BulletPoolObject>
    {
        private readonly IGameFactory _gameFactory;

        public BulletPoolHandlerHandler(IGameFactory gameFactory) =>
            _gameFactory = gameFactory;

        public BulletMove Get(BulletId id)
        {
            PoolObjectData data = GetData(id);
            data.ObjectPool.Enable();
            return (BulletMove)data.GetComponent(typeof(BulletMove));
        }

        protected override PoolObjectData NewObjectPoolData(BulletId key)
        {
            GameObject instance = _gameFactory.CreateBullet(key);

            BulletPoolObject poolObjects = instance.GetComponent<BulletPoolObject>();
            BulletMove bulletMove = instance.GetComponent<BulletMove>();

            return new PoolObjectData(poolObjects, bulletMove);
        }
    }
}