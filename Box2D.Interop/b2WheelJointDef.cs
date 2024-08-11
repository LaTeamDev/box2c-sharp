namespace Box2D.Interop;

public unsafe partial struct b2WheelJointDef
{
    public b2BodyId bodyIdA;

    public b2BodyId bodyIdB;

    public b2Vec2 localAnchorA;

    public b2Vec2 localAnchorB;

    public b2Vec2 localAxisA;

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

    public float maxMotorTorque;

    public float motorSpeed;

    [NativeTypeName("_Bool")]
    public bool collideConnected;

    public void* userData;

    [NativeTypeName("int32_t")]
    public int internalValue;
}
