using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mikabrytu.GGJ20
{
    public interface IGroundCheck
    {
        bool IsGrounded(Collider2D collider, Vector2 direction, LayerMask mask, float extra);
    }
}
