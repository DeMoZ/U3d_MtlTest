using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    [SerializeField] private FormulaSlider _sliderX = default;
    [SerializeField] private FormulaSlider _sliderZ = default;
    [SerializeField] private FormulaSlider _sliderAmplitude = default;
    [SerializeField] private Text _description = default;
    [SerializeField] private Dropdown _dropdown = default;

    private Formula[] _formulas;

    private event Action<int?, int?> _onSizeChanged;
    private event Action<float> _onAmplitudeChanged;
    private event Action<int> _onFormulaChanged;

    public void OnSizeChanged(Action<int?, int?> onSizeChanged) =>
        _onSizeChanged += onSizeChanged;

    public void OnAmplitudeChanged(Action<float> onAmplitudeChanged) =>
        _onAmplitudeChanged += onAmplitudeChanged;

    public void OnFormulaChanged(Action<int> onFormulaChanged) =>
        _onFormulaChanged += onFormulaChanged;

    public void Init(ProgramSettings settings, Formula[] formulas)
    {
        SubscribeToComponents();
        
        _formulas = formulas;

        _sliderX.Init(settings.SizeX);
        _sliderZ.Init(settings.SizeZ);
        _sliderAmplitude.Init(new Vector2(0.1f, 20), 1);

        _dropdown.options = _formulas.Select(formula => new Dropdown.OptionData(formula.name)).ToList();
        _dropdown.onValueChanged.AddListener(id =>
        {
            _description.text = _formulas[id].Description;
            _onFormulaChanged?.Invoke(id);
        });

        _dropdown.value = -1;
    }

    private void SubscribeToComponents()
    {
        _sliderX.ValueChanged(value => _onSizeChanged?.Invoke((int)value, null));
        _sliderZ.ValueChanged(value => _onSizeChanged?.Invoke(null, (int)value));
        _sliderAmplitude.ValueChanged(value => _onAmplitudeChanged?.Invoke(value));
    }
}