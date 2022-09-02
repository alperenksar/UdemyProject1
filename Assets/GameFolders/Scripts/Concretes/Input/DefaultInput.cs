using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UdemyProject1.Input
{
    public class DefaultInput : MonoBehaviour
    {
        DefaultAction _Input;
        public bool IsForceUp { get; private set; }

        public float LeftRight { get; private set; }

        public bool IsPause { get; private set; }


        public DefaultInput()
        {
            _Input = new DefaultAction();

            _Input.Rocket.ForceUp.performed += context => IsForceUp = context.ReadValueAsButton();

            _Input.Rocket.LeftRight.performed += context => LeftRight = context.ReadValue<float>();

            _Input.Rocket.IsPause.performed += context => IsPause = context.ReadValueAsButton();

            _Input.Enable();
        }
            






    }

}







