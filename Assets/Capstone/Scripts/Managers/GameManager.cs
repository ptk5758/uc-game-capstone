using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IGameManager
{   
    [SerializeField]
    private CharacterManager _characterManager;
    private void Awake()
    {   
        _characterManager.Init(this);
    }
}

public interface IGameManager
{

}