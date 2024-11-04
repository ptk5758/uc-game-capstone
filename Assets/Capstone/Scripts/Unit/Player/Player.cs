using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BasePlayer
{
    public static Action<int> hited;
    public Animator animator;

    private float attackTimer = 0;
    private void Update()
    {
        Targeting();
        Attacking();
    }
    private void Attacking()
    {
        if (target != null) {
            if (target.HP <= 0) {
                target = null;
            }
            if (attackTimer <= 0) {
                Attack();
                attackTimer = AttackDelay;
            }
            attackTimer -= Time.deltaTime;
        }
    }
    private void Attack()
    {
        target.Hit(AttackDamage);        
    }
    private void Targeting()
    {
        if (target == null) {
            if (monsters.Count > 0) {
                SetTarget(monsters.Dequeue());
            }
        }
    }
    private void SetTarget(Monster monster)
    {
        target = monster;
        animator.SetBool("IsAttack", true);
    }
    protected override void OnGameStatusChanged(GameStatus status)
    {
        animator.SetBool("IsBattle", status == GameStatus.Battle);
    }
    protected override void OnMonsterDied(Monster monster)
    {
        animator.SetBool("IsAttack", false);
    }
}