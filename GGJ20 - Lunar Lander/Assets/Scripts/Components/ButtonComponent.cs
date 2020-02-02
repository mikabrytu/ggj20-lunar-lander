using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Mikabrytu.GGJ20.Components
{
    public class ButtonComponent : SerializedMonoBehaviour
    {
        [SerializeField] private ButtonAnimationTypes buttonType;

        private void OnEnable()
        {
            GetComponent<Animator>().SetInteger("Button ID", (int) buttonType);
        }
    }
}
