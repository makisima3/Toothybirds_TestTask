using System;
using Code.Bootstrapper;
using Code.PlayerControllers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.InteractableObjects
{
    public class DeathTrigger : MonoBehaviour
    {
        [SerializeField] private SceneBootstrapper freeSceneLoader;
        [SerializeField] private GameScene currentScene;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Collector>(out _))
            {
                freeSceneLoader.GameBootstrapper.LoadScene(currentScene);
            }  
        }
    }
}