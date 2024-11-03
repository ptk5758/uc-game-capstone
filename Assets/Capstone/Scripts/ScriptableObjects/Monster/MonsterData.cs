using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName ="Game/MonsterData")]
public class MonsterData : ScriptableObject
{
    public GameObject prefab;
    public float speed;
}
