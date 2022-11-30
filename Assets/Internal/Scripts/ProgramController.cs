using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Program Entrance
/// </summary>
public class ProgramController : MonoBehaviour
{
    void Start()
    {
        LoadMainGameScene();
        //LoadInitializeScene();
    }
    void LoadInitializeScene()
    {
        AssetHolder.LoadScene("Assets/Internal/Scenes/InitializeScene.unity",
            handle =>
            {
                Debug.Log("On \"InitializeScene\" Loaded");
            });
    }
    void LoadMainMenu()
    {

    }
    void LoadMainGameScene()
    {
        AssetHolder.LoadScene("Assets/Internal/Scenes/MainGameScene.unity",
            handle =>
            {
                
            });
    }
}
