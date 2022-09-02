using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UdemyProject1.Managers;
using UdemyProject1.Controllers;
using UdemyProject1.Input;




namespace UdemyProject1.UI
{
    public class EscPanelScript : MonoBehaviour
    {
        [SerializeField] GameObject _pausePanel;
        DefaultInput _Input;



        public void TurnMenu()
        {
            GameManager.Instance.LoadMenuScene();
        }

     
        public void ExitGame()
        {
            GameManager.Instance.Exit();
        }



    }

}
