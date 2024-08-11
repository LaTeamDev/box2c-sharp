namespace Box2D.Interop;

public unsafe partial struct b2DistanceJointDef
{
    public b2BodyId bodyIdA;

    public b2BodyId bodyIdB;

    public b2Vec2 localAnchorA;

    public b2Vec2 localAnchorB;

    public float length;

    [NativeTypeName("_Bool")]
    public bool enableSpring;

    public float hertz;

    public float dampingRatio;

    [NativeTypeName("_Bool")]
    public bool enableLimit;

    public float minLength;

    public float maxLength;

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
