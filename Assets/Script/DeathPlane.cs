using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlane : MonoBehaviour
{
   private void OnCollisionEnter(Collision collision)
   {
      var currentSceneName = SceneManager.GetActiveScene().name;
      SceneManager.LoadSceneAsync(currentSceneName);
   }
}
