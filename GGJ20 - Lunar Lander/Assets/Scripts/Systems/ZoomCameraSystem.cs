using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mikabrytu.GGJ20.Systems
{
    public class ZoomCameraSystem : IZoomCamera
    {
        private Camera camera;
        private float minZoom;
        private float maxZoom;

        public void Setup(Camera camera, float minZoom, float maxZoom)
        {
            this.camera = camera;
            this.minZoom = minZoom;
            this.maxZoom = maxZoom;
        }

        public void Zoom(List<Transform> targets)
        {
            float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance(targets) / 5);
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, newZoom, Time.deltaTime);
        }

        private float GetGreatestDistance(List<Transform> targets)
        {
            Bounds bounds = new Bounds(targets[0].position, Vector3.zero);
            foreach (Transform item in targets)
                bounds.Encapsulate(item.position);
            return bounds.size.x;
        }
    }
}
