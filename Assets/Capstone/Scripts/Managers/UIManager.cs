using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GameSystem;
using Unity.VisualScripting;
public class UIManager : BaseManager
{
    [SerializeField]
    private Button actionButton;

    [SerializeField]
    private TMP_Text actionButtonText;

    private UISystem _UISystem;

    [SerializeField]
    private TMP_Text playerHPText;

    [SerializeField]
    private SkillController skillController;
    private void OnEnable()
    {
        Player.hited += OnPlayerHited;
        GameManager.losed += OnLosed;
    }
    private void Start()
    {
        skillController.SetUp(PlayerManager.Player);
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        Player.hited -= OnPlayerHited;
        GameManager.losed -= OnLosed;
    }
    private void OnPlayerHited(int hp) 
    {
        playerHPText.text = "HP : " + hp;
    }
    private void OnLosed()
    {
        Debug.Log("대충 게임 패배 POPUP");
    }

    public override void Init(IGameManager gameManager)
    {
        base.Init(gameManager);
        _UISystem = new UISystem(gameManager);
    }

    protected override void OnReady()
    {
        actionButtonText.text = "Battle!";
        actionButton.onClick.RemoveAllListeners();
        actionButton.onClick.AddListener(BattleActionHendler);
    }
    protected override void OnBattle()
    {
        actionButtonText.text = "Battling!";
        actionButton.onClick.RemoveAllListeners();
        actionButton.onClick.AddListener(()=>{
            Debug.Log("전투중 입니다...");
        });
    }
    protected override void OnMaintenance()
    {
        actionButtonText.text = "Maintenance..";
        actionButton.onClick.RemoveAllListeners();
        actionButton.onClick.AddListener(()=>{
            // Debug.Log("전투중 입니다...");
        });
    }

    private void BattleActionHendler()
    {
        _UISystem.SetGameStatusToBattle();
    }
}

[System.Serializable]
public class SkillController
{
    public Button s1;
    public Button s2;
    public Button s3;
    public Button s4;

    public void SetUp(Player player)
    {
        s1.onClick.AddListener(player.s1.Cast);
        s2.onClick.AddListener(player.s2.Cast);
        s3.onClick.AddListener(player.s3.Cast);
        s4.onClick.AddListener(player.s4.Cast);
    }
}