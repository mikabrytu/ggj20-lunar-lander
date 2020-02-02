using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mikabrytu.GGJ20.Components
{
    public interface IRocket
    {
        void SetStationPosition(Vector2 position);
        void ResetPosition();
        void ResetFuel();
        string GetFuel();
        Transform GetNextVisibleStation();
    }
}
