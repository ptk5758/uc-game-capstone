using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GameSystem;
public class UIManager : BaseManager
{
    [SerializeField]
    private Button actionButton;

    [SerializeField]
    private TMP_Text actionButtonText;

    private UISystem _UISystem;

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

    private void BattleActionHendler()
    {
        _UISystem.SetGameStatusToBattle();
    }
}
