using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Hud _hud = default;
    [SerializeField] private EntitiesProcessor _entitiesProcessor = default;
    [SerializeField] private ProgramSettings _settings = default;
    [SerializeField] private ScriptableFormula[] _formulas = default;


    void Start()
    {
        _entitiesProcessor.Init(new Pool(), _settings.EntityPrefab,_settings.Offset);
        _hud.OnSliderChanged(_entitiesProcessor.OnSliderChanged);
        _hud.OnFormulaChanged(_entitiesProcessor.OnFormulaChanged);
        _hud.Init(_settings, _formulas);
    }
}