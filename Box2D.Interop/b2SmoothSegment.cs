namespace Box2D.Interop;

public partial struct b2SmoothSegment
{
    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 ghost1;

    public Segment segment;

    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 ghost2;

    [NativeTypeName("int32_t")]
    public int chainId;
}
