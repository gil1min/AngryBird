using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLevelUI : MonoBehaviour
{
   public GameObject mapListGo;
   public GameObject levelListGo;

   public List<MapUI> mapUIList;

   public void ShowMapList(MapSO[] mapArray)
   {
    mapListGo.SetActive(true);
    levelListGo.SetActive(false);
    UpdateMapUIList(mapArray);
   }

   private void UpdateMapUIList(MapSO[] mapArray)
   {
        for (int i = 0; i < mapArray.Length; ++i)
        {
            mapUIList[i].Show(mapArray[i].startNumberOfMap);
        }
   }

   public void OnMapButtonClick(int mapID)
   {
        
   }
}
