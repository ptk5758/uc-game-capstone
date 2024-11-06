using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUP : Skill
{
    public LevelUP(Player p) : base(p) {
        coolTime = 5f;
    }
    protected override void Activate()
    {
        Debug.Log("스탯증가.");
    }
}
