using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject door;

    [SerializeField] private GameObject pickups;

    [SerializeField] private GameObject starPrefab;
    [SerializeField] private Transform starMap;
    
    private List<Transform> _stars;
    void Start()
    {
        _stars = new List<Transform>();
        for (int i = 0; i < pickups.transform.childCount; i++)
        {
            _stars.Add(pickups.transform.GetChild(i));
            var starPos = new Vector3(_stars[i].position.x / 5, (_stars[i].position.z+5) / 5 , 4.99f);
            Instantiate(starPrefab,starPos,Quaternion.Euler(0,90,0),starMap);
            //TODO create list to store Prefabs and use list to draw prefabs, if collected remove from list
            //TODO make door open when list is empty
        }
        
    }

    // Update is called once per frame
    
}
