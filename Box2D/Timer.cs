using Box2D.Interop;

namespace Box2D;

public class Timer {
    private b2Timer _b2Timer = B2.CreateTimer();

    public unsafe ulong GetTicks() {
        fixed(b2Timer* ptr = &_b2Timer)
            return (ulong)B2.GetTicks(ptr);
    }

    public unsafe float GetMilliseconds() {
        fixed(b2Timer* ptr = &_b2Timer)
            return B2.GetMilliseconds(ptr);
    }
    
    public unsafe float GetMillisecondsAndReset() {
        fixed(b2Timer* ptr = &_b2Timer)
            return B2.GetMillisecondsAndReset(ptr);
    }
    
    public static void SleepMilliseconds(int milliseconds) {
        B2.SleepMilliseconds(milliseconds);
    }
}