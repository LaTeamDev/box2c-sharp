namespace Box2D.Interop;

public partial struct b2SmoothSegment
{
    public b2Vec2 ghost1;

    public b2Segment segment;

    public b2Vec2 ghost2;

    [NativeTypeName("int32_t")]
    public int chainId;
}
