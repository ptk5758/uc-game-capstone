using System;
using System.Collections;
using System.Collections.Generic;
using GameSystem;
using UnityEngine;
using UnityEngine.Events;
public enum GameStatus
{
    Initialization, // 시스템 초기화
    Ready,   // 준비
    Battle,  // 전투
    Maintenance // 정비
}

public class GameManager : MonoBehaviour, IGameManager
{   
    public static event Action paused;
    public static event Action resumed;
    public static event Action losed;
    /// <summary>
    /// Game Manager의 Awake가 완료되고 마지막 줄에서 호출
    /// </summary>
    public static event Action Awaked;
#region 각종 메니저 Property

    [SerializeField]
    private MonsterManager _monsterManager;

    [SerializeField]
    private UIManager _uiManager;

    [SerializeField]
    private StageManager _stageManager;

    [SerializeField]
    private PlayerManager _playerManager;
#endregion

    public GameStatus Status { get; private set; }
    public static event Action<GameStatus> ChangedStatus;

    private void Awake()
    {   
        _monsterManager.Init(this);
        _uiManager.Init(this);
        _stageManager.Init(this);
        GameManagerInit();
        Awaked?.Invoke();
        SetGameStatus(GameStatus.Ready);
    }
    private void GameManagerInit()
    {
        // Character Spawned Event SubScription
        SetGameStatus(GameStatus.Initialization);
    }
    public void SetGameStatus(GameStatus nextStatus)
    {
        Status = nextStatus;
        ChangedStatus?.Invoke(Status);
    }

    public static void Lose()
    {
        Pause(true);
    }
    public static void Pause(bool isLose)
    {
        Time.timeScale = 0;
        if (isLose) {
            losed?.Invoke();
        } else {
            paused?.Invoke();
        }
    }
    public static void Resume()
    {
        Time.timeScale = 1;
        resumed?.Invoke();
    }
}

public interface IGameManager
{
    public void SetGameStatus(GameStatus nextStatus);
    // public IPlayer Player { get; }
}