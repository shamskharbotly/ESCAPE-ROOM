using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            audioData.Play(0);
            Debug.Log("Colided");
            Animator animator = other.gameObject.GetComponent<Animator>();
            animator.SetTrigger("Hit1");
            other.gameObject.GetComponent<EnemyHealth>().health -= 1;
        }
    }
}
