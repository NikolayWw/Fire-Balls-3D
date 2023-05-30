using CodeBase.Infrastructure.Logic.Pool;
using UnityEngine;

namespace CodeBase.Bullet
{
    public class BulletObjectPoolReporter : MonoBehaviour,IObjectPool
    {
        public void Enable()
        {
            
        }

        public void Disable()
        {
        }

        public bool IsReady()
        {
            return false;
        }
    }
}