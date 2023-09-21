using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WalletData
{
    [SerializeField] private float _balance;
    [SerializeField] private float _wallet;

    public float Balance { get { return _balance; } set { _balance = value; } }
    public float Wallet { get { return _wallet; } set { _wallet = value; } }

    public WalletData()
    {
        _balance = _wallet = 0f;
    }

    public void DoDeposit(float amount)
    {
        _balance += amount;
        _wallet -= amount;
    }

    public void DoWithdraw(float amount)
    {
        _balance -= amount;
        _wallet += amount;
    }

    public void ChangeWallet(float amount = 0f)
    {
        _wallet += amount;
    }

    public void ChangeBalance(float amount = 0f)
    {
        _balance += amount;
    }
}