using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
   
{
    public Transform player;
    public Transform BeginPunt;

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        player.GetComponent<CharacterController>().enabled=false;
        player.position = BeginPunt.position;
        player.GetComponent<CharacterController>().enabled = true;
    }
}


