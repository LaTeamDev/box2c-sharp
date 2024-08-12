namespace Box2D.Interop;

public partial struct b2SimplexVertex
{
    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 wA;

    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 wB;

    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 w;

    public float a;

    [NativeTypeName("int32_t")]
    public int indexA;

    [NativeTypeName("int32_t")]
    public int indexB;
}
