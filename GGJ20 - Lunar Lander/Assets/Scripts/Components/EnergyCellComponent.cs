using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mikabrytu.GGJ20.Components
{
    public class EnergyCellComponent : MonoBehaviour
    {
        [SerializeField] private int _rocketLayer;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.layer == _rocketLayer)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
