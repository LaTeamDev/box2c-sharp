namespace Box2D.Interop;

public unsafe partial struct b2BodyEvents
{
    public b2BodyMoveEvent* moveEvents;

    [NativeTypeName("int32_t")]
    public int moveCount;
}
