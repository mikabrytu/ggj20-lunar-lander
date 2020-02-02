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
        [SerializeField] private int _stationLayer;

        private IFly flySystem;
        private IGroundCheck groundCheckSystem;

        private new BoxCollider2D collider;
        private Rigidbody2D body;
        private Transform nextStation;
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

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer == _stationLayer)
                nextStation = collider2D.transform;
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

        public float GetFuel()
        {
            return flySystem.GetFuel() / 100;
        }

        public Transform GetNextVisibleStation()
        {
            return nextStation;
        }

        public void OnLeftClick()
        {
            ActivateThrusters(true);
            flySystem.Impulse(body, Vector2.left, isLanded());
        }

        public void OnRightClick()
        {
            ActivateThrusters(true);
            flySystem.Impulse(body, Vector2.right, isLanded());
        }

        public void ActivateThrusters(bool active)
        {
            if (active)
            {
                if (!_thrusterParticle.isPlaying)
                    _thrusterParticle.Play();
            }
            else
            {
                _thrusterParticle.Stop();
            }
        }

        private bool isLanded()
        {
            return groundCheckSystem.IsGrounded(collider, Vector2.down, _stationMask, .05f);
        }
    }
}
