namespace Box2D.Interop;

public partial struct b2TOIInput
{
    public b2DistanceProxy proxyA;

    public b2DistanceProxy proxyB;

    public b2Sweep sweepA;

    public b2Sweep sweepB;

    public float tMax;
}
