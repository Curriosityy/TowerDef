using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    private static SceneChanger _instance;

    public static SceneChanger Instance {
        get
        {
            if(_instance==null)
            {
                var gO = new GameObject("(Singleton)SceneChanger");
                
                _instance= gO.AddComponent<SceneChanger>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if(Instance!=null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeScreen(string sceneName, LoadSceneMode loadSceneMode)
    {
        SceneManager.LoadScene(sceneName, loadSceneMode);
    }
    public void ChangeScreen(int sceneId, LoadSceneMode loadSceneMode)
    {
        SceneManager.LoadScene(sceneId, loadSceneMode);
    }

}
