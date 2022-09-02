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
        [SerializeField] Rigidbody _playerRigidbody;

        [SerializeField] GameObject _PausePanel;

        Mover _mover;
        DefaultInput _Input;
        Rotator _rotator;
        Fuel _fuel;


        bool _canMove;
        bool _canForceUp;
        float _leftRight;

        public float _turnSpeed;
        public bool CanMove => _canMove;



        private void Awake()
        {
            _rotator = new Rotator(this);
            _Input = new DefaultInput();
            _mover = new Mover(GetComponent<Rigidbody>());
            _fuel =GetComponent<Fuel>();


        }
        private void Start()
        {
            _canMove = true;
        }


        // Update is called once per frame
        //Updateler ile input al�r�z...
        void Update()
        {
            if (_Input.IsPause)
            {
                Time.timeScale = 0f;
                _PausePanel.SetActive(true);

            }

            else if (!_Input.IsPause)
            {
                Time.timeScale = 1f;
                _PausePanel.SetActive(false);
            }

    
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
            GameManager.Instance.OnGameOver += HandleOnEventTriggerGameOver;
            GameManager.Instance.OnMissionSucced += HandleOnEventTriggerMissionOver;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnGameOver -= HandleOnEventTriggerGameOver;
            GameManager.Instance.OnMissionSucced -= HandleOnEventTriggerMissionOver;
        }

        private void HandleOnEventTriggerGameOver()
        {
            //_playerRigidbody.constraints = RigidbodyConstraints.FreezeAll;          
            _playerRigidbody.useGravity = false;                   
            _canMove = false;
            _canForceUp = false;
            _leftRight = 0f;
            _fuel.FuelIncrease(0f);
        }

        private void HandleOnEventTriggerMissionOver()
        {
            //_playerRigidbody.constraints = RigidbodyConstraints.FreezeAll;          
            _playerRigidbody.constraints = RigidbodyConstraints.FreezePosition;
            _canMove = false;
            _canForceUp = false;
            _leftRight = 0f;
            _fuel.FuelIncrease(0f);
        }

    
    }




}

