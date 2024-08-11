namespace Box2D.Interop;

public partial struct b2WorldId
{
    [NativeTypeName("uint16_t")]
    public ushort index1;

    [NativeTypeName("uint16_t")]
    public ushort revision;
}
