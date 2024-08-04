using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class BaseManager : MonoBehaviour
{
    protected IGameManager _gameManager;
    public virtual void Init(IGameManager gameManager)
    {
        _gameManager = gameManager;
        GameManager.Awaked += AwakedEventHendler;
        GameManager.ChangedStatus += GameManager_ChangedStatusEventHendler;
    }
    protected virtual void Awake()
    {
        
        
    }
    protected virtual void OnDisable()
    {
        GameManager.Awaked -= AwakedEventHendler;
        GameManager.ChangedStatus -= GameManager_ChangedStatusEventHendler;
    }

    protected virtual void AwakedEventHendler()
    {
        Debug.Log("[ "+ this.GetType().Name +" ] Default Awaked Event Hendler");
    }
    protected IGameManager GetGameManager() {
        return _gameManager;
    }

    protected virtual void GameManager_ChangedStatusEventHendler(GameStatus status)
    {
        switch (status) {
            case GameStatus.Ready :
                OnReady();
                return;
            case GameStatus.Battle :
                OnBattle();
                return;
            case GameStatus.Maintenance :
                OnMaintenance();
                return;
            default :
                return;
        }
    }

    protected virtual void OnReady()
    {
        Debug.Log("["+ this.GetType().Name +" Status] READY");
    }

    protected virtual void OnBattle()
    {
        Debug.Log("["+ this.GetType().Name +" Status] Battle");
    }

    protected virtual void OnMaintenance()
    {
        Debug.Log("["+ this.GetType().Name +" Status] Maintenance");
    }
}