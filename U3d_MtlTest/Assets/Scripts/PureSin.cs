using UnityEngine;

[CreateAssetMenu]
public class PureSin : Formula
{
    public override float Compute(int x, int z, float time)
    {
        return Mathf.Sin(time);
    }
}