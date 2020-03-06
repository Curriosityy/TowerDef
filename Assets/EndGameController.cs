using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey)
        {
            SceneChanger.Instance.ChangeScreen("Menu", UnityEngine.SceneManagement.LoadSceneMode.Single);
        }
    }
}
