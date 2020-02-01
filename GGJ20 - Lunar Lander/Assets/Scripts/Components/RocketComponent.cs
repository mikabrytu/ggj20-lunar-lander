using UnityEngine;
using Mikabrytu.GGJ20.Systems;
using Mikabrytu.GGJ20.Events;

namespace Mikabrytu.GGJ20.Components
{
    public class RocketComponent : MonoBehaviour, IRocket
    {
        [SerializeField] private ParticleSystem _thrusterParticle;
        [SerializeField] private Vector2 _initialImpulse;
        [SerializeField] private Vector2 _thrusterForce;
        [SerializeField] private LayerMask _stationMask;
        [SerializeField] private float _maxFuel;
        [SerializeField] private float _impulseCost;
        [SerializeField] private int _groundLayer;

        private IFly flySystem;
        private IGroundCheck groundCheckSystem;

        private new BoxCollider2D collider;
        private Rigidbody2D body;
        private Vector2 landPosition;
        private bool isGrounded = false;

        private void Start()
        {
            body = GetComponent<Rigidbody2D>();
            collider = GetComponent<BoxCollider2D>();
            landPosition = transform.position;

            flySystem = new FlySystem();
            groundCheckSystem = new GroundCheckSystem();

            flySystem.SetupForces(_initialImpulse, _thrusterForce);
            flySystem.SetupFuel(_maxFuel, _impulseCost);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == _groundLayer)
                EventsManager.Raise(new OnRocketCrashEvent());
        }
        
        public void SetStationPosition(Vector2 position)
        {
            landPosition = new Vector2(position.x, position.y + collider.bounds.extents.y);
        }

        public void ResetPosition()
        {
            transform.position = landPosition;
        }

        public void ResetFuel()
        {
            flySystem.ResetFuel();
        }

        public string GetFuel()
        {
            return flySystem.GetFuel().ToString();
        }

        public void OnLeftClick()
        {
            flySystem.Impulse(body, Vector2.left, _thrusterParticle, isLanded());
        }

        public void OnRightClick()
        {
            flySystem.Impulse(body, Vector2.right, _thrusterParticle, isLanded());
        }

        private bool isLanded()
        {
            return groundCheckSystem.IsGrounded(collider, Vector2.down, _stationMask, .05f);
        }

    }
}
