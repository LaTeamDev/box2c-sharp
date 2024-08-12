namespace Box2D.Interop;

public unsafe partial struct b2PrismaticJointDef
{
    public b2BodyId bodyIdA;

    public b2BodyId bodyIdB;

    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 localAnchorA;

    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 localAnchorB;

    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 localAxisA;

    public float referenceAngle;

    [NativeTypeName("_Bool")]
    public bool enableSpring;

    public float hertz;

    public float dampingRatio;

    [NativeTypeName("_Bool")]
    public bool enableLimit;

    public float lowerTranslation;

    public float upperTranslation;

    [NativeTypeName("_Bool")]
    public bool enableMotor;

    public float maxMotorForce;

    public float motorSpeed;

    [NativeTypeName("_Bool")]
    public bool collideConnected;

    public void* userData;

    [NativeTypeName("int32_t")]
    public int internalValue;
}
