using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mikabrytu.GGJ20
{
    public interface IFly
    {
        void Setup(Vector2 initialImpulse, Vector2 thrusterForce);
        void Impulse(Rigidbody2D body, Vector2 direction, bool isLanded);
    }
}
