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
        
        _hud.OnSizeChanged(_entitiesProcessor.OnSizeChanged);
        _hud.OnAmplitudeChanged(_entitiesProcessor.OnAmplitudeChanged);
        _hud.OnFormulaChanged(_entitiesProcessor.OnFormulaChanged);
        _hud.OnSizeChanged(_cameraOrbit.ChangeZoom);
        
        _hud.Init(_settings, _formulas);
    }
}