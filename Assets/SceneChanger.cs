using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : Singleton<SceneChanger>
{

    public void ChangeScreen(string sceneName, LoadSceneMode loadSceneMode)
    {
        SceneManager.LoadScene(sceneName, loadSceneMode);
    }
    public void ChangeScreen(int sceneId, LoadSceneMode loadSceneMode)
    {
        SceneManager.LoadScene(sceneId, loadSceneMode);
    }

}
