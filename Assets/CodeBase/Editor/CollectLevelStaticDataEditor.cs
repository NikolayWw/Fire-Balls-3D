using CodeBase.Data;
using CodeBase.Logic.Markers;
using CodeBase.StaticData.Levels;
using CodeBase.StaticData.Obstacle;
using CodeBase.StaticData.Tower;
using CodeBase.StaticData.Trek;
using System.Linq;
using CodeBase.Extension;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Editor
{
    public class CollectLevelStaticDataEditor : UnityEditor.Editor
    {
        private const string LevelStaticDataPath = "StaticData/LevelsStaticData";

        [MenuItem("Tools/Collect Level Data")]
        private static void CollectLevelData()
        {
            LevelsStaticData levelsStaticData = Resources.Load<LevelsStaticData>(LevelStaticDataPath);

            foreach (LevelConfig config in levelsStaticData.LevelConfigs)
            {
                if (SceneKey() == config.LevelKey)
                {
                    GameObject playerInitialPoint = GameObject.FindGameObjectWithTag(GameConstants.PlayerInitialPointTag);
                    TowerLevelStaticData[] towerLevelStaticData = FindObjectsOfType<TowerSpawnMarker>().Select(x => new TowerLevelStaticData(x.TowerId, x.transform.position)).ToArray();
                    ObstacleLevelStaticData[] obstacleLevelStaticData = FindObjectsOfType<ObstacleSpawnMarker>().Select(x => new ObstacleLevelStaticData(x.ObstacleId, x.transform.position)).ToArray();
                    TrekLevelStaticData[] trekLevelStaticData = FindTrekLevelStaticData();
                  
                    config.SetData(playerInitialPoint.transform.position, trekLevelStaticData, towerLevelStaticData, obstacleLevelStaticData);

                    EditorUtility.SetDirty(levelsStaticData);
                    break;
                }
            }
        }

        private static TrekLevelStaticData[] FindTrekLevelStaticData()
        {
            TrekMarker[] markers = FindObjectsOfType<TrekMarker>();
            markers.BubbleSort();
            TrekLevelStaticData[] trekStaticData = markers.Select(x => new TrekLevelStaticData(x.GetTrekPoints())).ToArray();
            return trekStaticData;
        }

        private static string SceneKey() =>
              SceneManager.GetActiveScene().name;
    }
}