using System.Numerics;

namespace Box2D;

public partial struct Matrix2x2
{
    public Vector2 Cx;

    public Vector2 Cy;

    public Matrix2x2 Identity => new Matrix2x2 { Cx = new(1f, 0f), Cy = new(0f, 1f) };
    public Matrix2x2 Zero => new Matrix2x2 { Cx = new(0f, 0f), Cy = new(0f, 0f) };

    public Matrix2x2(Vector2 cx, Vector2 cy) {
        Cx = cx;
        Cy = cy;
    }

    public Matrix2x2(float c11, float c21, float c12, float c22) 
        : this (new Vector2(c11, c21), new Vector2(c12, c22)) {} 
    
    /// Multiply a 2-by-2 matrix times a 2D vector
    public static Vector2 MultiplyByVector( Matrix2x2 A, Vector2 v )
    {
        Vector2 u = new (
            A.Cx.X * v.X + A.Cy.X * v.Y,
            A.Cx.Y * v.X + A.Cy.Y * v.Y
        );
        return u;
    }

    /// Get the inverse of a 2-by-2 matrix
    public static Matrix2x2 Invert( Matrix2x2 A )
    {
        float a = A.Cx.X, b = A.Cy.X, c = A.Cx.Y, d = A.Cy.Y;
        var det = a * d - b * c;
        if ( det != 0.0f )
        {
            det = 1.0f / det;
        }

        var B = new Matrix2x2(
            det * d, -det * c,
            -det * b, det * a
        );
        return B;
    }

    /// Solve A * x = b, where b is a column vector. This is more efficient
    /// than computing the inverse in one-shot cases.
    public static Vector2 Solve( Matrix2x2 A, Vector2 b )
    {
        float a11 = A.Cx.X, a12 = A.Cy.X, a21 = A.Cx.Y, a22 = A.Cy.Y;
        var det = a11 * a22 - a12 * a21;
        if ( det != 0.0f )
        {
            det = 1.0f / det;
        }
        var x = new Vector2(det * ( a22 * b.X - a12 * b.Y ), det * ( a11 * b.Y - a21 * b.X ));
        return x;
    }
}
