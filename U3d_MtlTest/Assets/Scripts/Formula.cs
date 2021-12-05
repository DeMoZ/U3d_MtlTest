using UnityEngine;

public abstract class Formula : ScriptableObject
{
    public string Name;
    public string Description;

    public abstract float Compute(int x, int z, float time);
}