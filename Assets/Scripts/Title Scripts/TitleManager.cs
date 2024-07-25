using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    public void BeginGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        Debug.Log("High score has been reset");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}