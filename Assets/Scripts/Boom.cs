using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boom : MonoBehaviour
{
   void Start() {
    Destroy(gameObject, 1f);
   }
}
