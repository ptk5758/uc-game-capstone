using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessgeManager : MonoBehaviour
{

    [SerializeField]
    private GameObject board;
    [SerializeField]
    private TMP_Text aletText;

    public void Notification(string message)
    {
        aletText.text = message;
    }
}
