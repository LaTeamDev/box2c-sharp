using Box2D.Interop;

namespace Box2D;

public class Timer {
    private b2Timer _b2timer = B2.CreateTimer();

    public unsafe ulong GetTicks() {
        using var pin = _b2timer.GcPin();
        return (ulong)B2.GetTicks(pin.Pointer);
    }

    public unsafe float GetMilliseconds() {
        using var pin = _b2timer.GcPin();
        return B2.GetMilliseconds(pin.Pointer);
    }
    
    public unsafe float GetMillisecondsAndReset() {
        using var pin = _b2timer.GcPin();
        return B2.GetMillisecondsAndReset(pin.Pointer);
    }
    
    public static void SleepMilliseconds(int milliseconds) {
        B2.SleepMilliseconds(milliseconds);
    }
}