using System;
using Code.Bootstrapper;
using Code.Menu;
using UnityEngine;
using UnityEngine.UI;

namespace Code
{
    public class LevelCompleteView : MonoBehaviour
    {
        [SerializeField] private Button ContinueButton;
        [SerializeField] private SceneBootstrapper freeSceneLoader;

        private void Awake()
        {
            ContinueButton.onClick.AddListener(Continue);

            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        private void Continue()
        {
            freeSceneLoader.GameBootstrapper.LoadScene(GameScene.Menu);
        }
        
    }
}