namespace Box2D.Interop;

public partial struct b2Capsule
{
    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 center1;

    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 center2;

    public float radius;
}
