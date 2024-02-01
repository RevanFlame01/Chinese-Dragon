using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSystem : MonoBehaviour
{
   public GameObject Tutorial1;
   public GameObject Tutorial2;
   public int tutStatus;

   private void Start()
   {
      tutStatus = PlayerPrefs.GetInt("Tutorial");
   }

   private void Update()
   {
      tutStatus = PlayerPrefs.GetInt("Tutorial");
   }

   public void SkipTutorial1()
   {
      Tutorial1.SetActive(false);
      Tutorial2.SetActive(true);
   }

   public void ExitTutorial()
   {
      gameObject.SetActive(false);
      tutStatus = 1;
      PlayerPrefs.SetInt("Tutorial",tutStatus);
   }
}
