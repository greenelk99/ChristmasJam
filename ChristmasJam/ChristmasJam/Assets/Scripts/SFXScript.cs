using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXScript : MonoBehaviour
{
    [SerializeField] AudioSource grinchDeath;
    [SerializeField] AudioSource presentBreak;

    static bool isCreated = false;

    void Start()
    {
        if (!isCreated)
        {
            DontDestroyOnLoad(gameObject);
            isCreated = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Update()
    {

    }

    public void PlaySound(string soundName)
    {
        switch (soundName)
        {
            case "grinchDeath":
                grinchDeath.Play();
                break;
            case "presentBreak":
                presentBreak.Play();
                break;
        }
    }
}
