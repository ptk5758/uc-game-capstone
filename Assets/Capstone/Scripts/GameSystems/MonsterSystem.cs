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
            spawned.transform.position = location.position;
            SpawnedMonster?.Invoke(spawned);
        }
    }
    public interface IMonsterSystem
    {
        public void SpawnMonster(GameObject monster, Transform location);
    }
}