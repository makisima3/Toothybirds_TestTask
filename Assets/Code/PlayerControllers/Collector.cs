using System;
using Code.Interfaces;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace Code.PlayerControllers
{
    public class Collector : MonoBehaviour
    {
        [SerializeField] private TMP_Text collectedCountPlace;
        [SerializeField] private int collectedTarget = 3;
        
        
        private int collectedCount = 0;

        public int CollectedTarget => collectedTarget;

        public int CollectedCount => collectedCount;

        private void Start()
        {
            collectedCountPlace.text = $"0/{collectedTarget}";
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<ICollectable>(out var collectable))
            {
                collectable.Collect();

                collectedCount++;

                collectedCountPlace.text = $"{collectedCount}/{collectedTarget}";
                
                
            }
        }
    }
}