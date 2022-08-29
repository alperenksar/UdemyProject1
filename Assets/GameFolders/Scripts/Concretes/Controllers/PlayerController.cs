using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyProject1.Input;
using UdemyProject1.Movements;


namespace UdemyProject1.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        Mover _mover;
        DefaultInput _Input;
        Rotator _rotator;

        bool _isForceUp;
        float _leftRight;
        public float _turnSpeed;



        private void Awake()
        {
            _rotator = new Rotator(this);
            _Input = new DefaultInput();
            _mover = new Mover(rigidbody: GetComponent<Rigidbody>());
        }



        // Update is called once per frame
        void Update()
        {
            //Updateler ile input alýrýz...
            Debug.Log(_Input.LeftRight);

            if (_Input.IsForceUp)
            {
                _isForceUp = true;
            }
            else
            {
                _isForceUp = false;
            }

            _leftRight=_Input.LeftRight;

        }

        private void FixedUpdate()
        {
            //Fizik iþlemlerini yaparýz...
            if (_isForceUp)
            {
                _mover.FixedTick();
            }

            _rotator.FixedTick(_leftRight);



        }


    }




}

