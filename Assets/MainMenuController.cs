using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class MainMenuController : MonoBehaviour
{
    public void OnEnter(TMP_Text data)
    {
        data.color = Color.red;
    }
    public void OnExit(TMP_Text data)
    {
        data.color = Color.red;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void GoToLevel(string name)
    {
        SceneChanger.Instance.ChangeScreen(name, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
}
