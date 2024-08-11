namespace Box2D.Interop;

public unsafe partial struct b2SensorEvents
{
    public b2SensorBeginTouchEvent* beginEvents;

    public b2SensorEndTouchEvent* endEvents;

    [NativeTypeName("int32_t")]
    public int beginCount;

    [NativeTypeName("int32_t")]
    public int endCount;
}
