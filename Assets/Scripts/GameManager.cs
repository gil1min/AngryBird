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
    public FollowTarget cameraFollowTarget;

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
        print("game over!");
    }
}
