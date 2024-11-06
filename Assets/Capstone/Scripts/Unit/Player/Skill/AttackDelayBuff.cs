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
        coolTime = 8f;
    }
    protected override void Activate()
    {
        player.AttackDelay -= 0.1f;
        Debug.Log("공속 증가");
        MessgeManager messgeManager = GameObject.FindObjectOfType<MessgeManager>();
        messgeManager.Notification("공격 속도가 증가 하였습니다.");
        
    }
}
