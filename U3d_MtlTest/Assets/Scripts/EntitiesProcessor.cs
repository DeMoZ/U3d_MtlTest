using UnityEngine;

public class EntitiesProcessor : MonoBehaviour
{
    private GameObject _prefab;
    private float _offset;
    private Vector2Int _size = new Vector2Int(-1, -1);
    private Transform[] _entities;
    private Pool _pool;

    public void Init(Pool pool, GameObject prefab, float offset)
    {
        _pool = pool;
        _prefab = prefab;
        _offset = offset;
    }

    public void OnSliderChanged(int? x, int? z)
    {
        Debug.Log($"Slider changed");

        if (x.HasValue) _size.x = x.Value;
        if (z.HasValue) _size.y = z.Value;

        if (_size.x > 0 && _size.y > 0)
        {
            ClearEntities();
            PopulateEntities();
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
        Debug.Log($"Formula selected {id}");
    }

    private void PopulateEntities()
    {
        _entities = new Transform[_size.x * _size.y];
        var xMiddle = (_size.x + _size.x * _offset) / 2;
        var zMiddle = (_size.y + _size.y * _offset) / 2;
        var count = 0;

        for (var x = 0; x < _size.x; x++)
        {
            for (var z = 0; z < _size.y; z++)
            {
                _entities[count] = _pool.Get(_prefab, transform).transform;
                var xPos = x + _offset * x - xMiddle;
                var zPos = z + _offset * z - zMiddle;
                _entities[count].position = new Vector3(xPos, 0, zPos);
                count++;
            }
        }
    }
}