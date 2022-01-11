using System;
using Code.PlayerControllers;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Code.InteractableObjects
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private bool isMove;
        [SerializeField] private Transform[] points;
        [SerializeField] private float minDistanceToPoint = 1f;
        [SerializeField] private float speed = 1f;
        [SerializeField] private float timeToMove;
        
        private int index = 0;
        private Vector3 moveDirection;

        private Transform currentPoint => points[index];
        
        private void FixedUpdate()
        {
            moveDirection = (currentPoint.position - transform.position).normalized;

            transform.position = transform.position + (moveDirection * Time.deltaTime * speed);

            if (Vector3.Distance(transform.position, currentPoint.position) <= minDistanceToPoint)
            {
                index++;

                if (index >= points.Length)
                    index = 0;
            }
        }
    }
}