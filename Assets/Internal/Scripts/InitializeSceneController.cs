using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeSceneController : MonoBehaviour
{
    static InitializeSceneController instance;
    public static InitializeSceneController Instance => instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {

    }
}
