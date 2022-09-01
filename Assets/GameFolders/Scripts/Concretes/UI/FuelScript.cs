using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UdemyProject1.Movements;


namespace UdemyProject1.UI
{
    public class FuelScript : MonoBehaviour
    {
        Slider _fuelSlider;
        Fuel _fuel;

        private void Awake()
        {
            _fuelSlider = GetComponent<Slider>();
            _fuel =FindObjectOfType<Fuel>();
        }

        private void Update()
        {
            _fuelSlider.value = _fuel.CurrentFuel;
        }
    }
}


