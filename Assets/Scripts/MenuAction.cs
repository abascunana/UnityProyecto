using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.XR.Interaction.Toolkit.InputHelpers;
using static UnityEngine.XR.OpenXR.Features.Interactions.OculusTouchControllerProfile;
 using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

    // ...
public class MenuAction : MonoBehaviour
{  private bool menuButtonPreviousState = false;
    public UnityEngine.XR.Interaction.Toolkit.XRRayInteractor rayInteractor;
    public GameObject player;
    //menu
    public GameObject menu;
    public AudioSource sound;
 
    public GameObject[] sites;
    public GameObject[] categories;

     public void ChangeCategory(int num){
        Debug.Log("Category: " + num);
        for( int i = 0; i<categories.Length; i++){
         categories[i].SetActive(false);
           
        }
        categories[num].SetActive(true);
        Debug.Log("Category: " + categories[num].name);
  }
    
    public void GoSite(int num){
        for( int i = 0; i<sites.Length; i++){
         sites[i].SetActive(false);
           
        }
        sites[num].SetActive(true);
    }

     public void playButton(){
    sound.Play();
   }
   
  //Button handling
    void Update()
    {
        bool menuButtonCurrentState;
        if (UnityEngine.XR.InputDevices.GetDeviceAtXRNode(UnityEngine.XR.XRNode.LeftHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.menuButton, out menuButtonCurrentState))
        {
            if (menuButtonCurrentState && !menuButtonPreviousState)
            {
                Debug.Log("Menu button pressed!");
                if(menu != null)
                {
                    menu.SetActive(!menu.activeSelf);
                }
    
            }
            menuButtonPreviousState = menuButtonCurrentState;
        }
    }

   
}
