using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyNetworkManager : NetworkManager
{
    public override void OnStartHost()
    {
        base.OnStartHost();
    }
    public override void OnStartClient()
    {
        
        base.OnStartClient();
    }
}
