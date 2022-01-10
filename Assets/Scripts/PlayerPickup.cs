using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [Header("References")] 
    [SerializeField] private GameObject gUI;

    [SerializeField] private GameObject exitController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Pickup>())
        {
            var score = other.GetComponent<Pickup>().GetPickedUp();
            if (score == -1) return;
            gUI.GetComponent<UIManager>().UpdateScore(score);
            exitController.GetComponent<ExitController>().StarCollected(other.gameObject);
        }
    }
}
