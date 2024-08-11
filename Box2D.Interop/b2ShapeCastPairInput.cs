namespace Box2D.Interop;

public partial struct b2ShapeCastPairInput
{
    public b2DistanceProxy proxyA;

    public b2DistanceProxy proxyB;

    public b2Transform transformA;

    public b2Transform transformB;

    public b2Vec2 translationB;

    public float maxFraction;
}
