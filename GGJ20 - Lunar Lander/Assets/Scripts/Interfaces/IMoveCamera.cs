using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mikabrytu.GGJ20.Systems
{
    public interface IMoveCamera
    {
        void Setup(Vector3 offset);
        void Move(Transform transform, List<Transform> targets);
    }
}
