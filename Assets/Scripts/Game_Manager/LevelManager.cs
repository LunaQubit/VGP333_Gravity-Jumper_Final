using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int Level;
    public GameObject Warp; 
    public Text levelText;

	void Start ()
    {
        //DontDestroyOnLoad(GameManager.Instance.mPlayer);
        //DontDestroyOnLoad(GameManager.Instance.mCheckPointSystem);
        //DontDestroyOnLoad(GameManager.Instance.mDeathZoneObj);
        //DontDestroyOnLoad(GameManager.Instance.mHealthManager);
        //DontDestroyOnLoad(GameManager.Instance.mTimer);
        //DontDestroyOnLoad(GameManager.Instance.mLifePlus);
        //DontDestroyOnLoad(GameManager.Instance.mPickUps);
        //DontDestroyOnLoad(GameManager.Instance.mTextManager);
        //DontDestroyOnLoad(GameManager.Instance.mAiSpawnManager);
        //DontDestroyOnLoad(GameManager.Instance.mLevelManager);
        //DontDestroyOnLoad(GameManager.Instance.mGameOver);
        
}
	
	void Update ()
    {
	    if(SceneManager.GetActiveScene().name == "Level01")
        {
            Level = 1;
            SceneManager.UnloadScene("StatMenu");
        }

        if (SceneManager.GetActiveScene().name == "Level02")
        {
            Level = 2;
            SceneManager.UnloadScene("Level01");
        }
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Level == 1)
        {
            //GameObject.DestroyImmediate(GameManager.Instance.mPlayer);
            //GameObject.DestroyImmediate(GameManager.Instance.mCheckPointSystem);
            //GameObject.DestroyImmediate(GameManager.Instance.mDeathZoneObj);
            //GameObject.DestroyImmediate(GameManager.Instance.mHealthManager);
            //GameObject.DestroyImmediate(GameManager.Instance.mTimer);
            //GameObject.DestroyImmediate(GameManager.Instance.mLifePlus);
            //GameObject.DestroyImmediate(GameManager.Instance.mPickUps);
            //GameObject.DestroyImmediate(GameManager.Instance.mTextManager);
            //GameObject.DestroyImmediate(GameManager.Instance.mAiSpawnManager);
            //GameObject.DestroyImmediate(GameManager.Instance.mLevelManager);
            //GameObject.DestroyImmediate(GameManager.Instance.mGameOver);
            //GameObject.DestroyImmediate(GameManager.Instance.mEnemyLayout);
            //GameObject.DestroyImmediate(GameManager.Instance.mRingWall);
            //GameObject.DestroyImmediate(GameManager.Instance.mPlatforms);
            
            SceneManager.LoadScene( "Level02" );
        }
        else if(other.CompareTag("Player") && Level == 2)
        {
            
            SceneManager.LoadScene("VictoryScene");
            //Application.LoadLevel("VictoryScene");
        }
    }

    //Since we set int Level in the inspector, this function is redundant and in fact causes bugs.
    //public void OnLevelWasLoaded()
    //{
    //    Level++;
    //}
}
