using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystem
{
    public class MonsterSystem : IMonsterSystem
    {
        public static event Action<GameObject> SpawnedMonster;
        private IGameManager _gameManager;
        public MonsterSystem(IGameManager gameManager)
        {
            _gameManager = gameManager;
        }
        public void SpawnMonster(MonsterSpawnData data, Transform location)
        {
            GameObject spawned = GameObject.Instantiate(data.monster.prefab);
            Monster mob = spawned.AddComponent<Monster>();
            SetTarget(mob, PlayerManager.Player);
            mob.SetData(data.monster);
            spawned.transform.position = location.position;
            SpawnedMonster?.Invoke(spawned);
        }
        public void SetTarget(IMonster monster, IUnit unit)
        {
            monster.SetTarget(unit);
        }
    }
    public interface IMonsterSystem
    {
        public void SpawnMonster(MonsterSpawnData data, Transform location);
        public void SetTarget(IMonster monster, IUnit unit);
    }
}