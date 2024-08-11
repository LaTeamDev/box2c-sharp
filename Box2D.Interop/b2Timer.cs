namespace Box2D.Interop;

public partial struct b2Timer
{
    [NativeTypeName("unsigned long long")]
    public ulong start_sec;

    [NativeTypeName("unsigned long long")]
    public ulong start_usec;
}
