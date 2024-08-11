using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour, IPlayer, IUnit
{
    [field:SerializeField]
    public int AttackDamage { get; private set; }
    public void SetPlayerData(PlayerData data)
    {
        AttackDamage = data.AttackDamage;
    }
    public GameObject GameObject { get { return gameObject; } }

}

public interface IPlayer
{
    public int AttackDamage { get; }
    public void SetPlayerData(PlayerData data);
}
