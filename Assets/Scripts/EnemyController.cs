using UnityEngine;
using UnityEngine.AI;
using System.Collections;

/* Makes enemies follow and attack the player */


public class EnemyController : MonoBehaviour {

	public float lookRadius = 10f;

	public Transform target;
	NavMeshAgent agent;
	private Animator animator;
    bool shouldAttack = true;

	public bool isAttacking;



	void Start()
	{
        animator = GetComponent<Animator>();

		agent = GetComponent<NavMeshAgent>();
		
	}

	void Update ()
	{
		// Get the distance to the player
		float distance = Vector3.Distance(target.position, transform.position);

		// If inside the radius
		if (distance <= lookRadius)
		{
			// Move towards the player
			agent.SetDestination(target.position);
			animator.SetFloat("speedh" , 3f);

            if (distance <= agent.stoppingDistance)
            {
                // Attack if close to the player
                FaceTarget();
                if (shouldAttack == true)
                {
                    isAttacking = true;
                    animator.SetTrigger("Attack1h1");
                    shouldAttack = false;
                    StartCoroutine("reAttack");
                }
            }
			else
			{
				isAttacking = false;
			}
		}
    }
		
	public IEnumerator reAttack()
		{
			yield return new WaitForSeconds(1.5f);

			shouldAttack = true;


		}


	// Point towards the player
	void FaceTarget ()
	{
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, lookRadius);
	}

}