using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SFXScript : MonoBehaviour
{
    public int presentsAlive = 0;
    [SerializeField] AudioSource grinchDeath;
    [SerializeField] AudioSource presentBreak;
    [SerializeField] int minPresents;

    static bool isCreated = false;

    void Start()
    {
        //Console.WriteLine(presentsAlive);
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
        Console.WriteLine(presentsAlive);

        if(presentsAlive < minPresents)
        {
            DeadByPresents();
        }
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

    private void DeadByPresents()
    {
        Debug.Log("Dead by Presents");
    }

    public void LoadSceneByName(string name)
    {
        presentsAlive = 0;
        SceneManager.LoadScene(name);
    }
}
