using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UdemyProject1.Abstracts.Utilities;



namespace UdemyProject1.Managers
{
    public class GameManager : SingletonThisObject<GameManager>
    {

        public event System.Action OnGameOver;
        public event System.Action OnMissionSucced;


        private void Awake()
        {
            SingletonThisGameObject(this);
        }

        public void GameOver()
        {
            OnGameOver?.Invoke();

            //if (OnGameOver != null)
            //{
            //    GameOver();
            //}
        }

        public void MissionSucced()
        {
            OnMissionSucced?.Invoke();
        }

        public void LoadLevelScene(int levelindex = 0)
        {
            StartCoroutine(LoadLevelSceneAsync(levelindex));
        }

        private IEnumerator LoadLevelSceneAsync(int levelindex)
        {
            yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+levelindex);
        }

        public void LoadMenuScene()
        {
            StartCoroutine("LoadMenuSceneAsync");
        }

        IEnumerator LoadMenuSceneAsync()
        {
            yield return SceneManager.LoadSceneAsync("Menu");
        }


        public void Exit()
        {
            Debug.Log("Exit process on triggered");
            Application.Quit();
        }

    }


}
