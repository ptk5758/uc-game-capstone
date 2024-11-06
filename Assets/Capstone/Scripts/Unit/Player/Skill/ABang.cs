using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
모든 적을 공격 하는 Skill Class
*/
public class ABang : Skill
{
    private float skillDamage;
    public ABang(Player p) : base(p) {
        coolTime = 5f;
        skillDamage = 10;
    }
    protected override void Activate()
    {
        // Debug.Log("아방 스트랏슈");
        foreach (Monster monster in new HashSet<Monster>(MonsterManager.alive)) {            
            Debug.Log(monster);
            // monster.abangHitParticle.Play();
            // player.particleManager.abangEffect
            GameObject obj = GameObject.Instantiate(player.particleManager.abangEffect, monster.transform);
            monster.Hit(player.AttackDamage + skillDamage);
        }
    }
}
