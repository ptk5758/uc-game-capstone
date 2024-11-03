using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour, IPlayer
{
    [field:SerializeField]
    public int AttackDamage { get; private set; }

    [field:SerializeField]
    public int HP { get ; set; }
    public void SetPlayerData(PlayerData data)
    {
        AttackDamage = data.attackDamage;
        HP = data.hp;
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
}

public interface IPlayer : IUnit
{
    public int AttackDamage { get; }
    public void SetPlayerData(PlayerData data);
    public void Hit(int damage);
}
