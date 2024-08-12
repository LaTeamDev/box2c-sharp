namespace Box2D.Interop;

public partial struct b2Sweep
{
    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 localCenter;

    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 c1;

    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 c2;

    [NativeTypeName("b2Rot")]
    public Rotation q1;

    [NativeTypeName("b2Rot")]
    public Rotation q2;
}
