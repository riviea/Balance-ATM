using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletManager : MonoBehaviour
{
    public static WalletManager Instance;
    public GameObject scene_ui { get; private set; }
    public ATMSystem _system { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void AttachSystem(ATMSystem system)
    {
        _system = system;
    }
}
