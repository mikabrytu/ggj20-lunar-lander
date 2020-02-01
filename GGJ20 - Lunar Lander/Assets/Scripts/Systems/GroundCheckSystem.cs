using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mikabrytu.GGJ20.Systems
{
    public class GroundCheckSystem : IGroundCheck
    {
        public bool IsGrounded(Collider2D collider, Vector2 direction, LayerMask mask, float extra)
        {
            float distance = collider.bounds.extents.y + extra;
            RaycastHit2D hit = Physics2D.Raycast(collider.bounds.center, direction, distance, mask);
            return hit.collider != null;
        }
    }
}
