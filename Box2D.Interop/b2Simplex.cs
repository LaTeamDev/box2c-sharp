namespace Box2D.Interop;

public partial struct b2Simplex
{
    public b2SimplexVertex v1;

    public b2SimplexVertex v2;

    public b2SimplexVertex v3;

    [NativeTypeName("int32_t")]
    public int count;
}
