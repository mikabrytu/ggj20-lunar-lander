using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mikabrytu.GGJ20.Systems
{
    public class FlySystem : IFly
    {
        private Vector2 initialImpulse;
        private Vector2 thrusterForce;

        public void Setup(Vector2 initialImpulse, Vector2 thrusterForce)
        {
            this.initialImpulse = initialImpulse;
            this.thrusterForce = thrusterForce;
        }

        public void Impulse(Rigidbody2D body, Vector2 direction, bool isLanded)
        {
            if (isLanded)
            {
                body.AddForce(initialImpulse, ForceMode2D.Impulse);
                return;
            }

            body.AddRelativeForce(thrusterForce * direction, ForceMode2D.Force);
            //Debug.Log($"Adding Relative {thrusterForce} Force");
        }
    }
}
