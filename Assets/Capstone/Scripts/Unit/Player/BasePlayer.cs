using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePlayer : MonoBehaviour, IPlayer
{
    [field:SerializeField]
    public int AttackDamage { get; private set; }
    public float AttackDelay { get; set; }

    [field:SerializeField]
    public int HP { get ; set; }

    protected Queue<Monster> monsters = new Queue<Monster>();
    protected Monster target;
    
    public void SetPlayerData(PlayerData data)
    {
        AttackDamage = data.attackDamage;
        HP = data.hp;
        AttackDelay = data.attackDelay;
    }
    public GameObject GameObject { get { return gameObject; } }
    private void Start()
    {
        Player.hited?.Invoke(HP);
    }

    public void Hit(int damage) 
    {
        HP -= damage;
        Player.hited?.Invoke(HP);
        if (HP <= 0) {
            GameManager.Lose();
        }
    }
    private void OnEnable()
    {
        GameManager.ChangedStatus += OnGameStatusChanged;
        GameSystem.MonsterSystem.SpawnedMonster += OnMonsterSpawned;
    }

    private void OnDisable()
    {
        GameManager.ChangedStatus -= OnGameStatusChanged;
    }
    protected abstract void OnGameStatusChanged(GameStatus status);
    private void OnMonsterSpawned(Monster monster)
    {
        Debug.Log("[Player] : Listen Monster -> " + monster.gameObject.name);
        monsters.Enqueue(monster);
    }
}

public interface IPlayer : IUnit
{
    public int AttackDamage { get; }
    public void SetPlayerData(PlayerData data);
    public void Hit(int damage);
}
