namespace Box2D.Interop;

public partial struct b2ShapeId
{
    [NativeTypeName("int32_t")]
    public int index1;

    [NativeTypeName("uint16_t")]
    public ushort world0;

    [NativeTypeName("uint16_t")]
    public ushort revision;
}
