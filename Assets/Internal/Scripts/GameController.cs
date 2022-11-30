using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] MyNetworkManager network_manager;

    private void Start()
    {
        Screen.fullScreenMode = FullScreenMode.Windowed;
        //UnityEditor.PlayerSettings.resizableWindow = true;
        
    }
    public void OnCreateHostButtonPressed()
    {
        network_manager.StartHost();
    }
    public void OnConnectToHostButtonPressed()
    {
        network_manager.StartClient();
        
    }
    
}