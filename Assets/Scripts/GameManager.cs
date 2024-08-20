using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private Bird[] birdList;
    private int index = -1;
    private int pigTotalCount;
    private int pigDeadCount;
    private FollowTarget cameraFollowTarget;
    public GameOverUI gameOverUI;

    private void Awake()
    {
        Instance = this;
        pigDeadCount = 0;
    }

    private void Start()
    {
        birdList = FindObjectsByType<Bird>(FindObjectsSortMode.None);
        pigTotalCount = FindObjectsByType<Pig>(FindObjectsSortMode.None).Length;
        cameraFollowTarget = Camera.main.GetComponent<FollowTarget>();
        LoadNextBird();
    }

    public void OnPigDead()
    {
        pigDeadCount++;
        if (pigDeadCount == pigTotalCount)
        {
            GameOver();
        }
    }

    public void LoadNextBird()
    {
        print("Load next bird!");
        index++;
        if (index >= birdList.Length)
        {
            GameOver();
        }
        else
        {
            birdList[index].EnterOnTheField(Slingshot.Instance.GetCenterPosition());
            cameraFollowTarget.SetTarget(birdList[index].transform);
        }
    }

    private void GameOver()
    {
        int starCount = 0;
        Debug.Log(pigDeadCount);
        Debug.Log(pigTotalCount);
        float pigDeadPercent = pigDeadCount * 1f / pigTotalCount;

        if (pigDeadPercent > 0.99f)
        {
            starCount = 3;
        }
        else if (pigDeadCount > 0.66f)
        {
            starCount = 2;
        }
        else if (pigDeadCount > 0.33f)
        {
            starCount = 1;
        }
        gameOverUI.Show(starCount);
    }

    public void RestartLevel()
    {

    }

    public void LevelList()
    {
        
    }
}
