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

        bool _isForceUp;



        private void Awake()
        {
            _Input = new DefaultInput();
            _mover = new Mover(rigidbody: GetComponent<Rigidbody>());
        }



        // Update is called once per frame
        void Update()
        {
            //Updateler ile input alýrýz...
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
            //Fizik iþlemlerini yaparýz...
            if (_isForceUp)
            {
                _mover.FixedTick();
            }

          

        }


    }




}

