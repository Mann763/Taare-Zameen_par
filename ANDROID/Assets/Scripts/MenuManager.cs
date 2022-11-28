using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{ 
    public GameObject controller;
    public GameObject tutorialObject;
    public GameObject gameTitle;
    public GameObject colliderButton;

    void Update()
    {
         GameObject PL = GameObject.FindGameObjectWithTag("Planets");
         if (PL == null)
         {
             Debug.Log("Main Menu Starts");
             StartCoroutine(MainMenu());
         }
    }
    IEnumerator MainMenu()
    {
        yield return new WaitForSeconds(2f);
        tutorialObject.SetActive(false);
        controller.SetActive(false);
        gameTitle.SetActive(true);
        colliderButton.SetActive(true);

        //Remove the Collider

    }

    public void TriggerLevel()
    {
        SceneManager.LoadScene(1);

    }
}
