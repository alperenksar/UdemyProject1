using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyProject1.Input;


namespace UdemyProject1.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _force;
        Rigidbody _rocketRb;
        DefaultInput _Input;

        bool _isForceUp;



        private void Awake()
        {
            _rocketRb = GetComponent<Rigidbody>();
            _Input = new DefaultInput();
        }



        // Update is called once per frame
        void Update()
        {
            //Updateler ile input al�r�z...
            if (_Input.IsForceUp)
            {
                _isForceUp = true;
            }
            else
            {
                _isForceUp = false;
            }

        }

        private void FixedUpdate()
        {
            //Fizik i�lemlerini yapar�z...
            if (_isForceUp)
            {
                _rocketRb.AddForce(Vector3.up * Time.deltaTime*_force);
            }

          

        }


    }




}

