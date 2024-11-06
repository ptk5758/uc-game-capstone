using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GameSystem;
using Unity.VisualScripting;
using UnityEngine.Events;
public class UIManager : BaseManager
{
    [SerializeField]
    private Button actionButton;

    [SerializeField]
    private TMP_Text actionButtonText;

    private UISystem _UISystem;

    [SerializeField]
    private ProgressBar healthBar;

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
        // playerHPText.text = "HP : " + hp;
        healthBar.value = hp;
        healthBar.Render();
    }
    private void OnLosed()
    {
        Debug.Log("대충 게임 패배 POPUP");
    }
    private void Update()
    {
        skillController.Update();
    }

    public override void Init(IGameManager gameManager)
    {
        base.Init(gameManager);
        _UISystem = new UISystem(gameManager);
    }

    protected override void OnReady()
    {
        actionButtonText.text = "전투시작";
        actionButton.onClick.RemoveAllListeners();
        actionButton.onClick.AddListener(BattleActionHendler);
    }
    protected override void OnBattle()
    {
        actionButtonText.text = "전투중";
        actionButton.onClick.RemoveAllListeners();
        actionButton.onClick.AddListener(()=>{
            Debug.Log("전투중 입니다...");
        });
    }
    protected override void OnMaintenance()
    {
        actionButtonText.text = "정비";
        actionButton.onClick.RemoveAllListeners();
        actionButton.onClick.AddListener(()=>{
            // Debug.Log("전투중 입니다...");
            _gameManager.SetGameStatus(GameStatus.Ready);
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
    public Image s1bw;
    public Button s2;
    public Image s2bw;
    public Button s3;
    public Image s3bw;
    public Button s4;
    public Image s4bw;
    private Player player;

    public void SetUp(Player player)
    {
        this.player = player;
        s1.onClick.AddListener(() => ClickHandler(player.s1, s1bw));
        s2.onClick.AddListener(() => ClickHandler(player.s2, s2bw));
        s3.onClick.AddListener(() => ClickHandler(player.s3, s3bw));
        s4.onClick.AddListener(() => ClickHandler(player.s4, s4bw));
    }
    private void ClickHandler(Skill skill, Image bw)
    {
        if (!skill.isSkillReady)
            return;
        skill.Cast();
        bw.fillAmount = 1;
    }

    public void Update()
    {
        if (s1bw.fillAmount > 0) {
            s1bw.fillAmount -= 1 / player.s1.coolTime * Time.deltaTime;
        }
        if (s2bw.fillAmount > 0) {
            s2bw.fillAmount -= 1 / player.s2.coolTime * Time.deltaTime;
        }
        if (s3bw.fillAmount > 0) {
            s3bw.fillAmount -= 1 / player.s3.coolTime * Time.deltaTime;
        }
        if (s4bw.fillAmount > 0) {
            s4bw.fillAmount -= 1 / player.s4.coolTime * Time.deltaTime;
        }
    }
}