using Code.Bootstrapper;
using UnityEngine;

namespace Code.Menu
{
    public class LevelSceneLoader : SceneBootstrapper
    {
        
        public override void OnSceneLoaded(GameBootstrapper gameBootstrapper)
        {
            GameBootstrapper = gameBootstrapper;
        }

        public override void OnSceneUnloaded(GameBootstrapper gameBootstrapper)
        {
           
        }
    }
}