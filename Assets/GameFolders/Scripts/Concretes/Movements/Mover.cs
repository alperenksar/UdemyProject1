using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UdemyProject1.Movements
{
    public class Mover : MonoBehaviour
    {
        Rigidbody _rigidbody;

        public Mover(Rigidbody rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public void FixedTick()
        {
            _rigidbody.AddRelativeForce(Vector3.up * Time.deltaTime * 1000f);
        }


    }

}
