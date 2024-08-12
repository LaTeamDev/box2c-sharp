namespace Box2D.Interop;

public partial struct b2RayCastInput
{
    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 origin;

    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 translation;

    public float maxFraction;
}
