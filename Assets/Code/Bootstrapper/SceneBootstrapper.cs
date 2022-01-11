using UnityEngine;

namespace Code.Bootstrapper
{
    public abstract class SceneBootstrapper: MonoBehaviour
    {
        public GameBootstrapper GameBootstrapper { get; set; } 
        
        public abstract void OnSceneLoaded(GameBootstrapper gameBootstrapper);

        public abstract void OnSceneUnloaded(GameBootstrapper gameBootstrapper);
    }
}