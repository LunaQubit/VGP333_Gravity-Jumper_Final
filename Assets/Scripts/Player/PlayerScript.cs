using UnityEngine;
using System.Collections;


public class PlayerScript : MonoBehaviour
{
	public bool rotating;
	public Vector3 strafedir;
	public Camera m_Camera;
	public Camera b_Camera;
	private Rigidbody cache_rb;
	private Transform cache_tf;
	public float forspeed;
	public float strafespeed;

	public float jetupforce;
	private Vector3 velocity;
	private Vector3 prevVelocityY;
	private MyMouseLook m_MouseLook;
	private Quaternion rot;
	public bool hasnotshot;
    private Vector3 m_PlayerBottom;
    public RaycastHit hit;
	//public float mass;
	//private float weight;

    //Player Speeds

    //[SerializeField]
    private Vector3 m_Velocity;
    [SerializeField]
    private Quaternion m_Rotation;

    public Vector3 display;
    [SerializeField]
    private Vector3 forw;
    [SerializeField]
    private Vector3 strafe;
    //Jetpack Values
    public float m_Fuel;
    [SerializeField]
    private bool m_Jetpack;
    public float m_JetForce;

    //Damping Values
    public float m_PositiveLimit;
    public float m_NegativeLimit;
    public Vector3 m_GravLimit;

    //Audio Source
    private AudioSource m_JetpackSound;
    private AudioSource m_Footsteps;

    // Use this for initialization
    void Start ()
	{
		m_MouseLook = this.GetComponent<MyMouseLook>();
		m_Camera.enabled = true;
		cache_rb = this.GetComponent<Rigidbody>();
		cache_tf = this.GetComponent<Transform>();
        m_JetpackSound = this.GetComponent<AudioSource>();
        m_Footsteps = m_Camera.GetComponent<AudioSource>();
        m_MouseLook.Init(cache_tf, m_Camera.transform);
        m_Jetpack = false;
		//weight = mass * 9.81;
        //m_JetForce = new Vector3(0.0f, 7.5f, 0.0f);
	}
	
