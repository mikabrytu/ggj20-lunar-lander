using UnityEngine;
using Mikabrytu.GGJ20.Events;

namespace Mikabrytu.GGJ20.Components
{
    public class StationComponent : MonoBehaviour
    {
        [SerializeField] private StationModel _model;
        [SerializeField] private int _layerCheck;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (_model.id == 0)
                return;
                
            if (collision.gameObject.layer == _layerCheck)
                EventsManager.Raise(new OnLandOnStationEvent(_model));
        }
    }
}
