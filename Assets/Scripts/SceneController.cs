using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [Header("References")] 
    [SerializeField] private int nextScene;
    

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(nextScene);
    }
}
