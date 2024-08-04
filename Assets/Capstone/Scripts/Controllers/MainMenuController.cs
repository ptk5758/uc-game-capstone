using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartButtonHendle()
    {
        #region TEST
        Debug.Log("asd");
        #endregion
        SceneManager.LoadScene("GamePlay");
    }

    public void ConfigButtonHendle()
    {
        Debug.Log("환경설정 창이 열려야합니다");
    }

    public void ExitButtonHendle()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quti();
#endif
    }
}
