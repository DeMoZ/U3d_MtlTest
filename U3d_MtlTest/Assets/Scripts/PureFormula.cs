using System;
using UnityEngine;

[CreateAssetMenu]
public class PureFormula : Formula
{
    public TrigonometricFunction Function;

    public override float Compute(int x, int z, float time)
    {
        switch (Function)
        {
            case TrigonometricFunction.Sin:
                return Mathf.Sin(time);
            case TrigonometricFunction.Cos:
                return Mathf.Cos(time);
            case TrigonometricFunction.Tan:
                return Mathf.Tan(time);
            case TrigonometricFunction.Cotang:
                return 1 / Mathf.Tan(time);
            default:
                throw new ArgumentOutOfRangeException(nameof(Function), Function, "No fanc name found");
        }
    }
}