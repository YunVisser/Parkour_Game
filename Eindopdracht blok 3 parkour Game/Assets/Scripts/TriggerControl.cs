using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TriggerControl : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("Entering the" + other.gameObject.name);
    }

    private void OnTriggerStay(Collider other)
    {
        print("In the" + other.gameObject.name);
        
    }
    private void OnTriggerExit(Collider other)
    {
        print("Exit the" + other.gameObject.name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }


}