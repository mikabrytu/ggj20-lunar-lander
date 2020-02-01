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

        private Rigidbody2D body;
        private BoxCollider2D collider;
        private bool isGrounded = false;

        private void Start()
        {
            body = GetComponent<Rigidbody2D>();
            collider = GetComponent<BoxCollider2D>();

            flySystem = new FlySystem();
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
            float distance = collider.bounds.extents.y + .05f;
            RaycastHit2D hit = Physics2D.Raycast(
                collider.bounds.center, Vector2.down, distance, _groundMask);
            return hit.collider != null;
        }
    }
}
