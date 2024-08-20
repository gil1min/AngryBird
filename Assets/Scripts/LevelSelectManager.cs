using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectManager : MonoBehaviour
{
    public GameSO gameSO;
    public MapLevelUI mapLevelUI;

    void Start()
    {
        mapLevelUI.ShowMapList(gameSO.mapArray);
    }
}
