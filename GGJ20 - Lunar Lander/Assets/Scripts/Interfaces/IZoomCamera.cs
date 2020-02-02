using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mikabrytu.GGJ20.Systems
{
    public interface IZoomCamera
    {
        void Setup(Camera camera, float minZoom, float maxZoom);
        void Zoom(List<Transform> targets);
    }
}
