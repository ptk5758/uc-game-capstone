using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterManager : BaseManager
{
    private IGameManager _gameManager;

    [SerializeField]
    private Transform spawnLocation;

    [SerializeField]
    private GameObject spawnPrefab;

    public void Init(IGameManager gameManager)
    {
        _gameManager = gameManager;
    }
    public IGameManager GameManager { get { return _gameManager; } }
}
