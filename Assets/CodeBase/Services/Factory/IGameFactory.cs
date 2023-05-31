using CodeBase.Bullet;
using CodeBase.StaticData.Bullet;
using CodeBase.StaticData.Let;
using CodeBase.StaticData.Tower;
using UnityEngine;

namespace CodeBase.Services.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreateTower(TowerId id, Vector3 at);
        GameObject CreateBullet(BulletId id);
        GameObject CreateLet(LetId id, Vector3 at);
    }
}