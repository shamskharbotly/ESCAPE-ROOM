using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class AnimateHandOnInput : MonoBehaviour
{
    public InputActionProperty pinchAnimationActoin;
    public InputActionProperty gripAnimationActoin;

    public Animator handAnimator;
    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        float triggerValue = pinchAnimationActoin.action.ReadValue<float>();
        float gripValue = gripAnimationActoin.action.ReadValue<float>();

        handAnimator.SetFloat("Trigger", triggerValue); 
        handAnimator.SetFloat("Grip", gripValue);
         
    }
}
