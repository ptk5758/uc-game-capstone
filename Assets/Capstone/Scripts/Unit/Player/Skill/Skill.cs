using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill
{
    public static event Action<Skill> SkillCasted;        
    protected Player player;
    public float coolTime;
    private bool isSkillReady = true;
    public Skill(Player player)
    {
        this.player = player;
    }
    public void Cast()
    {
        if (!isSkillReady) 
            return;
        Action();
        TriggerSkillCasted(this);
    }
    protected IEnumerator SkillCollTimeCoroutine()
    {
        isSkillReady = false;
        yield return new WaitForSeconds(coolTime);
        isSkillReady = true;
    }
    public abstract void Action();
    protected void TriggerSkillCasted(Skill skill)
    {
        SkillCasted?.Invoke(skill);
    }
}