using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
모든 적을 공격 하는 Skill Class
*/
public class ABang : Skill
{
    public ABang(Player p) : base(p) {
        coolTime = 5f;
    }
    protected override void Activate()
    {
        Debug.Log("아방 스트랏슈");
    }
}
