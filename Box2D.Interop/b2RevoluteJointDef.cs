namespace Box2D.Interop;

public unsafe partial struct b2RevoluteJointDef
{
    public b2BodyId bodyIdA;

    public b2BodyId bodyIdB;

    public b2Vec2 localAnchorA;

    public b2Vec2 localAnchorB;

    public float referenceAngle;

    [NativeTypeName("_Bool")]
    public bool enableSpring;

    public float hertz;

    public float dampingRatio;

    [NativeTypeName("_Bool")]
    public bool enableLimit;

    public float lowerAngle;

    public float upperAngle;

    [NativeTypeName("_Bool")]
    public bool enableMotor;

    public float maxMotorTorque;

    public float motorSpeed;

    public float drawSize;

    [NativeTypeName("_Bool")]
    public bool collideConnected;

    public void* userData;

    [NativeTypeName("int32_t")]
    public int internalValue;
}
