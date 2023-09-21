using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WalletDisplayer : MonoBehaviour
{
    [Header("Attach Data")]
    [SerializeField] private TMP_Text _header;
    [SerializeField] private TMP_Text _balance;
    [SerializeField] private Color _color;

    [Header("Initialize Data")]
    [SerializeField] private string header;
    [SerializeField] private ATM.DisplayerType _currentDisplayerType;

    private Image _renderer;
    

    public string Header { get { return header; } set { header = value; } }

    private void Awake()
    {
        _renderer = GetComponent<Image>();
    }

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        UpdateAmount();

        _renderer.color = _color;
        _header.text = header;
    }

    public void UpdateAmount()
    {
        float amount = 0f;
        switch(_currentDisplayerType)
        {
            case ATM.DisplayerType.Balance:
                amount = WalletManager.Instance._system.WalletData.Balance;
                break;
            case ATM.DisplayerType.Wallet:
                amount = WalletManager.Instance._system.WalletData.Wallet;
                break;
        }
        _balance.text = amount.ToString("N0");
    }
}
