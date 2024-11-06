using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill
{
    public static event Action<Skill> SkillCasted;        
    protected Player player;
    public float coolTime;
    public bool isSkillReady = true;
    public Skill(Player player)
    {
        this.player = player;
    }
    public void Cast()
    {
        if (!isSkillReady) {
            Debug.Log("쿨타임 입니다.");
            return;
        }
            
        Activate();
        TriggerSkillCasted(this);
    }
    public IEnumerator SkillCollTimeCoroutine()
    {
        isSkillReady = false;
        yield return new WaitForSeconds(coolTime);
        isSkillReady = true;
    }
    protected abstract void Activate();
    protected void TriggerSkillCasted(Skill skill)
    {
        SkillCasted?.Invoke(skill);
    }
}
