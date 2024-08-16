using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public GameObject scorePrefab;

    public Sprite[] score3000;
    public Sprite[] score5000;
    public Sprite[] score10000;
    private Dictionary<int, Sprite[]> scoreDict;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        scoreDict = new Dictionary<int, Sprite[]>
        {
            { 3000, score3000 },
            { 5000, score5000 },
            { 10000, score10000 }
        };
    }

    public void ShowScore(Vector3 position, int score)
    {
        GameObject scoreGo = Instantiate(scorePrefab, position, Quaternion.identity);
        scoreDict.TryGetValue(score, out Sprite[] scoreArray);
        int index = Random.Range(0, scoreArray.Length);
        Sprite sprite = scoreArray[index];
        scoreGo.GetComponent<SpriteRenderer>().sprite = sprite;
        Destroy(scoreGo, 1f);
    }
}
