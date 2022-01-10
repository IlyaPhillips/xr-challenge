using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAudio : MonoBehaviour
{
    private AudioSource _source;

    private Pickup _pickup;
    
    void Start()
    {
        _source = GetComponent<AudioSource>();
        _pickup = GetComponent<Pickup>();
    }
    
    void Update()
    {
        if (_pickup.IsCollected)
        {
            _source.enabled = false;
        }
    }
}
