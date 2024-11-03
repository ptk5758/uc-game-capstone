using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="PlayerData", menuName="Game/PlayerData", order=1)]
public class PlayerData : ScriptableObject
{
    public GameObject prefab;
    public int attackDamage;
    public int hp;
}