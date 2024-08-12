using System.Numerics;

namespace Box2D;

public partial struct Transform
{
    public Vector2 Position;

    public Rotation Rotation;

    public Transform Identity => new Transform {
        Position = Vector2.Zero, 
        Rotation = new Rotation { C = 1f, S = 0f }
    };
}
