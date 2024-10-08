namespace Box2D.Interop;

public unsafe partial struct b2WeldJointDef
{
    public b2BodyId bodyIdA;

    public b2BodyId bodyIdB;

    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 localAnchorA;

    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 localAnchorB;

    public float referenceAngle;

    public float linearHertz;

    public float angularHertz;

    public float linearDampingRatio;

    public float angularDampingRatio;

    [NativeTypeName("_Bool")]
    public bool collideConnected;

    public void* userData;

    [NativeTypeName("int32_t")]
    public int internalValue;
}
