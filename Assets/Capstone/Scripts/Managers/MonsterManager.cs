using System.Collections;
using System.Collections.Generic;
using GameSystem;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterManager : BaseManager
{
    public static event System.Action<Monster> MonsterDied;
    public static event System.Action<Monster> MonsterSpawned;
    public static HashSet<Monster> alive = new HashSet<Monster>();
    public static void TriggerMonsterDied(Monster monster)
    {
        MonsterDied?.Invoke(monster);
    }
    private Transform[] spawnPoints;

    private StageData _stageData;

    private Stack<MonsterSpawnData> spawnStack;

    public override void Init(IGameManager gameManager)
    {
        base.Init(gameManager);
        MonsterManagerInit();
    }
    
    private void MonsterManagerInit() 
    {
        spawnStack = new Stack<MonsterSpawnData>();
        // GetComponentsInChildren 사용하면 자신의 transform도 포함하기에 1번째 index 부터 가져옴
        // [1..] => 1 index 부터 나머지 싹다
        spawnPoints = gameObject.transform.GetComponentsInChildren<Transform>()[1..];
    }

    private void OnEnable()
    {
        MonsterDied += OnMonsterDied;
        StageSystem.ChangedStage += StageSystem_ChangedStageEventHendler;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        StageSystem.ChangedStage -= StageSystem_ChangedStageEventHendler;
        MonsterDied -= OnMonsterDied;
    }
    protected override void OnBattle()
    {
        foreach (MonsterSpawnData monsterSpawnData in _stageData.monsterSpawnDatas) {
            spawnStack.Push(monsterSpawnData);
        }
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        while (spawnStack.Count > 0) {
            MonsterSpawnData spawnData = spawnStack.Pop();
            SpawnMonster(spawnData, GetRandomSpawnPoint());
            yield return new WaitForSeconds(spawnData.delay);                        
        }
        yield break;
    }
    public void SpawnMonster(MonsterSpawnData data, Transform location)
    {
        GameObject spawned = GameObject.Instantiate(data.monster.prefab);
        spawned.name = "Monster " + alive.Count;
        Monster mob = spawned.GetComponent<Monster>();
        mob.SetData(data.monster);
        mob.SetTarget(PlayerManager.Player);
        alive.Add(mob);
        spawned.transform.position = location.position;
        MonsterSpawned?.Invoke(mob);
    }

    private void OnMonsterDied(Monster monster)
    {
        alive.Remove(monster);
        if (spawnStack.Count == 0 && alive.Count == 0) 
        {
            _gameManager.SetGameStatus(GameStatus.Maintenance);
        }
    }

    private void StageSystem_ChangedStageEventHendler(StageData data)
    {
        _stageData = data;
    }

    private Transform GetRandomSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)];
    }
}
