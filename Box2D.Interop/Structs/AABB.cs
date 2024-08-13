using System.Numerics;
using System.Runtime.InteropServices;

namespace Box2D;

public partial struct AABB {
    public Vector2 LowerBound;

    public Vector2 UpperBound;

    public AABB(Vector2 lowerBound, Vector2 upperBound) {
        LowerBound = lowerBound;
        UpperBound = upperBound;
    }

    public AABB(float x1, float y1, float x2, float y2) :
        this(new Vector2(x1, x2), new Vector2(x2, y2)) { }
    
    // Used code from https://github.com/erincatto/box2c/blob/main/include/box2d/math_functions.h

    /// Does a fully contain b
    public bool Contains(AABB b) {
        var s = true;
        s = s && LowerBound.X <= b.LowerBound.X;
        s = s && LowerBound.Y <= b.LowerBound.Y;
        s = s && b.UpperBound.X <= UpperBound.X;
        s = s && b.UpperBound.Y <= UpperBound.Y;
        return s;
    }

    /// Get the center of the AABB.
    public Vector2 Center =>
        new (0.5f * (LowerBound.X + UpperBound.X), 0.5f * (LowerBound.Y + UpperBound.Y));

    /// Get the extents of the AABB (half-widths).
    public Vector2 Extents => new(0.5f * ( UpperBound.X - LowerBound.X ), 0.5f * ( UpperBound.Y - LowerBound.Y ));

    /// Union of two AABBs
    public static AABB Union( AABB a, AABB b )
    {
        AABB c;
        c.LowerBound.X = MathF.Min( a.LowerBound.X, b.LowerBound.X );
        c.LowerBound.Y = MathF.Min( a.LowerBound.Y, b.LowerBound.Y );
        c.UpperBound.X = MathF.Min( a.UpperBound.X, b.UpperBound.X );
        c.UpperBound.Y = MathF.Min( a.UpperBound.Y, b.UpperBound.Y );
        return c;
    }
    
    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2AABB_IsValid", ExactSpelling = true)]
    private static extern bool _isValid(AABB rotation);

    public bool IsValid => _isValid(this);
}
