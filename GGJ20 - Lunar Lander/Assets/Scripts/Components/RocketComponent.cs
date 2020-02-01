using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mikabrytu.GGJ20.Systems;

namespace Mikabrytu.GGJ20.Components
{
    public class RocketComponent : MonoBehaviour
    {
        private IFly flySystem;
        private IInput inputSystem;

        private void Start()
        {
            flySystem = new FlySystem();
            inputSystem = new InputSystem();
        }
    }
}
