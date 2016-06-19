using UnityEngine;
using System.Collections;


public class HazardSpawnScript : MonoBehaviour {

    public GameObject m_Hazard;
    public float m_SpawnTime;
    public float m_SpawnRate;
    [SerializeField]
    private int m_RandomDir;

    // Use this for initialization
    void Start () {
        //m_Hazard = GameObject.FindGameObjectWithTag("Hazard");
        InvokeRepeating("InstantiateHazard", m_SpawnTime, m_SpawnRate);
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void InstantiateHazard()
    {
        Instantiate(m_Hazard, this.transform.position, Random.rotation);
    }
}
