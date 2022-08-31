using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyProject1.Managers; 


namespace UdemyProject1.UI
{
    public class GameOverPanel : MonoBehaviour
    {
        public void YesClick()
        {
            GameManager.Instance.LoadLevelScene(0);

        }

        public void NoClick()
        {
            GameManager.Instance.LoadMenuScene();
        }


    }



}
