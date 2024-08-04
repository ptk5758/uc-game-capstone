using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem;

[System.Serializable]
public class CharacterManager : BaseManager
{
    [field:SerializeField]
    public GameObject CurrentCharacter { get; private set; }
    private IGameManager _gameManager;
    private ICharacterSystem _characterSystem;

    [SerializeField]
    private Transform spawnLocation;

    [SerializeField]
    private GameObject spawnPrefab;

    public void Init(IGameManager gameManager)
    {
        _gameManager = gameManager;
        _characterSystem = new CharacterSystem();
    }
    public IGameManager GameManager { get { return _gameManager; } }
    
    protected override void AwakedEventHendler() {
        SpawnCharacter();
    }
    private void SpawnCharacter()
    {
        GameObject spawnedObject = _characterSystem.SpawnCharacter(spawnLocation, spawnPrefab);
        CurrentCharacter = spawnedObject;
    }
}
