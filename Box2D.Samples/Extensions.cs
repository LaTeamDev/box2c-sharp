using System.Runtime.CompilerServices;
using Box2D.Interop;
using ZeroElectric.Vinculum;

namespace Box2D; 

public static class Extensions {
    public unsafe static Color ToRaylib(this b2HexColor color) {
        return *(Color*)Unsafe.AsPointer(ref color);
    }
}