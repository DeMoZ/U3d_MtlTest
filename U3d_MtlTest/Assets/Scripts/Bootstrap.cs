using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private CameraOrbit _cameraOrbit = default;
    [SerializeField] private Hud _hud = default;
    [SerializeField] private EntitiesProcessor _entitiesProcessor = default;
    [SerializeField] private ProgramSettings _settings = default;
    [SerializeField] private Formula[] _formulas = default;

    void Start()
    {
        _cameraOrbit.Init(_settings.Offset);
        _entitiesProcessor.Init(new Pool(), _settings.EntityPrefab, _settings.Offset, _formulas);
        _hud.OnSliderChanged(_entitiesProcessor.OnSliderChanged);
        _hud.OnFormulaChanged(_entitiesProcessor.OnFormulaChanged);
        _hud.OnSliderChanged(_cameraOrbit.ChangeZoom);
        _hud.Init(_settings, _formulas);
    }
}