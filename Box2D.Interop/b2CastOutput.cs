namespace Box2D.Interop;

public partial struct b2CastOutput
{
    public b2Vec2 normal;

    public b2Vec2 point;

    public float fraction;

    [NativeTypeName("int32_t")]
    public int iterations;

    [NativeTypeName("_Bool")]
    public bool hit;
}
