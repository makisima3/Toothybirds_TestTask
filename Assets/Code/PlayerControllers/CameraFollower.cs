using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.PlayerControllers
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private Vector3 shoulderOffset;
        [SerializeField] private Vector3 cameraOffset;
        
        [SerializeField] private Transform followTarget;
        [SerializeField] private Transform cameraTransform;

        [SerializeField] private Transform requiredPoint;
        [SerializeField] private Transform cameraPoint;
        [SerializeField] private LayerMask cameraBordersMask;
        [SerializeField] private float maxDistance;

        [Range(0f, 10f)]
        [SerializeField] private float smooth = 0.1f;

        private void Awake()
        {
            maxDistance = Vector3.Distance(transform.position, cameraPoint.position);
        }

        private void Update()
        {
            if(followTarget == null)
                return;

            transform.position = followTarget.position + shoulderOffset;
            
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, cameraPoint.position, smooth * Time.deltaTime);
            cameraTransform.rotation = Quaternion.Lerp(cameraTransform.rotation, cameraPoint.rotation, smooth * Time.deltaTime);
        }

        public void RotateCamera()
        {
            //fit shoulder rotation
            var rotation = followTarget.eulerAngles;
            rotation.x = transform.eulerAngles.x;
            rotation.z = transform.eulerAngles.z;
            transform.eulerAngles = rotation;


            //var requiredPosition = followTarget.position + shoulderOffset + cameraOffset;
            
            var targetPosition = followTarget.position + shoulderOffset;
            var direction = (requiredPoint.position -  targetPosition).normalized;
            var ray = new Ray(targetPosition ,direction);
            
            Debug.DrawRay(ray.origin,ray.direction, Color.magenta,10f);

            var hasCollision = Physics.SphereCast(ray, 0.1f, out var hit, maxDistance, cameraBordersMask);
            cameraPoint.position = hasCollision ? hit.point : ray.GetPoint(maxDistance);
            
            //FitCamera(true);
        }

        private void FitCamera(bool immediate = false)
        {
            if (immediate)
            {
                cameraTransform.position = cameraPoint.position;
                cameraTransform.rotation = cameraPoint.rotation;
                return;
            }
            
            //TODO: dotween move
        }
        
        private void OnValidate()
        {
            if(followTarget == null || cameraPoint == null || cameraTransform == null)
                return;

            transform.position = followTarget.position + shoulderOffset;
            cameraPoint.localPosition = cameraOffset;

            FitCamera(true);
        }
    }
}