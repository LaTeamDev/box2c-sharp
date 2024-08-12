namespace Box2D.Interop;

public partial struct b2ShapeCastPairInput
{
    public b2DistanceProxy proxyA;

    public b2DistanceProxy proxyB;

    [NativeTypeName("b2Transform")]
    public Transform transformA;

    [NativeTypeName("b2Transform")]
    public Transform transformB;

    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 translationB;

    public float maxFraction;
}
