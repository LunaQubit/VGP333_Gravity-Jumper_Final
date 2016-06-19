using UnityEngine;
using System.Collections;

public class Death_Zone : MonoBehaviour
{    
	void Start ()
    {
    
	}

	void Update ()
    {
	
	}

    void OnTriggerEnter(Collider other)
    {
		if (other.CompareTag ("Player")) 
		{
			GameManager.Instance.mHealthManager.takeDmg ();
			GameManager.Instance.mCheckPointSystem.RespawnPlayer ();
			Debug.Log ("Life Taken.");
		}
    }
}

