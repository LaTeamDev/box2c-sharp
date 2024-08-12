namespace Box2D.Interop;

public partial struct b2Circle
{
    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 center;

    public float radius;
}
