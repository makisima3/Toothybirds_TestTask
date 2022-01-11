using System;
using Code.Bootstrapper;
using Code.PlayerControllers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.InteractableObjects
{
    public class Finish : MonoBehaviour
    {
        [SerializeField] private bool isSave;
        [SerializeField] private GameScene save;
        
        [SerializeField] private LevelCompleteView levelCompleteView;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Collector>(out var collector))
            {
                if (collector.CollectedCount >= collector.CollectedTarget)
                {
                    if(isSave)
                        PlayerPrefs.SetString("LevelIndex", save.ToString());
                    levelCompleteView.Show();
                }
            }       
        }
    }
}