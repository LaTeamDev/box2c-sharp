namespace Box2D.Interop;

public partial struct b2DistanceInput
{
    public b2DistanceProxy proxyA;

    public b2DistanceProxy proxyB;

    public b2Transform transformA;

    public b2Transform transformB;

    [NativeTypeName("_Bool")]
    public bool useRadii;
}
