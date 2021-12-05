using UnityEngine;

[CreateAssetMenu]
public class ProgramSettings : ScriptableObject
{
    public GameObject EntityPrefab;
    public Vector2Int SizeX;
    public Vector2Int SizeZ;
    public float Offset;
}