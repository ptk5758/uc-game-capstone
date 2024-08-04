using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseManager : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Awaked += AwakedEventHendler;
    }
    private void OnEnable() 
    {
        GameManager.Awaked -= AwakedEventHendler;        
    }

    protected void AwakedEventHendler()
    {
        Debug.Log("BaseManager Awaked listen");
    }
}