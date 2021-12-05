using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    [SerializeField] private FormulaSlider _sliderX = default;
    [SerializeField] private FormulaSlider _sliderZ = default;
    [SerializeField] private Text _description = default;
    [SerializeField] private Dropdown _dropdown = default;

    private ScriptableFormula[] _formulas;

    private event Action<int?, int?> _onSliderChanged;
    private event Action<int> _onFormulaChanged;

    public void OnSliderChanged(Action<int?, int?> onSliderChanged) =>
        _onSliderChanged += onSliderChanged;

    public void OnFormulaChanged(Action<int> onFormulaChanged) =>
        _onFormulaChanged += onFormulaChanged;

    private void Start()
    {
        _sliderX.OnSliderChanged(value => { _onSliderChanged?.Invoke(value, null); });
        _sliderZ.OnSliderChanged(value => { _onSliderChanged?.Invoke(null, value); });
    }

    public void Init(ProgramSettings settings, ScriptableFormula[] formulas)
    {
        _formulas = formulas;

        _sliderX.Init(settings.SizeX);
        _sliderZ.Init(settings.SizeZ);

        _dropdown.options = _formulas.Select(formula => new Dropdown.OptionData(formula.name)).ToList();
        _dropdown.onValueChanged.AddListener(id =>
        {
            _description.text = _formulas[id].Description;
            _onFormulaChanged?.Invoke(id);
        });

        _dropdown.value = -1;
    }
}