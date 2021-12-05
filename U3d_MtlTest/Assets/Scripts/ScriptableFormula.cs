using System;
using UnityEngine;

[CreateAssetMenu]
public class ScriptableFormula : ScriptableObject
{
    public string Name;
    public string Description;

    public TrigonometricFunction FunctionA;
    public TrigonometricFunction FunctionB;

    public float Compute(int x, int z, float time)
    {
        var valA =Count (FunctionA, x + time);
        var valB =Count (FunctionB, z + time);

        return valA * valB;
    }

    private float Count(TrigonometricFunction func, float value)
    {
        switch (func)
        {
            case TrigonometricFunction.Sin:
                return Mathf.Sin(value);
            case TrigonometricFunction.Cos:
                return Mathf.Cos(value);
            case TrigonometricFunction.Tan:
                return Mathf.Tan(value);
            case TrigonometricFunction.Cotang:
                return 1 / Mathf.Tan(value);
            default:
                throw new ArgumentOutOfRangeException(nameof(func), func, "No fanc name found");
        }
    }
}