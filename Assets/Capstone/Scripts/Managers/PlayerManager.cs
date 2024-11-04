using System.Collections;
using System.Collections.Generic;
using GameSystem;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class PlayerManager : MonoBehaviour
{
    public static Player Player { get; set; }

    [SerializeField]
    private Transform spawnPosition;
    [SerializeField]
    private PlayerData data;
    private void OnEnable() 
    {
        SpawnPlayer();
    }
    private void SpawnPlayer()
    {
        GameObject created = Instantiate(data.prefab);
        created.transform.position = spawnPosition.position;
        Player = created.GetComponent<Player>();
        Player.SetPlayerData(data);
    }
}