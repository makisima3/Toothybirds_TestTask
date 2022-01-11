using UnityEngine;

namespace Code.PlayerControllers
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private Vector3 offset;
        [SerializeField] private Transform target;

        [Range(0f, 10f)]
        [SerializeField] private float smooth = 0.1f;
        
        [SerializeField] private float rotationSmooth = 50f;


        private void Update()
        {
            if(target == null)
                return;
            
            transform.position = Vector3.Lerp(transform.position, target.position + offset, smooth * Time.deltaTime);
            
            var targetRotation = target.eulerAngles.y;
            Debug.Log(targetRotation);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f,targetRotation,0f), rotationSmooth * Time.deltaTime);
        }

        private void OnValidate()
        {
            if(target == null)
                return;

            transform.position = target.position + offset;
        }
    }
}