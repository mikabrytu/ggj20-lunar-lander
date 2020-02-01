using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mikabrytu.GGJ20.Systems;

namespace Mikabrytu.GGJ20.Components
{
    public class RocketComponent : MonoBehaviour
    {
        [SerializeField] private Vector2 _initialImpulse;
        [SerializeField] private Vector2 _thrusterForce;
        [SerializeField] private LayerMask _groundMask;

        private IFly flySystem;
        private IGroundCheck groundCheckSystem;

        private Rigidbody2D body;
        private new BoxCollider2D collider;
        private bool isGrounded = false;

        private void Start()
        {
            body = GetComponent<Rigidbody2D>();
            collider = GetComponent<BoxCollider2D>();

            flySystem = new FlySystem();
            groundCheckSystem = new GroundCheckSystem();

            flySystem.Setup(_initialImpulse, _thrusterForce);
        }

        private void Update()
        {
            
        }

        public void OnLeftClick()
        {
            flySystem.Impulse(body, Vector2.left, isLanded());
        }

        public void OnRightClick()
        {
            flySystem.Impulse(body, Vector2.right, isLanded());
        }

        private bool isLanded()
        {
            return groundCheckSystem.IsGrounded(collider, Vector2.down, _groundMask, .05f);
        }
    }
}
