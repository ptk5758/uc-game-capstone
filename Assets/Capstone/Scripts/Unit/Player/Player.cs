using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BasePlayer
{
    public static Action<int> hited;
    public Animator animator;

    private void OnEnable()
    {
        GameManager.ChangedStatus += OnGameStatusChanged;
    }

    private void OnDisable()
    {
        GameManager.ChangedStatus -= OnGameStatusChanged;
    }

    private void OnGameStatusChanged(GameStatus status)
    {
        animator.SetBool("IsBattle", status == GameStatus.Battle);
    }
}