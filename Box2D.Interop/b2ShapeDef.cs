namespace Box2D.Interop;

public unsafe partial struct b2ShapeDef
{
    public void* userData;

    public float friction;

    public float restitution;

    public float density;

    public b2Filter filter;

    [NativeTypeName("uint32_t")]
    public uint customColor;

    [NativeTypeName("_Bool")]
    public bool isSensor;

    [NativeTypeName("_Bool")]
    public bool enableSensorEvents;

    [NativeTypeName("_Bool")]
    public bool enableContactEvents;

    [NativeTypeName("_Bool")]
    public bool enableHitEvents;

    [NativeTypeName("_Bool")]
    public bool enablePreSolveEvents;

    [NativeTypeName("_Bool")]
    public bool forceContactCreation;

    [NativeTypeName("int32_t")]
    public int internalValue;
}
