using System;
using Code.Bootstrapper;
using UnityEngine;

namespace Code.MenuLogic
{
    public class MenuLoader : SceneBootstrapper
    {
        public GameBootstrapper GameBootstrapper { get; private set; }

        public override void OnSceneUnloaded(GameBootstrapper gameBootstrapper)
        {
        }

        public override void OnSceneLoaded(GameBootstrapper gameBootstrapper)
        {
            GameBootstrapper = gameBootstrapper;
        }

        public void LoadFreeGame()
        {
            GameBootstrapper.LoadScene(GameScene.FreeGame);
        }

        public void LoadTunnelGame()
        {
            var index = PlayerPrefs.GetString("LevelIndex", GameScene.Game1.ToString());

            if (Enum.TryParse(index, out GameScene value))
            {
                GameBootstrapper.LoadScene(value);
                return;
            }
            
            GameBootstrapper.LoadScene(GameScene.Game1);
            
        }
    }
}