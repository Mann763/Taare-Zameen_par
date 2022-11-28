using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip planetGrab;
    public AudioClip planetDestroy;
    public AudioClip buttonClick;

    public static AudioManager instance;

    void Awake()
    {
        if(instance == null)
         {
             instance = this;
             DontDestroyOnLoad(gameObject);
         }
         else if (instance != this)
         {
             Destroy(gameObject);
         }   
    }
}
