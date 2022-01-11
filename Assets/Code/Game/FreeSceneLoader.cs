using Code.Bootstrapper;
using UnityEngine;

namespace Code.Menu
{
    public class FreeSceneLoader : SceneBootstrapper
    {
        [SerializeField] private CollectableItemsManager manager;
        
        
        public override void OnSceneLoaded(GameBootstrapper gameBootstrapper)
        {
            manager.Init();
            GameBootstrapper = gameBootstrapper;
        }

        public override void OnSceneUnloaded(GameBootstrapper gameBootstrapper)
        {
            
        }
    }
}