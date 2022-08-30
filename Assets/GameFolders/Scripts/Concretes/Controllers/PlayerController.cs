using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyProject1.Input;
using UdemyProject1.Movements;
using UdemyProject1.Managers;


namespace UdemyProject1.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        Mover _mover;
        DefaultInput _Input;
        Rotator _rotator;
        Fuel _fuel;


        bool _canMove;
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
        private void Start()
        {
            _canMove = true;
        }


        // Update is called once per frame
        void Update()
        {
            //Updateler ile input al�r�z...

            //if (!_canMove)
            //{
            //    return;
            //}

            if (!_canMove) return;

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
            //Fizik i�lemlerini yapar�z...
            if (_canForceUp)
            {
                _mover.FixedTick();
                _fuel.FuelDecrease(0.2f);
            }

            _rotator.FixedTick(_leftRight);
        }


        private void OnEnable()
        {
            GameManager.Instance.OnGameOver += HandleOnEventTrigger;
            GameManager.Instance.OnMissionSucced += HandleOnEventTrigger;
        }

        private void HandleOnEventTrigger()
        {
            _canMove = false;
            _canForceUp = false;
            _leftRight = 0f;
            _fuel.FuelIncrease(0f);
        }

        private void OnDisable()
        {
            GameManager.Instance.OnGameOver -= HandleOnEventTrigger;
            GameManager.Instance.OnMissionSucced -= HandleOnEventTrigger;
        }


    }




}

