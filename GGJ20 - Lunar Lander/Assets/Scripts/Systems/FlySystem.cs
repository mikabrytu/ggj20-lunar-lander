using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mikabrytu.GGJ20.Systems
{
    public class FlySystem : IFly
    {
        private Vector2 initialImpulse;
        private Vector2 thrusterForce;
        private float maxFuel;
        private float currentFuel;
        private float impulseCost;

        public void SetupForces(Vector2 initialImpulse, Vector2 thrusterForce)
        {
            this.initialImpulse = initialImpulse;
            this.thrusterForce = thrusterForce;
        }

        public void SetupFuel(float maxFuel, float impulseCost)
        {
            this.maxFuel = maxFuel;
            this.impulseCost = impulseCost;

            ResetFuel();
        }

        public void Impulse(Rigidbody2D body, Vector2 direction, bool isLanded)
        {
            if (currentFuel <= 0)
                return;

            if (isLanded)
            {
                body.velocity = Vector2.zero;
                body.AddForce(initialImpulse, ForceMode2D.Impulse);
                return;
            }

            Vector2 force = new Vector2(thrusterForce.x * direction.x, thrusterForce.y);
            body.AddRelativeForce(force, ForceMode2D.Force);
            currentFuel -= impulseCost;
        }

        public void ResetFuel()
        {
            currentFuel = maxFuel;
        }

        public float GetFuel()
        {
            return (currentFuel * 100) / maxFuel;
        }
    }
}
