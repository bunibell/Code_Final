using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Variables 
    public static GameManager instance;

    //private bool canstart = true;


    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        { 
            Destroy(gameObject);
        }
    }

    /*public void StartGame()
    {
        if (canstart)
        {
            SceneManager.LoadScene(1);
            canstart = false;
        }
    }*/
}