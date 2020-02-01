using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Mikabrytu.GGJ20
{
    public class OnLongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private UnityEvent _onLongClick;

        private bool isPressing = false;

        private void Update()
        {
            if (isPressing)
                _onLongClick.Invoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            isPressing = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isPressing = false;
        }
    }
}
