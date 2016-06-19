    using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private static GameManager s_Instance;
    public static GameManager Instance
    {
        get
        {
            if (s_Instance == null)
            {
                s_Instance = FindObjectOfType<GameManager>();
            }
            return s_Instance;
        }
    }

    public GameObject mPlayer;
	public GameObject mGun;
    public GameObject mDeathZoneObj; //Added because Death Zone does not delete on level load
    public CheckpointSystem mCheckPointSystem;
    public Death_Zone mDeathZone;
    public GameOver mGameOver;
    public HealthManager mHealthManager;
    public Timer mTimer;
	public LifePlus mLifePlus;
	public PickUps mPickUps;
    public TextManager mTextManager;
    public AiSpawnManager mAiSpawnManager;
    public LevelManager mLevelManager;
    public GunScript mGunScript;
    public GameObject mRingWall;
    public GameObject mPlatforms;
    public GameObject mEnemyLayout;
}
