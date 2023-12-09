using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] Animator transisiAnimator;
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            Application.targetFrameRate = 60;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(1);
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            MovingScene("Mainmenu");
        }
    }

    public void MovingScene(string nameScene)
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            transisiAnimator.gameObject.SetActive(true);
            transisiAnimator.SetTrigger("Start");
            yield return new WaitForSeconds(1.5f);

            if (nameScene == "Quit") Application.Quit();
            else SceneManager.LoadScene(nameScene);

            yield return new WaitForSeconds(1.5f);
            transisiAnimator.SetTrigger("Exit");
            yield return new WaitForSeconds(1.5f);
            transisiAnimator.gameObject.SetActive(false);
        }
    }
}
