using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBird : Bird
{
    protected override void FlyingSkill()
    {
        rgd.velocity *= 2;
    }
}
