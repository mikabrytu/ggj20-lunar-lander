using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mikabrytu.GGJ20.Events
{
    public class OnLandOnStationEvent : BaseEvent
    {
        public StationModel stationModel;
        public Vector2 stationPosition;

        public OnLandOnStationEvent(StationModel stationModel, Vector2 stationPosition)
        {
            this.stationModel = stationModel;
            this.stationPosition = stationPosition;
        }
    }
}
