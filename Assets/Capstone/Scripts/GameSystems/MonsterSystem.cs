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
        public void SpawnMonster(GameObject monster, Transform location)
        {
            GameObject spawned = GameObject.Instantiate(monster);
            Monster mob = spawned.AddComponent<Monster>();
            SetTarget(mob, _gameManager.Player);
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
        public void SpawnMonster(GameObject monster, Transform location);
        public void SetTarget(IMonster monster, IUnit unit);
    }
}