using System.Collections;
using System.Collections.Generic;
using GameSystem;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterManager : BaseManager
{
    public static event System.Action<Monster> MonsterDied;
    public static void TriggerMonsterDied(Monster monster)
    {
        MonsterDied?.Invoke(monster);
    }
    private Transform[] spawnPoints;

    private StageData _stageData;
    private IMonsterSystem _monsterSystem;

    private Stack<MonsterSpawnData> spawnStack;

    public override void Init(IGameManager gameManager)
    {
        base.Init(gameManager);
        MonsterManagerInit();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        StageSystem.ChangedStage -= StageSystem_ChangedStageEventHendler;
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
            _monsterSystem.SpawnMonster(spawnData, GetRandomSpawnPoint());
            yield return new WaitForSeconds(spawnData.delay);                        
        }
        yield break;
    }

    private void MonsterManagerInit() 
    {
        _monsterSystem = new MonsterSystem(GetGameManager());
        spawnStack = new Stack<MonsterSpawnData>();
        StageSystem.ChangedStage += StageSystem_ChangedStageEventHendler;
        // GetComponentsInChildren 사용하면 자신의 transform도 포함하기에 1번째 index 부터 가져옴
        // [1..] => 1 index 부터 나머지 싹다
        spawnPoints = gameObject.transform.GetComponentsInChildren<Transform>()[1..];
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
