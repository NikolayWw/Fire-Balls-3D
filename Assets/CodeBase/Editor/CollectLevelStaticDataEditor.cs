using CodeBase.Data;
using CodeBase.Extension;
using CodeBase.Logic.Markers;
using CodeBase.StaticData.Levels;
using CodeBase.StaticData.Tower;
using CodeBase.StaticData.Trek;
using System.Linq;
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
                    config.SetData(playerInitialPoint.transform.position, FindTrekLevelStaticData(), FindTowerStaticData());
                    EditorUtility.SetDirty(levelsStaticData);
                    break;
                }
            }
        }

        private static TrekLevelStaticData[] FindTrekLevelStaticData()
        {
            TrekMarker[] markers = FindObjectsOfType<TrekMarker>();
            markers.ArrayBubbleSort();
            TrekLevelStaticData[] staticData = markers.Select(x => new TrekLevelStaticData(x.GetTrekPoints())).ToArray();
            return staticData;
        }

        private static TowerLevelStaticData[] FindTowerStaticData()
        {
            TowerSpawnMarker[] markers = FindObjectsOfType<TowerSpawnMarker>();
            markers.ArrayBubbleSort();
            TowerLevelStaticData[] staticData = markers.Select(x => new TowerLevelStaticData(x.TowerId, x.ObstacleId, x.transform.position)).ToArray();
            return staticData;
        }

        private static string SceneKey() =>
              SceneManager.GetActiveScene().name;
    }
}