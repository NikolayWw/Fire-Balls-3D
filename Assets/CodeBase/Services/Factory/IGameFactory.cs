﻿using CodeBase.StaticData.Bullet;
using CodeBase.StaticData.Obstacle;
using CodeBase.StaticData.Tower;
using UnityEngine;

namespace CodeBase.Services.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreateTower(TowerId id, Vector3 at);

        GameObject CreateBullet(BulletId id);

        GameObject CreateObstacle(ObstacleId id, Vector3 at);

        GameObject CreatePlayer();
    }
}