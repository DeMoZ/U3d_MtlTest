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
                break;
            case TrigonometricFunction.Cos:
                return Mathf.Cos(value);
                break;
            case TrigonometricFunction.Tan:
                return Mathf.Tan(value);
                break;
            case TrigonometricFunction.Cotang:
                return 1 / Mathf.Tan(value);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(func), func, "No fanc name found");
        }
    }
}