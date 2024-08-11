namespace Box2D.Interop;

public partial struct b2DistanceOutput
{
    public b2Vec2 pointA;

    public b2Vec2 pointB;

    public float distance;

    [NativeTypeName("int32_t")]
    public int iterations;

    [NativeTypeName("int32_t")]
    public int simplexCount;
}
