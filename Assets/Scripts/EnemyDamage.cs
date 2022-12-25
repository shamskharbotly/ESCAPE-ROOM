using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 1; // the amount of damage that the enemy will deal to the player
    public GameObject player; // the player game object
    GameObject enemy;
    void Start()
    {
        enemy = GetComponentInParent<EnemyController>().gameObject;
    }
    void Update()
    {
        Debug.Log(enemy.GetComponent<EnemyController>().isAttacking);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && enemy.GetComponent<EnemyController>().isAttacking) // if the enemy's sword collides with the player
        {
            Debug.Log("Damaged");
            player.GetComponent<PlayerHealth>().TakeDamage(damage); // call the TakeDamage function on the player's health script, passing in the damage value
            
        }
    }
}
