namespace Box2D.Interop;

public unsafe partial struct b2DistanceCache
{
    [NativeTypeName("uint16_t")]
    public ushort count;

    [NativeTypeName("uint8_t[3]")]
    public fixed byte indexA[3];

    [NativeTypeName("uint8_t[3]")]
    public fixed byte indexB[3];
}
