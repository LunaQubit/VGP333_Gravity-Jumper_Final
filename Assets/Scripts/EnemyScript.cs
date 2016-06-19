using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    //public GameObject m_Enemy;
    public GameObject m_Player;
    [SerializeField]
    //private Vector3 m_P;
    //[SerializeField]
    private float m_TranslateX;
    [SerializeField]
    private float m_TranslateY;
    [SerializeField]
    private float m_TranslateZ;
    [SerializeField]
    private Vector3 m_EMoveSpeed;
    public float m_Proximity;
    //[SerializeField]
    public float m_Distance;

    // Use this for initialization
    void Start () {
        m_Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

        m_TranslateX = m_Player.transform.position.x - this.transform.position.x * 0.5f;
        m_TranslateY = m_Player.transform.position.y - this.transform.position.y * 0.5f;
        m_TranslateZ = m_Player.transform.position.z - this.transform.position.z * 0.5f;
        m_Distance = Vector3.Distance(m_Player.transform.position, this.transform.position);
        //Debug.DrawLine(this.transform.position, m_Player.transform.position, Color.magenta, 10.0f);
        if(m_Distance <= m_Proximity)
        {
            m_EMoveSpeed = new Vector3(m_TranslateX, m_TranslateY, m_TranslateZ);

            //transform.Translate(m_Player.transform.position.x - m_Enemy.transform.position.x * 0.1f,  m_Player.transform.position.y - m_Enemy.transform.position.y * 0.1f 
            //    , m_Player.transform.position.z - m_Enemy.transform.position.z * 0.1f );
            //transform.Translate(m_TranslateX, m_TranslateY, m_TranslateZ);
            this.transform.position = Vector3.SmoothDamp(this.transform.position, m_EMoveSpeed, ref m_EMoveSpeed, 0.25f);
        }

        
	}


}
