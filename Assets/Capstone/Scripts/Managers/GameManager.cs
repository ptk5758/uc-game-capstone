using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IGameManager
{   

    /// <summary>
    /// Game Manager의 Awake가 완료되고 마지막 줄에서 호출
    /// </summary>
    public static event Action Awaked;

    [SerializeField]
    private CharacterManager _characterManager;
    private void Awake()
    {   
        _characterManager.Init(this);

        Awaked?.Invoke();
    }
}

public interface IGameManager
{

}