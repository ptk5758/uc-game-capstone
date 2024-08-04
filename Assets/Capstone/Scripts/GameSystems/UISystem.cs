using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystem
{
    public class UISystem : IUISystem
    {
        private IGameManager _gameManager;
        public UISystem(IGameManager gameManager)
        {
            _gameManager = gameManager;
        }
        public void SetGameStatusToBattle()
        {
            _gameManager.SetGameStatus(GameStatus.Battle);
        }
    }
    public interface IUISystem
    {
        public void SetGameStatusToBattle();
    }
}