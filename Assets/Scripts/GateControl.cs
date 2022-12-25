using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateControl : MonoBehaviour
{
    // Declare three game objects to represent the keys
    public GameObject key1;
    public GameObject key2;
    public GameObject key3;

    // Declare a game object to represent the gate
    public GameObject gate;

    // Declare three boolean variables to track whether each key is in place
    private bool key1InPlace = false;
    private bool key2InPlace = false;
    private bool key3InPlace = false;

    public Animator gateAnimator;
    void Start()
    {
        gateAnimator = gate.GetComponent<Animator>();
    }
    // This function is called when a trigger collider enters the trigger area of this game object's collider
    void OnTriggerEnter(Collider collider)
    {
        // Check if the collider that entered the trigger area is Key 1
        if (collider.gameObject == key1)
        {
            // Set the key1InPlace boolean to true
            key1InPlace = true;
            Debug.Log("1 triggered");

        }

        // Check if the collider that entered the trigger area is Key 2
        if (collider.gameObject == key2)
        {
            // Set the key2InPlace boolean to true
            Debug.Log("2 triggered");
            key2InPlace = true;
        }

        // Check if the collider that entered the trigger area is Key 3
        if (collider.gameObject == key3)
        {
            // Set the key3InPlace boolean to true
            key3InPlace = true;
            Debug.Log("3 triggered");

        }

        // Check if all keys are in place
        if (key1InPlace && key2InPlace && key3InPlace)
        {
            // If all keys are in place, open the gate
            gateAnimator.SetTrigger("GateOpen");
            Debug.Log("Game Over");
        }
    }
}
