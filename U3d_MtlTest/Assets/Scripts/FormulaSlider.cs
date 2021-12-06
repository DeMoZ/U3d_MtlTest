using System;
using UnityEngine;
using UnityEngine.UI;

public class FormulaSlider : MonoBehaviour
{
    [SerializeField] private Text _value = default;
    [SerializeField] private Slider _slider = default;
    private Action<float> _onValueChanged;

    private void Awake() =>
        _slider.onValueChanged.AddListener(_ => OnValueChanged());

    public void ValueChanged(Action<float> onValueChanged) => 
        _onValueChanged += onValueChanged;

    private void OnValueChanged()
    {
        _value.text = _slider.value.ToString();
        _onValueChanged?.Invoke(_slider.value);
    }

    public void Init(Vector2 limits, float? setValue = null)
    {
        _slider.minValue = limits.x;
        _slider.maxValue = limits.y;
        _slider.value = setValue.HasValue ? setValue.Value : limits.x;
    }
}