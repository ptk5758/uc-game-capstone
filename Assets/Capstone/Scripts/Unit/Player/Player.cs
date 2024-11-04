using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BasePlayer
{
    public static Action<int> hited;
    public Animator animator;
    private void Update()
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
}