using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mikabrytu.GGJ20.Systems;

namespace Mikabrytu.GGJ20.Components
{
    public class CameraComponent : MonoBehaviour, ICamera
    {
        [SerializeField] private List<Transform> _targets;
        [SerializeField] private Vector3 _offset;

        private IMoveCamera moveCameraSystem;
        private IZoomCamera zoomCameraSystem;
        
        private Transform cameraTransform;

        private void Start()
        {
            cameraTransform = transform;

            moveCameraSystem = new MoveCameraSystem();
            zoomCameraSystem = new ZoomCameraSystem();

            moveCameraSystem.Setup(_offset);
        }

        private void LateUpdate()
        {
            moveCameraSystem.Move(cameraTransform, _targets);
            zoomCameraSystem.Zoom();
        }

        public void UpdateTargets(Transform newTarget)
        {
            Transform rocket = _targets.Find(t => t.name == "Rocket");

            _targets.Clear();
            _targets.Add(rocket);
            _targets.Add(newTarget);
        }
    }
}
