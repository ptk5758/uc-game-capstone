using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterManager : BaseManager
{
    public Transform[] spawnPoints;

    public override void Init(IGameManager gameManager)
    {
        base.Init(gameManager);
        MonsterManagerInit();
    }

    private void MonsterManagerInit() 
    {
        // GetComponentsInChildren 사용하면 자신의 transform도 포함하기에 1번째 index 부터 가져옴
        // [1..] => 1 index 부터 나머지 싹다
        spawnPoints = gameObject.transform.GetComponentsInChildren<Transform>()[1..];        
    }
}
