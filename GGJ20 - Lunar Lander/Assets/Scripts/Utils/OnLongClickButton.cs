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
        [SerializeField] private UnityEvent _onRelease;

        private bool isPressing = false;

        private void Update()
        {
            if (isPressing)
                _onLongClick.Invoke();
        }

        private void OnDisable()
        {
            isPressing = false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            isPressing = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isPressing = false;
            _onRelease?.Invoke();
        }
    }
}
