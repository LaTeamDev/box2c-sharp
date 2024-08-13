using System.Numerics;

namespace Box2D;

public partial struct Transform
{
    public Vector2 Position;

    public Rotation Rotation;

    public Transform Identity => new Transform {
        Position = Vector2.Zero, 
        Rotation = Rotation.Identity
    };
    
    // Used code from https://github.com/erincatto/box2c/blob/main/include/box2d/math_functions.h

    /// Transform a point (e.g. local space to world space)
    public static Vector2 TransformPoint( Transform t, Vector2 p )
    {
        var x = ( t.Rotation.C * p.X - t.Rotation.S * p.Y ) + t.Position.X;
        var y = ( t.Rotation.S * p.X + t.Rotation.C * p.Y ) + t.Position.Y;

        return new (x, y);
    }

    /// Inverse transform a point (e.g. world space to local space)
    public static Vector2 InverseTransformPoint( Transform t, Vector2 p )
    {
        var vx = p.X - t.Position.X;
        var vy = p.Y - t.Position.Y;
        return new( t.Rotation.C * vx + t.Rotation.S * vy, -t.Rotation.S * vx + t.Rotation.C * vy );
    }

    public static Transform Multiply( Transform a, Transform b )
    {
        Transform c;
        c.Rotation = a.Rotation * b.Rotation;
        c.Position = Rotation.RotateVector( a.Rotation, b.Position ) + a.Position;
        return c;
    }

    public static Transform operator *(Transform a, Transform b) => Multiply(a, b);
    
    public static Transform InverseMultiply(Transform a, Transform b)
    {
        Transform c;
        c.Rotation = Rotation.InverseMultiply(a.Rotation, b.Rotation);
        c.Position = Rotation.InverseRotateVector(a.Rotation, b.Position-a.Position);
        return c;
    }
}
