using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mikabrytu.GGJ20.Events
{
    public class OnLandOnStationEvent : BaseEvent
    {
        public StationModel model;
        public Transform transform;

        public OnLandOnStationEvent(StationModel model, Transform transform)
        {
            this.model = model;
            this.transform = transform;
        }
    }
}
