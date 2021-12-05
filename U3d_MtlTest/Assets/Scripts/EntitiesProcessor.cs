using System.Collections;
using UnityEngine;

public class EntitiesProcessor : MonoBehaviour
{
    private GameObject _prefab;
    private float _offset;
    private Vector2Int _size = new Vector2Int(-1, -1);
    private Transform[,] _entities;
    private Pool _pool;
    private Coroutine _ieUpdate;
    private ScriptableFormula[] _formulas;
    private ScriptableFormula _formula;

    public void Init(Pool pool, GameObject prefab, float offset, ScriptableFormula[] formulas)
    {
        _pool = pool;
        _prefab = prefab;
        _offset = offset;
        _formulas = formulas;
    }

    public void OnSliderChanged(int? x, int? z)
    {
        if (x.HasValue) _size.x = x.Value;
        if (z.HasValue) _size.y = z.Value;

        StopUpdateRoutine();

        if (_size.x > 0 && _size.y > 0)
        {
            ClearEntities();
            PopulateEntities();
        }

        _ieUpdate = StartCoroutine(IEUpdate());
    }

    private IEnumerator IEUpdate()
    {
        while (true)
        {
            yield return null;
            for (var x = 0; x < _entities.GetLength(0); x++)
            {
                for (var z = 0; z < _entities.GetLength(1); z++)
                {
                    _entities[x, z].position = new Vector3(
                        _entities[x, z].position.x, 
                        _formula.Compute(x, z, Time.time),
                        //_formula.Compute(x, z, Time.deltaTime),
                        _entities[x, z].position.z);
                }
            }
        }
    }

    private void ClearEntities()
    {
        if (_entities == null) return;

        foreach (var entity in _entities)
            _pool.Return(entity.gameObject);
    }

    public void OnFormulaChanged(int id)
    {
        StopUpdateRoutine();
        _formula = _formulas[id];
        _ieUpdate = StartCoroutine(IEUpdate());
    }

    private void PopulateEntities()
    {
        _entities = new Transform[_size.x, _size.y];
        var xMiddle = (_size.x + _size.x * _offset) / 2;
        var zMiddle = (_size.y + _size.y * _offset) / 2;

        for (var x = 0; x < _size.x; x++)
        {
            for (var z = 0; z < _size.y; z++)
            {
                _entities[x, z] = _pool.Get(_prefab, transform).transform;
                var xPos = x + _offset * x - xMiddle;
                var zPos = z + _offset * z - zMiddle;
                _entities[x, z].position = new Vector3(xPos, 0, zPos);
            }
        }
    }

    private void StopUpdateRoutine()
    {
        if (_ieUpdate != null)
        {
            StopCoroutine(_ieUpdate);
            _ieUpdate = null;
        }
    }
}