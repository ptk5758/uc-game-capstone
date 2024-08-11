using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystem
{    
    public class PlayerSystem
    {
        private IGameManager _gameManager;
        public PlayerSystem(IGameManager gameManager) {
            _gameManager = gameManager;
        }
    }
    public interface IPlayerSystem
    {
        
    }
}