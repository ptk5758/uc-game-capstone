using System.Collections;
using System.Collections.Generic;
using GameSystem;
using UnityEngine;

public class PlayerManager : BaseManager, IAwakedEventListener
{
    public IPlayer Player { get; private set; }
    [SerializeField]
    private GameObject playerPrefab;

    [SerializeField]
    private Transform spawnLocation;

    [SerializeField]
    private PlayerData playerData;

    private PlayerSystem _playerSystem;

    public override void Init(IGameManager gameManager)
    {
        base.Init(gameManager);
        _playerSystem = new PlayerSystem(_gameManager);
    }

    protected override void AwakedEventHendler()
    {
        OnAwaked();
    }

    private void OnAwaked()
    {
        Player = CreatePlayer();
    }
    private IPlayer CreatePlayer()
    {
        GameObject created = Instantiate(playerPrefab);
        Player p = created.AddComponent<Player>();
        p.SetPlayerData(playerData);
        created.transform.position = spawnLocation.position;
        return p;
    }
}