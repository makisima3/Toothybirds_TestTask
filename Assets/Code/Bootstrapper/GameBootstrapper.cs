using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Bootstrapper
{
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private GameScene firstScene = GameScene.LoadScene;

        public GameScene CurrentGameScene { get; private set; }
        public SceneBootstrapper CurrentSceneBootstrapper { get; private set; }

        public bool HasLoadedScene =>
            _currentSceneBuildIndex > 0 &&
            CurrentGameScene != GameScene.LoadScene; 
            

        private int _currentSceneBuildIndex;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            _currentSceneBuildIndex = 0;
            
            if (CurrentGameScene == GameScene.LoadScene)
            {
                LoadScene(firstScene);
            }
        }

        public void LoadScene(GameScene scene)
        {
            if(scene == GameScene.LoadScene)
                return;
            
            if (HasLoadedScene)
            {
                OnSceneUnloaded();
            }

            CurrentGameScene = scene;
            _currentSceneBuildIndex = GetSceneBuildIndex(CurrentGameScene);

            var loadOperation = SceneManager.LoadSceneAsync(_currentSceneBuildIndex);
            loadOperation.completed += _ => OnSceneLoaded();
        }

        private void OnSceneLoaded()
        {
            CurrentSceneBootstrapper = FindObjectOfType<SceneBootstrapper>();

            if (CurrentSceneBootstrapper != null)
            {
                CurrentSceneBootstrapper.OnSceneLoaded(this);
            }
        }

        private void OnSceneUnloaded()
        {
            if (CurrentSceneBootstrapper != null)
            {
                CurrentSceneBootstrapper.OnSceneUnloaded(this);
            }

            CurrentSceneBootstrapper = null;
        }

        private static int GetSceneBuildIndex(GameScene scene) => (int) scene;
    }
}