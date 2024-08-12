namespace Box2D.Interop;

public partial struct b2CastOutput
{
    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 normal;

    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 point;

    public float fraction;

    [NativeTypeName("int32_t")]
    public int iterations;

    [NativeTypeName("_Bool")]
    public bool hit;
}
