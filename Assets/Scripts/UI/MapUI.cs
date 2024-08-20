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
    // Start is called before the first frame update
    void Start()
    {
        Show(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // startCount == -1 means locked
    public void Show(int starCount)
    {
        if (starCount < 0)
        {
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
}
