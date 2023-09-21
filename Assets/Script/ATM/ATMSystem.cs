using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATMSystem : MonoBehaviour
{
    [Header("Attach")]
    [SerializeField] private GameObject walletDisplayer;
    [SerializeField] private GameObject walletBehavior;
    [SerializeField] private GameObject atmCommand;
    [SerializeField] private GameObject error;

    [Header("Initialize Data")]
    [SerializeField] private float _initBalance;
    [SerializeField] private float _initWallet;

    private WalletData _walletData;
    private ATM.BehaviorType _currentBehaviorType;

    public WalletData WalletData { get { return _walletData; } }

    private void Awake()
    {
        _walletData = new WalletData();
        WalletManager.Instance.AttachSystem(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        _currentBehaviorType = ATM.BehaviorType.None;
        _walletData.Balance = _initBalance;
        _walletData.Wallet = _initWallet;
    }

    public void ChangeDeposit()
    {
        GameObject withdraw = walletBehavior.transform.GetChild(0).gameObject;
        GameObject deposit = walletBehavior.transform.GetChild(1).gameObject;

        atmCommand.SetActive(false);
        withdraw.SetActive(false);
        deposit.SetActive(true);
        _currentBehaviorType = ATM.BehaviorType.Deposit;
    }

    public void ChangeWithdraw()
    {
        GameObject withdraw = walletBehavior.transform.GetChild(0).gameObject;
        GameObject deposit = walletBehavior.transform.GetChild(1).gameObject;

        atmCommand.SetActive(false);
        withdraw.SetActive(true);
        deposit.SetActive(false);
        _currentBehaviorType = ATM.BehaviorType.Withdraw;
    }

    public void BackBehavior()
    {
        GameObject witdraw = walletBehavior.transform.GetChild(0).gameObject;
        GameObject deposit = walletBehavior.transform.GetChild(1).gameObject;

        atmCommand.SetActive(true);
        witdraw.SetActive(false);
        deposit.SetActive(false);
        _currentBehaviorType = ATM.BehaviorType.None;
    }

    public void BehaviorProcess(float amount)
    {
        float tempBalance = _walletData.Balance;
        float tempWallet = _walletData.Wallet;

        switch (_currentBehaviorType)
        {
            case ATM.BehaviorType.Deposit:
                if ((tempWallet - amount) < 0) ErrorBehaviorProcess(false);
                else _walletData.DoDeposit(amount);
                break;
            case ATM.BehaviorType.Withdraw:
                if ((tempBalance - amount) < 0) ErrorBehaviorProcess(false);
                else _walletData.DoWithdraw(amount);
                break;
        }

        for(int i=0; i<walletDisplayer.transform.childCount; i++)
        {
            GameObject temp = walletDisplayer.transform.GetChild(i).gameObject;
            WalletDisplayer displayer = temp.GetComponent<WalletDisplayer>();
            displayer.UpdateAmount();
        }
    }

    public void ErrorBehaviorProcess(bool state)
    {
        error.SetActive(!state);
        for (int i=0; i<walletBehavior.transform.childCount; i++)
        {
            GameObject temp = walletBehavior.transform.GetChild(i).gameObject;
            if (temp.activeInHierarchy)
            {
                WalletBehavior behavior = temp.GetComponent<WalletBehavior>();
                behavior.InteractableBtn(state);
            }
        }
    }
}
