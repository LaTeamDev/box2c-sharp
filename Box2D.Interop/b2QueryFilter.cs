namespace Box2D.Interop;

public partial struct b2QueryFilter
{
    [NativeTypeName("uint32_t")]
    public uint categoryBits;

    [NativeTypeName("uint32_t")]
    public uint maskBits;
}
