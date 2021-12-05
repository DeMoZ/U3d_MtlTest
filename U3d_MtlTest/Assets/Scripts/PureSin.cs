using UnityEngine;

[CreateAssetMenu]
public class PureSin : Formula
{
    public override float Compute(int x, int z, float time)
    {
        Debug.Log($"value = {time}");
        return Mathf.Sin(time);
    }
}