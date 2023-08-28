using System;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] private Text _title;
    [SerializeField] private Text _description;
        [SerializeField] private Text _level;
    [SerializeField] private Image _icon;
    private Action _applyAction;

    public void Setup(string title, string description, string level, Sprite icon, Action onApply)
    {
        this._title.text = title;
        this._description.text =description;
        this._level.text=level;
        this._icon.sprite = icon;
        this._applyAction = onApply;

    }
    public void Apply()
    {
        _applyAction?.Invoke();
    }
}
