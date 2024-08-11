namespace Box2D.Interop;

public unsafe partial struct b2BodyDef
{
    public b2BodyType type;

    public b2Vec2 position;

    public b2Rot rotation;

    public b2Vec2 linearVelocity;

    public float angularVelocity;

    public float linearDamping;

    public float angularDamping;

    public float gravityScale;

    public float sleepThreshold;

    public void* userData;

    [NativeTypeName("_Bool")]
    public bool enableSleep;

    [NativeTypeName("_Bool")]
    public bool isAwake;

    [NativeTypeName("_Bool")]
    public bool fixedRotation;

    [NativeTypeName("_Bool")]
    public bool isBullet;

    [NativeTypeName("_Bool")]
    public bool isEnabled;

    [NativeTypeName("_Bool")]
    public bool automaticMass;

    [NativeTypeName("int32_t")]
    public int internalValue;
}
