using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyProject1.Managers;

namespace UdemyProject1.Movements
{
    public class Fuel : MonoBehaviour
    {
        [SerializeField] float _maxFuel;
        [SerializeField] float _currentFuel;
        [SerializeField] ParticleSystem _particle;

        public bool IsEmpty => _currentFuel < 1f;
        public float CurrentFuel => _currentFuel / _maxFuel;


        private void Awake()
        {
            _currentFuel = _maxFuel;  
        }

        public void FuelIncrease(float increase)
        {
            _currentFuel += increase;
            _currentFuel = Mathf.Min(_currentFuel, _maxFuel);

            if (_particle.isPlaying)
            {
                _particle.Stop();
            }

            
            SoundManager.Instance.StopSound(2);



        }

        public void FuelDecrease(float decrease)
        {
            _currentFuel -= decrease;
            _currentFuel = Mathf.Max(_currentFuel, 0f);

            if (_particle.isStopped) 
            {
                _particle.Play();
            }
            SoundManager.Instance.PlaySound(2);



        }
    }
}

