using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthManager : MonoBehaviour
{
	public GameObject life;
	public Text healthText;
    public int initHealth;

    public int healthCoutner;

    void Start ()
    {
       healthCoutner = initHealth;
    }
	
	void Update ()
    {
        healthText.text = "Life: " + healthCoutner;
        if (healthCoutner <= 0)
        {
			GameManager.Instance.mGameOver.gameOver();			
        }
    }

    public void takeDmg()
    {
       healthCoutner--;     
    }

	public void OnTriggerEnter(Collider other)
	{
		LifePlus lPlus = other.GetComponent<LifePlus>();
		if (lPlus != null && lPlus.wasTriggered == false) 
		{
			healthCoutner++;
			lPlus.wasTriggered = true;
			other.gameObject.SetActive (false);
			Debug.Log( "Life +1." );
		}
	}
}
