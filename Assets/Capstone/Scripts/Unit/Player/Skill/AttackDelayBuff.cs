using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
모든 적을 공격 하는 Skill Class
*/
public class AttackDelayBuff : Skill
{
    public AttackDelayBuff(Player p) : base(p) {
        coolTime = 5f;
    }
    protected override void Activate()
    {
        Debug.Log("공속 증가");
    }
}
