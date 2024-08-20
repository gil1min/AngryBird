using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    public GameObject unlockGo;
    public GameObject lockGo;
    public TextMeshProUGUI levelNumberText;
    public GameObject star0Go;
    public GameObject star1Go;
    public GameObject star2Go;
    public GameObject star3Go;
   public void Show(int starCount)
   {
        star0Go.SetActive(false);
        star1Go.SetActive(false);
        star2Go.SetActive(false);
        star3Go.SetActive(false);

        if (starCount < 0)
        {
            unlockGo.SetActive(false);
            lockGo.SetActive(true);
        }
        else 
        {
            unlockGo.SetActive(true);
            lockGo.SetActive(false);

            switch (starCount)
            {
                case 3:
                    star3Go.SetActive(true);
                    break;
                case 2:
                    star2Go.SetActive(true);
                    break;
                case 1:
                    star1Go.SetActive(true);
                    break;
                case 0:
                    star0Go.SetActive(true);
                    break;
                default:
                    break;
            }
        }
   }

   public void OnClick()
   {

   }
}
