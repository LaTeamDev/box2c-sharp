namespace Box2D.Interop;

public unsafe partial struct b2MotorJointDef
{
    public b2BodyId bodyIdA;

    public b2BodyId bodyIdB;

    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 linearOffset;

    public float angularOffset;

    public float maxForce;

    public float maxTorque;

    public float correctionFactor;

    [NativeTypeName("_Bool")]
    public bool collideConnected;

    public void* userData;

    [NativeTypeName("int32_t")]
    public int internalValue;
}
