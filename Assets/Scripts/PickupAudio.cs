using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAudio : MonoBehaviour
{
    private AudioSource _source;

    private Pickup _pickup;
    // Start is called before the first frame update
    void Start()
    {
        _source = GetComponent<AudioSource>();
        _pickup = GetComponent<Pickup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_pickup.IsCollected)
        {
            _source.enabled = false;
        }
    }
}
