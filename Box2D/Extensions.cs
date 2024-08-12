using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Box2D; 

public static class Extensions {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static PinHelper<T> GcPin<T>(this T obj) => new(obj);
    
}