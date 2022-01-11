using System;
using System.Collections.Generic;
using Code.InteractableObjects;
using Code.PlayerControllers;
using Code.Utils;
using UnityEngine;

namespace Code
{
    public class CollectableItemsManager : MonoBehaviour
    {
        [SerializeField] private Collector collector;
        [SerializeField] private List<Cheese> cheeses;

        public void Init()
        {
            foreach (var cheese in cheeses.ChooseManyUnique(collector.CollectedTarget + 1))
            {
                cheese.gameObject.SetActive(true);
            }
        }
    }
}