using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointStrike : Skill
{
    public PointStrike(Player p) : base(p) {
        coolTime = 5f;
    }
    protected override void Activate()
    {
        Debug.Log("일점 타격");
    }
}
