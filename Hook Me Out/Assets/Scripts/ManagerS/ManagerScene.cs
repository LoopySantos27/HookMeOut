using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{

    public static ManagerScene instance;

    [SerializeField]
    private GameObject canvasPause;
    private bool _isPaused;
    [SerializeField]
    private GameObject WinDemo;

    Scene activeScene;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
        //AudioManager.instance.Play("MusicMenu");
    }


    public void GoToPlay()
    {
        AudioManager.instance.Play("ButtonPlay");
        AudioManager.instance.StopMusic("MusicMenu");
        SceneManager.LoadScene(1);
        //StartCoroutine(PlaySound());
    }

    public void GoToMenu()
    {
        AudioManager.instance.Play("CanvasButton");
        SceneManager.LoadScene(0);
    }

    public void PauseGameplay()
    {
        _isPaused = !_isPaused;
        if(_isPaused)
        {
            
            AudioManager.instance.StopMusic("MusicGameplay");
            Time.timeScale = 0;
            canvasPause.SetActive(true);
        }
        else
        {
            canvasPause.SetActive(false);
            AudioManager.instance.Play("MusicGameplay");
            Time.timeScale = 1;
        }
        
    }

    IEnumerator PlaySound()
    {
       yield return  new WaitForSeconds(1f);
       SceneManager.LoadScene(1);
    }
}
