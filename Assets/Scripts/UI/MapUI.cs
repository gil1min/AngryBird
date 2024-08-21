using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapUI : MonoBehaviour
{
    public GameObject lockUI;
    public GameObject starUI;
    public TextMeshProUGUI starCountTextUI;
    public MapLevelUI mapLevelUI;
    public int mapID;

    // startCount == -1 means locked
    public void Show(int starCount, MapLevelUI mapLevelUI, int mapID)
    {
        this.mapLevelUI = mapLevelUI;
        this.mapID = mapID;
        if (starCount < 0)
        {
            GetComponent<Button>().enabled = false;
            lockUI.SetActive(true);
            starUI.SetActive(false);
            lockUI.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
        }   
        else 
        {
            lockUI.SetActive(false);
            starUI.SetActive(true);
            starCountTextUI.text = starCount.ToString();
        }
    }

    public void OnClick()
    {
        mapLevelUI.OnMapButtonClick(mapID);
    }
}