	// Update is called once per frame
	void Update ()
	{
        //display = cache_tf.up * -1;
		m_Velocity = this.GetComponent<Rigidbody>().velocity;
        
        RotateView();

        //m_PlayerBottom = this.transform.position;
        //m_PlayerBottom.y = m_PlayerBottom.y - 0.6f;
        
        //Debug.DrawLine(m_PlayerBottom, m_PlayerBottom - new Vector3(0.0f, 3.0f, 0.0f) , Color.magenta, 2.0f);
		/*
        if (Physics.Raycast(m_PlayerBottom, Vector3.down, 1.0f))//if (Physics.SphereCast(m_PlayerBottom, 0.5f, , out hit))//       new Vector3(0.0f, -1.0f, 0.0f)
        {
            //print("There is something below the object!");
            onground = true;
        }
        else
        {
            onground = false;
        }*/

		if (Input.GetButton("r"))
		{
			b_Camera.enabled = true;
			m_Camera.enabled = false;
		}
		else
		{
			b_Camera.enabled = false;
			m_Camera.enabled = true;
		}
        #region Ground Movement
        m_Footsteps.Stop();

		if (hasnotshot == true)
		{
			float horizontal = Input.GetAxis("Horizontal");
			float vertical = Input.GetAxis("Vertical");

            //This block of code here is the problem zone
            /////////////////////////////////////////////////////////////////////
            //if (horizontal == 0)
            //{
            //	cache_rb.velocity = forspeed * vertical * cache_tf.forward;
            //}
            //else if (vertical == 0)
            //{
            //	cache_rb.velocity = cache_tf.right * horizontal * strafespeed;
            //}
            //else
            //{
            //	forw = forspeed * vertical * cache_tf.forward;
            //	strafe = cache_tf.right * strafespeed * horizontal;
            //	cache_rb.velocity = resultant(strafe, forw);
            //}
            ////////////////////////////////////////////////////////////////////////
            prevVelocityY.y = cache_rb.velocity.y;
			Vector3 temp;

			if (horizontal == 0)
			{
                m_Footsteps.Play();
                temp = forspeed * vertical * cache_tf.forward;

                cache_rb.velocity = resultant(temp, prevVelocityY);
            }


			else if (vertical == 0)
			{
                m_Footsteps.Play();
                temp = strafespeed * horizontal * cache_tf.right;
				cache_rb.velocity = resultant(temp, prevVelocityY);

            }


			else
			{
                m_Footsteps.Play();
                forw = forspeed * vertical * cache_tf.forward;
				strafe = cache_tf.right * strafespeed * horizontal;
				temp = resultant(strafe, forw);
				cache_rb.velocity = resultant(temp, prevVelocityY);

            }

		}
		/*
		if (Input.GetKey(KeyCode.W))
		{
			cache_tf.Translate(Vector3.forward * Time.deltaTime * forspeed);
			//cache_rb.AddForce(cache_tf.forward * m_JetForce);
		}

		if (Input.GetKey(KeyCode.A))
		{
			cache_tf.Translate(Vector3.left * Time.deltaTime * forspeed);
			//cache_rb.AddForce(cache_tf.right * m_JetForce * -1);
		}

		if (Input.GetKey(KeyCode.S))
		{
			cache_tf.Translate(Vector3.back * Time.deltaTime * forspeed);
			//cache_rb.AddForce(cache_tf.forward * m_JetForce * -1);
		}

		if (Input.GetKey(KeyCode.D))
		{
			cache_tf.Translate(Vector3.right * Time.deltaTime * forspeed);
			//cache_rb.AddForce(cache_tf.right * m_JetForce);
		}
		*/
		#endregion

		#region Velocity Damping

		if (m_Velocity.y < m_GravLimit.y)//v: Limit the Downward Velocity that Gravity can impose. Make things easier for the player.
        {
            cache_rb.AddForce(m_GravLimit * -1);
        }

        if(m_Velocity.x < m_NegativeLimit)
        {
            cache_rb.AddForce(1.5f, 0.0f, 0.0f);
        }

        if(m_Velocity.x > m_PositiveLimit)
        {
            cache_rb.AddForce(-1.5f, 0.0f, 0.0f);
        }

        if (m_Velocity.z < m_NegativeLimit)
        {
            cache_rb.AddForce(0.0f, 0.0f, 1.5f);
        }

        if (m_Velocity.z > m_PositiveLimit)
        {
            cache_rb.AddForce(0.0f, 0.0f, -1.5f);
        }

        #endregion

        #region Jetpack Code

        if (m_Fuel <= 0.0f)
        {
            m_Jetpack = false;
        }

        if(Input.GetButton("Fire2") && m_Fuel > 0.0f)
        {
            //cache_rb.AddForce(m_JetForce);
            m_Jetpack = true;
        }

        if(Input.GetButtonUp("Fire2") && m_Fuel > 0.0f )
        {
            m_Jetpack = false;
        }

        if(m_Jetpack == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                m_JetpackSound.Play();
                hasnotshot = false;
                cache_rb.AddForce(new Vector3(0.0f, jetupforce, 0.0f));
                m_Fuel = m_Fuel - 0.5f;
            }
            if (Input.GetKey(KeyCode.W))
            {
                m_JetpackSound.Play();
                //cache_tf.Translate(Vector3.forward * Time.deltaTime);
                cache_rb.AddForce(cache_tf.forward * m_JetForce);
                m_Fuel = m_Fuel - 0.5f;
            }

            if (Input.GetKey(KeyCode.A))
            {
                m_JetpackSound.Play();
                //cache_tf.Translate(Vector3.left * Time.deltaTime);
                cache_rb.AddForce(cache_tf.right * m_JetForce * -1);
                m_Fuel = m_Fuel - 0.5f;
            }

            if (Input.GetKey(KeyCode.S))
            {
                m_JetpackSound.Play();
                //cache_tf.Translate(Vector3.back * Time.deltaTime);
                cache_rb.AddForce(cache_tf.forward * m_JetForce * -1);
                m_Fuel = m_Fuel - 0.5f;
            }

            if (Input.GetKey(KeyCode.D))
            {
                m_JetpackSound.Play();
                //cache_tf.Translate(Vector3.right * Time.deltaTime);
                cache_rb.AddForce(cache_tf.right * m_JetForce);
                m_Fuel = m_Fuel - 0.5f;
            }
            
        }


        #endregion


    }

    void FixedUpdate()
	{
		m_MouseLook.UpdateCursorLock();
	}

    //v: Changes player state, doesn't need references
	void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<GroundScript>() != null)
		{
			hasnotshot = true;
		}
	}

	private void RotateView()
	{
		//Quaternion rotation = Quaternion.AngleAxis(180, m_Camera.transform.up);
		Quaternion player = cache_tf.localRotation;
		Quaternion cam = m_Camera.transform.localRotation;
		
		m_MouseLook.LookRotation(ref player,ref cam);

		cache_tf.localRotation = player;
		//b_Camera.transform.localRotation = rotation * cam;
		m_Camera.transform.localRotation = cam;
	}

	private Vector3 resultant(Vector3 a, Vector3 b)
	{
		Vector3 result;
		result.x = a.x + b.x;
		result.y = a.y + b.y;
		result.z = a.z + b.z;
		return result;
	}

    //v: Dot Product
	private Vector3 multiplyvec(Vector3 a,Vector3 b)
	{
		Vector3 result;
		result.x = a.x * b.x;
		result.y = a.y * b.y;
		result.z = a.z * b.z;
		return result;
	}

}
