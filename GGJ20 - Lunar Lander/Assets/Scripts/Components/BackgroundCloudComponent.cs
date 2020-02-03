using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mikabrytu.GGJ20.Components
{
    public class BackgroundCloudComponent : MonoBehaviour
    {
        [SerializeField] private Transform _startPosition;
        [SerializeField] private Transform _endPosition;
        [SerializeField] private float _velocity;

        private void Update()
        {
            // TODO: Extract a System of this
            transform.Translate(Vector2.left * _velocity * Time.deltaTime);

            if (transform.position.x < _endPosition.position.x)
                transform.position = _startPosition.position;
        }
    }
}
