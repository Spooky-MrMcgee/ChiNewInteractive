using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    LevelManager instance;

    private void Awake()
    {
        //set this script as a singleton instance
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void intro()
    {
        SceneManager.LoadScene("Intro");   
    }
    public void Day1()
    {
        SceneManager.LoadScene("Day1");
    }

    public void Day2()
    {
        SceneManager.LoadScene("Day2A");
    }
    public void Day3()
    {
        SceneManager.LoadScene("Day3");
    }



}
