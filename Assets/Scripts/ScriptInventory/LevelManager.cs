using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
    
{
    


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
    public void StartGame()
    {
        SceneManager.LoadScene(3);
    }





}
