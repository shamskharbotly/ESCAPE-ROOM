using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float health = 2;
    public bool died;

    public Transform Player;
    public int MoveSpeed = 4;
    public int MaxDist = 10;
    public int MinDist = 5;

    public bool attacking;

    private Animator animator;
    private Quaternion initRotation;


    private int currentAnimation;
    private List<string> animations;

    void Awake()
    {
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        initRotation = transform.rotation;


        animations = new List<string>()
            {
                "Hit1",
                "Fall1",
                "Attack1h1",
            };
    }

    void Update()
    {
        //Death
        if (health <= 0 && !died)
            {
                animator.SetTrigger("Fall1");
                Debug.Log("playing");
                Destroy(gameObject);
                died = true;
            }

    }

    void OnCollisionEnters(Collider collision)
    {
        //Detect Damage
        if (collision.gameObject.tag == "Sword")
        {
            animator.SetTrigger("Hit1");
            Debug.Log("Hit");
            health -= 1;
        }


        /*
        if (Input.GetKeyDown(KeyCode.E))
        {
           animator.SetTrigger("Attack1h1");
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            animator.SetTrigger("Fall1");
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            animator.SetTrigger("Up");
        }*/
    }

}
