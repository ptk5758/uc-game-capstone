using System;
using System.Collections;
using System.Collections.Generic;
using GameSystem;
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
        GameManagerInit();
        Awaked?.Invoke();
    }
    private void GameManagerInit()
    {
        // Character Spawned Event SubScription
        CharacterSystem.SpawnedCharacter += CharacterSystem_SpawnedEventHendler;
    }

    private void CharacterSystem_SpawnedEventHendler(GameObject character)
    {
        Debug.Log("Spawned Object : " + character.name);
    }

    private void OnDisable()
    {
        CharacterSystem.SpawnedCharacter -= CharacterSystem_SpawnedEventHendler;
    }
}

public interface IGameManager
{

}