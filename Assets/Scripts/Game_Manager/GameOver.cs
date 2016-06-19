using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOver : MonoBehaviour
{
    private HealthManager health;
    

	void Start ()
    {
        
	}
	
	void Update ()
    {
	
	}

    public void gameOver()
    {
        Destroy(GameManager.Instance.mPlayer);
        //Display GameOver Screen
        Debug.Log("You lose");
        //Application.LoadLevel("StatingMenu");
        GameObject.DestroyImmediate(GameManager.Instance.mPlayer);
        GameObject.DestroyImmediate(GameManager.Instance.mCheckPointSystem);
        GameObject.DestroyImmediate(GameManager.Instance.mDeathZoneObj);
        GameObject.DestroyImmediate(GameManager.Instance.mHealthManager);
        GameObject.DestroyImmediate(GameManager.Instance.mTimer);
        GameObject.DestroyImmediate(GameManager.Instance.mLifePlus);
        GameObject.DestroyImmediate(GameManager.Instance.mPickUps);
        GameObject.DestroyImmediate(GameManager.Instance.mTextManager);
        GameObject.DestroyImmediate(GameManager.Instance.mAiSpawnManager);
        GameObject.DestroyImmediate(GameManager.Instance.mLevelManager);
        GameObject.DestroyImmediate(GameManager.Instance.mGameOver);
        GameObject.DestroyImmediate(GameManager.Instance.mEnemyLayout);
        GameObject.DestroyImmediate(GameManager.Instance.mRingWall);
        GameObject.DestroyImmediate(GameManager.Instance.mPlatforms);
        SceneManager.LoadScene("GameOverScene");
    }
}
