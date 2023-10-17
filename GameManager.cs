using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int blocksLeft;

    //Declaracion de Singleton
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        blocksLeft = GameObject.FindGameObjectsWithTag("Block").Length;
    }

    public void BlockDestroyed()
    {
        blocksLeft--;
        if(blocksLeft <= 0)
        {
            LoadNextLevel();
        }
    }


   private void LoadNextLevel()
   {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        if(buildIndex == 3)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(buildIndex + 1);
        }
   }

    public void ReloadScene()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
