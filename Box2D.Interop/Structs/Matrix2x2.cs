using System.Numerics;

namespace Box2D;

public partial struct Matrix2x2
{
    public Vector2 Cx;

    public Vector2 Cy;

    public Matrix2x2 Identity => new Matrix2x2 { Cx = new(1f, 0f), Cy = new(0f, 1f) };
    public Matrix2x2 Zero => new Matrix2x2 { Cx = new(0f, 0f), Cy = new(0f, 1f) };
}
