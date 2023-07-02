using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
    
{
    public float delayTime = 5f; //pam


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(3);

    }
    public void InstructionsGame()
    {
        SceneManager.LoadScene(1);
    }
    public void CreditsGame()
    {
        SceneManager.LoadScene(2);
    }
    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void PlayCinematica()
    {
        StartCoroutine(LoadSceneWithDelay()); //pame
        //SceneManager.LoadScene(5);
    }

   private IEnumerator LoadSceneWithDelay() //pam
    {
        yield return new WaitForSeconds(delayTime);

        SceneManager.LoadScene(5);
    }



}
