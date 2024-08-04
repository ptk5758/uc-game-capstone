using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseManager : MonoBehaviour
{
    protected virtual void Awake()
    {
        GameManager.Awaked += AwakedEventHendler;
    }
    protected virtual void OnDisable()
    {
        GameManager.Awaked -= AwakedEventHendler;
    }

    protected virtual void AwakedEventHendler()
    {
        Debug.Log("[ "+ this.GetType().Name +" ] Default Awaked Event Hendler");
    }
}