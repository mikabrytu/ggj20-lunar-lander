using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mikabrytu.GGJ20
{
    public interface IFly
    {
        void SetupForces(Vector2 initialImpulse, Vector2 thrusterForce);
        void SetupFuel(float maxFuel, float impulseCost);
        void Impulse(Rigidbody2D body, Vector2 direction, ParticleSystem thrusterParticle, bool isLanded);
        void ResetFuel();
        float GetFuel();
    }
}
