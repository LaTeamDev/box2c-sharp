namespace Box2D.Interop;

public partial struct b2DistanceInput
{
    public b2DistanceProxy proxyA;

    public b2DistanceProxy proxyB;

    [NativeTypeName("b2Transform")]
    public Transform transformA;

    [NativeTypeName("b2Transform")]
    public Transform transformB;

    [NativeTypeName("_Bool")]
    public bool useRadii;
}
