using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystem
{
    public class MonsterSystem : IUISystem
    {
        private IGameManager _gameManager;
        public MonsterSystem(IGameManager gameManager)
        {
            _gameManager = gameManager;
        }
        public void SetGameStatusToBattle()
        {
            _gameManager.SetGameStatus(GameStatus.Battle);
        }
    }
}