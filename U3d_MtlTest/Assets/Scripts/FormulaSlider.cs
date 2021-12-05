using System;
using UnityEngine;
using UnityEngine.UI;

public class FormulaSlider : MonoBehaviour
{
    [SerializeField] private Text _value = default;
    [SerializeField] private Slider _slider = default;
    private Action<int> _onSliderChanged;

    private void Start() => 
        _slider.onValueChanged.AddListener(_ => OnValueChanged());

    public void OnSliderChanged(Action<int> onSliderChanged) =>
        _onSliderChanged += onSliderChanged;

    private void OnValueChanged()
    {
        _value.text = ((int)_slider.value).ToString();
        _onSliderChanged?.Invoke((int)_slider.value);
    }

    public void Init(Vector2Int limits)
    {
        _slider.minValue = limits.x;
        _slider.maxValue = limits.y;
    }
}