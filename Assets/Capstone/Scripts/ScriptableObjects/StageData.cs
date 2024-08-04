using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="StageData", menuName="Game/StageData", order=1)]
public class StageData : ScriptableObject
{
    public MonsterSpawnData[] monsterSpawnDatas;
}

[System.Serializable]
public struct MonsterSpawnData
{
    public GameObject monster;
    public float delay;
}