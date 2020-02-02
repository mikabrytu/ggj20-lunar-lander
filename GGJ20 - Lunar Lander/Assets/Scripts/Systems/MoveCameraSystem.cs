using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mikabrytu.GGJ20.Systems
{
    public class MoveCameraSystem : IMoveCamera
    {
        private Vector3 offset;
        private Vector3 velocity;
        private float smoothTime = .5f;

        public void Setup(Vector3 offset)
        {
            this.offset = offset;
        }
        
        public void Move(Transform transform, List<Transform> targets)
        {
            Vector3 center = GetCenterOfTargets(targets);
            Vector3 newPosition = center + offset;
            transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
        }

        private Vector2 GetCenterOfTargets(List<Transform> targets)
        {
            Bounds bounds = new Bounds(targets[0].position, Vector3.zero);
            
            foreach (Transform item in targets)
                bounds.Encapsulate(item.position);

            return bounds.center;
        }
    }
}
