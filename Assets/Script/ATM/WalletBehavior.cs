using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class WalletBehavior : MonoBehaviour
{
    [Header("WalletType")]
    [SerializeField] private ATM.BehaviorType _behaviorType;

    [Header("Attach Data")]
    [SerializeField] private List<Button> _buttons;
    [SerializeField] private Button _decisionButton;
    [SerializeField] private Button _cancleButton;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TMP_Text _header;
    
    [Header("Initialize Data")]
    [SerializeField] private Color _color;
    [SerializeField] private float[] _amount;
    [SerializeField] private string _headerText;

    private TMP_Text _decisionText;

    public void Awake()
    {
        _decisionText = _decisionButton.GetComponentInChildren<TMP_Text>();
    }

    public void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        for (int i = 0; i < _buttons.Count; i++)
        {
            Image img = _buttons[i].GetComponent<Image>();
            img.color = _color;

            TMP_Text temp = _buttons[i].GetComponentInChildren<TMP_Text>();
            temp.text = _amount[i].ToString("N0");
        }
        _decisionButton.GetComponent<Image>().color = _color; 

        _header.text = _headerText;
        _decisionText.text = _headerText;
    }

    public void BehaviorProcess(float amount)
    {
        WalletManager.Instance._system.BehaviorProcess(amount);
    }

    public void Command1()
    {
        BehaviorProcess(_amount[0]);
    }

    public void Command2()
    {
        BehaviorProcess(_amount[1]);
    }

    public void Command3()
    {
        BehaviorProcess(_amount[2]);
    }

    public void Command4()
    {
        float temp;
        float.TryParse(_inputField.text, out temp);

        if(temp>=0)
            BehaviorProcess(temp);
    }

    public void InteractableBtn(bool state)
    {
        foreach (var btn in _buttons)
        {
            btn.interactable = state;
        }
        _decisionButton.interactable = state;
        _cancleButton.interactable = state;
    }

    public void OnCancle()
    {
        WalletManager.Instance._system.BackBehavior();

    }
}
