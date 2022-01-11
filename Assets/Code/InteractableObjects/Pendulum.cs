using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Code.InteractableObjects
{
    public class Pendulum : MonoBehaviour
    {
        [SerializeField] private float angle;
        [SerializeField] private Ease ease = Ease.OutQuad;
        [SerializeField] private float timeToMove;
        [SerializeField] private SnapAxis axisOptions;

        private Dictionary<SnapAxis, Vector3> axisToVector3;

        private void Start()
        {
            axisToVector3 = new Dictionary<SnapAxis, Vector3>()
            {
                {SnapAxis.X, Vector3.right},
                {SnapAxis.Y, Vector3.up},
                {SnapAxis.Z, Vector3.forward}
            };
            
            transform.DORotate(axisToVector3[axisOptions] * angle * -1, 0f);
            DOTween.Sequence()
                .Append(transform.DORotate(axisToVector3[axisOptions] * angle, timeToMove).SetEase(ease))
                .Append(transform.DORotate(axisToVector3[axisOptions] * angle * -1, timeToMove).SetEase(ease))
                .SetLoops(-1)
                .Play();
        }
    }
}