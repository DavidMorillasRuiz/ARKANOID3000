using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Declaracion de Singleton
    public static AudioManager Instance;

    [Header("Audio CLip Array")]
    public AudioClip[] musicList;

    [Header("Audio Source Reference")]
    [SerializeField] AudioSource musicSource;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(int musicIndex)
    {
        musicSource.clip = musicList[musicIndex];
        musicSource.Play();
    }

}
