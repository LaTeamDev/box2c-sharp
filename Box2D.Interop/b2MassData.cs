namespace Box2D.Interop;

public partial struct b2MassData
{
    public float mass;

    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 center;

    public float rotationalInertia;
}
