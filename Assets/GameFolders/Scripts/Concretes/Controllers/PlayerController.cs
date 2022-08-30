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
        Fuel _fuel;

        bool _canForceUp;
        float _leftRight;
        public float _turnSpeed;



        private void Awake()
        {
            _rotator = new Rotator(this);
            _Input = new DefaultInput();
            _mover = new Mover(rigidbody: GetComponent<Rigidbody>());
            _fuel =GetComponent<Fuel>();
        }



        // Update is called once per frame
        void Update()
        {
            //Updateler ile input alýrýz...
            Debug.Log(_Input.LeftRight);

            if (_Input.IsForceUp && !_fuel.IsEmpty) 
            {
                _canForceUp = true;
            }
            else
            {
                _canForceUp = false;
                _fuel.FuelIncrease(0.02f);
            }

            _leftRight=_Input.LeftRight;

        }

        private void FixedUpdate()
        {
            //Fizik iþlemlerini yaparýz...
            if (_canForceUp)
            {
                _mover.FixedTick();
                _fuel.FuelDecrease(0.2f);
            }

            _rotator.FixedTick(_leftRight);



        }


    }




}

