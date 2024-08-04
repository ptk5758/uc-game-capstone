using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem;

public class CharacterManager : BaseManager
{
    #region Public Property
    public GameObject CurrentCharacter { get; private set; }
    
    #endregion
    
    private ICharacterSystem _characterSystem;

    [SerializeField]
    private Transform spawnLocation;

    [SerializeField]
    private GameObject spawnPrefab;

    public override void Init(IGameManager gameManager)
    {
        base.Init(gameManager);
        _characterSystem = new CharacterSystem();
    }
    
    protected override void AwakedEventHendler() {
        SpawnCharacter();
    }
    private void SpawnCharacter()
    {
        GameObject spawnedObject = _characterSystem.SpawnCharacter(spawnLocation, spawnPrefab);
        CurrentCharacter = spawnedObject;
    }
}
