using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessgeManager : MonoBehaviour
{

    [SerializeField]
    private GameObject display;
    [SerializeField]
    private TMP_Text aletText;

    public float displayDuration;

    public void Notification(string message)
    {
        display.SetActive(true);
        aletText.text = message;
        StartCoroutine(DeactivateAfterDelay(displayDuration));
    }
    private IEnumerator DeactivateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        DeactivateDisplay();
    }
    private void DeactivateDisplay()
    {
        aletText.text = "";
        display.SetActive(false);        
    }

    [ContextMenu("Test")]
    public void TEST_notification()
    {
        Notification("notice Text!");
    }
}
