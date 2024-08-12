namespace Box2D.Interop;

public partial struct b2SegmentDistanceResult
{
    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 closest1;

    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 closest2;

    public float fraction1;

    public float fraction2;

    public float distanceSquared;
}
