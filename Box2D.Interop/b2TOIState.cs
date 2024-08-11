namespace Box2D.Interop;

[NativeTypeName("unsigned int")]
public enum b2TOIState : uint
{
    b2_toiStateUnknown,
    b2_toiStateFailed,
    b2_toiStateOverlapped,
    b2_toiStateHit,
    b2_toiStateSeparated,
}
