using UnityEngine;

/// <summary>
/// in case that the calculation formula may be changed a lot
/// </summary>
public interface Formula
{
    string Name { get; }
    string Desctiption { get; }
    Vector3 Compute(int x, int z, float time);
}

public class Cosinus : Formula
{
    private string _name = "Cosinus";
    private string _description = @"Y = Cos(X+Time) *Cos(X+Time)";

    public string Name => _name;
    public string Desctiption => _description;

    public Vector3 Compute(int x, int z, float time)
    {
        return Vector3.zero;
    }
}

public class Sinus : Formula
{
    private string _name = "Sinus";
    private string _description = @"Y = Sin(X+Time) *Sin(X+Time)";

    public string Name => _name;
    public string Desctiption => _description;

    public Vector3 Compute(int x, int z, float time)
    {
        return Vector3.zero;
    }
}

public class Tangent : Formula
{
    private string _name = "Tangent";
    private string _description = @"Y = Tan(X+Time) *Tan(X+Time)";

    public string Name => _name;
    public string Desctiption => _description;

    public Vector3 Compute(int x, int z, float time)
    {
        return Vector3.zero;
    }
}

public class Cotangent : Formula
{
    private string _name = "Cotangent";
    private string _description = @"Y = Cotan(X+Time) *Cotan(X+Time)";

    public string Name => _name;
    public string Desctiption => _description;

    public Vector3 Compute(int x, int z, float time)
    {
        return Vector3.zero;
    }
}