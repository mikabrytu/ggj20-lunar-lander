using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mikabrytu.GGJ20.Events
{
    public class OnLandOnStationEvent : BaseEvent
    {
        public StationModel stationModel;

        public OnLandOnStationEvent(StationModel stationModel)
        {
            this.stationModel = stationModel;
        }
    }
}
