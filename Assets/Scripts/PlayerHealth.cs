using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // the maximum health of the player
    public int currentHealth; // the current health of the player
    public AudioClip damageSound; // the sound that will play when the player takes damage
    public Slider healthBar;

    void Start()
    {
        currentHealth = maxHealth; // set the current health to the maximum health when the game starts
        healthBar.value = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        
        currentHealth -= damage; // decrease the current health by the amount of damage taken
        GetComponent<AudioSource>().PlayOneShot(damageSound); // play the damage sound
        healthBar.value = currentHealth;
        if (currentHealth <= 0) // if the player's health is less than or equal to 0
        {
            Die(); // call the Die function
        }
    }

    void Die()
    {
        RestartScene();
        // code to handle the player's death goes here

    }

    public void RestartScene()
    {
        Scene thisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(thisScene.name);
    }
}
