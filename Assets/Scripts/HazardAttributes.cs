using UnityEngine;
using System.Collections;

public class HazardAttributes : MonoBehaviour {

    public float m_Lifetime;

    //Hazard's Own Damping
    public Vector3 m_HazardUpForce; // Force to counter Gravity

    //To Diversify Hazard Spawning...directions
    public Vector3 m_HazardSpawnForce;

    [SerializeField]
    private Rigidbody m_Rigidbody;

	// Use this for initialization
	void Start () {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_HazardSpawnForce = new Vector3(Random.Range(-500.0f, 500.0f), Random.Range(-500.0f, 500.0f), Random.Range(-500.0f, 500.0f));
        m_Rigidbody.AddForce(m_HazardSpawnForce);
	}
	
	// Update is called once per frame
	void Update () {
	    if(m_Lifetime <= 0)
        {
            DestroyImmediate(this.gameObject);
        }
        else
        {
            m_Lifetime -= Time.deltaTime;
            m_Rigidbody.AddForce(m_HazardUpForce);
        }
        
	}
}
