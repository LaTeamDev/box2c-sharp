namespace Box2D.Interop;

public partial struct b2SimplexVertex
{
    public b2Vec2 wA;

    public b2Vec2 wB;

    public b2Vec2 w;

    public float a;

    [NativeTypeName("int32_t")]
    public int indexA;

    [NativeTypeName("int32_t")]
    public int indexB;
}
