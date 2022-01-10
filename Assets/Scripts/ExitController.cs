using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject door;

    [SerializeField] private GameObject exitZone; 

    [SerializeField] private GameObject pickups;

    [SerializeField] private GameObject starPrefab;
    [SerializeField] private Transform starMap;
    
    private List<Transform> _stars; //list of transforms of the actual positions of the stars
    private List<GameObject> _starMarkers; // list of the star markers that appear on the door 
    private int _starCounter;
    void Start()
    {
        _stars = new List<Transform>();
        _starMarkers = new List<GameObject>();
        for (int i = 0; i < pickups.transform.childCount; i++)
        {
            _stars.Add(pickups.transform.GetChild(i));
            var starPos = new Vector3(_stars[i].position.x / 5, (_stars[i].position.z+5) / 5 , 4.99f);
            _starMarkers.Add(Instantiate(starPrefab,starPos,Quaternion.Euler(0,90,0),starMap));
        }
        
    }
/// <summary>
/// gets called from the player pickup class on collection of a star
/// increments the star collected counter
/// if all stars are collected opens the door
/// the star map sets the stars to inactive rather than deleting them
/// the stars could be set to reactivate on Pickup.Init() for a live updated position
/// </summary>
/// <param name="collected"></param>
    public void StarCollected(GameObject collected)
    {
        
        for (int i = 0; i < _stars.Count; i++)
        {
            if (collected != _stars[i].gameObject) continue;
            _starMarkers[i].SetActive(false);
            _starCounter++;
            if (_starCounter >= _stars.Count)
            {
                ActivateExit();
            }

            break;
        }
    }

    private void ActivateExit()
    {
        door.SetActive(false);
        exitZone.SetActive(true);
    }
}
