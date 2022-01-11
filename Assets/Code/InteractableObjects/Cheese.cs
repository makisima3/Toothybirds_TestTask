using System;
using Code.Interfaces;
using UnityEngine;

namespace Code.InteractableObjects
{
    public class Cheese : MonoBehaviour, ICollectable
    {
        [SerializeField] private GameObject collectEffect;

        private void Update()
        {
            transform.rotation *= Quaternion.Euler(0f,0.5f,0f);
        }

        public void Collect()
        {
            if (collectEffect != null)
                Instantiate(collectEffect, transform.position, Quaternion.identity);
            
            Destroy(gameObject);
        }
    }
}