namespace Box2D.Interop;

public partial struct b2DistanceOutput
{
    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 pointA;

    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 pointB;

    public float distance;

    [NativeTypeName("int32_t")]
    public int iterations;

    [NativeTypeName("int32_t")]
    public int simplexCount;
}
