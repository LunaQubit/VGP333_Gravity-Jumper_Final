using UnityEngine;
using System.Collections;

public class EnemyAi : MonoBehaviour
{
    public Transform player;
    NavMeshAgent nav;

//    public GameObject EnemyToDestroy;
    public float selfDestroyTimer;


	void Start ()
    {
        player = GameObject.FindGameObjectWithTag( "Player" ).transform;
        nav = GetComponent<NavMeshAgent>();
        Destroy(this.gameObject, selfDestroyTimer);
//        selfDestroyTimer += Time.deltaTime;
    }
	
	void Update ()
    {
        nav.SetDestination(player.position);

/*        if(selfDestroyTimer > 10f)
        {
            Destroy(gameObject);
        }
*/
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag( "EnemyAi" ) )
        {
            Destroy(this.gameObject);
        }
    }
}
