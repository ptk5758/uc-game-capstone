using System.Collections;
using System.Collections.Generic;
using GameSystem;
using UnityEngine;

public class StageManager : BaseManager
{
    [SerializeField]
    private StageData[] stageDatas;

    private IStageSystem _stageSystem;
    public override void Init(IGameManager gameManager)
    {
        base.Init(gameManager);
        _stageSystem = new StageSystem(gameManager);
    }
    protected override void OnReady()
    {
        _stageSystem.SetStageData(stageDatas[_stageSystem.Stage]);
    }
}
