namespace Box2D.Interop;

public unsafe partial struct b2ChainDef
{
    public void* userData;

    [NativeTypeName("const b2Vec2 *")]
    public System.Numerics.Vector2* points;

    [NativeTypeName("int32_t")]
    public int count;

    public float friction;

    public float restitution;

    public b2Filter filter;

    [NativeTypeName("_Bool")]
    public bool isLoop;

    [NativeTypeName("int32_t")]
    public int internalValue;
}
