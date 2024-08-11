namespace Box2D.Interop;

public unsafe partial struct b2ContactEvents
{
    public b2ContactBeginTouchEvent* beginEvents;

    public b2ContactEndTouchEvent* endEvents;

    public b2ContactHitEvent* hitEvents;

    [NativeTypeName("int32_t")]
    public int beginCount;

    [NativeTypeName("int32_t")]
    public int endCount;

    [NativeTypeName("int32_t")]
    public int hitCount;
}
