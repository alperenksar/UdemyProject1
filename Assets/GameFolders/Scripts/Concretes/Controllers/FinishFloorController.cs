using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyProject1.Managers;


namespace UdemyProject1.Controllers
{
    public class FinishFloorController : MonoBehaviour
    {
        [SerializeField] GameObject _endEffect;
        private void OnCollisionEnter(Collision collision)
        {
            PlayerController player = collision.collider.GetComponent<PlayerController>();

            if (player == null || !player.CanMove) 
            {
                return;
            }

            if (collision.GetContact(0).normal.y == -1)
            {
                _endEffect.SetActive(true);
                GameManager.Instance.MissionSucced();

            }
            else
            {
                GameManager.Instance.GameOver();
            }
        }

    }


}
