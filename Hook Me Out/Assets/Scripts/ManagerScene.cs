using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    public SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ResetLevel()
    {

    }
    public void GoToPlay()
    {
        soundManager.PlayButton();
        StartCoroutine(PlaySound());
        
    }

    IEnumerator PlaySound()
    {
       yield return  new WaitForSeconds(1f);
       SceneManager.LoadScene(1);
    }
}
