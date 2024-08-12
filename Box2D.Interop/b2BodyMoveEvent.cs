namespace Box2D.Interop;

public unsafe partial struct b2BodyMoveEvent
{
    [NativeTypeName("b2Transform")]
    public Transform transform;

    public b2BodyId bodyId;

    public void* userData;

    [NativeTypeName("_Bool")]
    public bool fellAsleep;
}
