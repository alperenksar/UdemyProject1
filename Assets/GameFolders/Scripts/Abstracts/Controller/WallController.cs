using UnityEngine;
using UdemyProject1.Managers;
using UdemyProject1.Controllers;

namespace UdemyProject1.Abstracts.Controllers
{
    public abstract class WallController : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            PlayerController player = collision.collider.GetComponent<PlayerController>();

            if (player != null)
            {
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);               
                GameManager.Instance.GameOver();
            }
        }
    }
    // Abstract s�n�flar�n amac� miras vermektir.Ba�ka da bir amac� yoktur.
}
