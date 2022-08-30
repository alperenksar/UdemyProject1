using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UdemyProject1.Controllers
{
    public class FinishFloorController : MonoBehaviour
    {
        [SerializeField] GameObject _endEffect;
        private void OnCollisionEnter(Collision collision)
        {
            PlayerController player = collision.collider.GetComponent<PlayerController>();

            if (player == null)
            {
                return;
            }

            if (collision.GetContact(0).normal.y == -1)
            {
                _endEffect.SetActive(true);
            }
        }

    }


}
