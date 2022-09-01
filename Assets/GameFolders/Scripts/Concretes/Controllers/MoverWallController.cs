using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyProject1.Abstracts.Controllers;

namespace UdemyProject1.Controllers
{
    public class MoverWallController : WallController
    {
        [SerializeField] Vector3 _direction;

        [Range(0f, 1f)]
        [SerializeField] float _factor;

        [SerializeField] float _speed = 1f;

        const float _fullCircle = Mathf.PI * 2f;

        //const deðiþtirilemeyen bir deðerdir...


        Vector3 _startPos;

        private void Awake()
        {
            _startPos = transform.position;
        }

        private void Update()
        {
            float cycle = Time.time / _speed;

            float SinWave =Mathf.Sin( cycle * _fullCircle);

            _factor =Mathf.Abs( SinWave);


            Vector3 offset = _direction * _factor;

            transform.position = offset + _startPos;
        }



    }

}