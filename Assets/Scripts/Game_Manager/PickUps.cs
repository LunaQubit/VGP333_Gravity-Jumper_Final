using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PickUps : MonoBehaviour
{
    private int score;

	public GameObject Coin;
	public Text scoreText;
	
	void Update ()
    {
		scoreText.text = "Score: " + score;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag( "PickUp" ) )
        {
			score++;
            other.gameObject.SetActive(false);
			//UpdateScore(score + 1);
        }
    }
}
