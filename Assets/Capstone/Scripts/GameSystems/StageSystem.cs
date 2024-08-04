using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystem
{
    public class StageSystem : IStageSystem
    {
        public static event Action<StageData> ChangedStage;
        public int Stage { get; private set; }
        public StageData StageData { get; private set; }
        private IGameManager _gameManager;
        public StageSystem(IGameManager gameManager)
        {
            _gameManager = gameManager;
        }
        public void SetStageData(StageData data)
        {
            StageData = data;
            ChangedStage?.Invoke(data);
        }
    }
    public interface IStageSystem
    {
        public int Stage { get; }
        public StageData StageData { get; }
        public void SetStageData(StageData data);
    }
}