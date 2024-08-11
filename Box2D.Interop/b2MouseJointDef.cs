namespace Box2D.Interop;

public unsafe partial struct b2MouseJointDef
{
    public b2BodyId bodyIdA;

    public b2BodyId bodyIdB;

    public b2Vec2 target;

    public float hertz;

    public float dampingRatio;

    public float maxForce;

    [NativeTypeName("_Bool")]
    public bool collideConnected;

    public void* userData;

    [NativeTypeName("int32_t")]
    public int internalValue;
}
