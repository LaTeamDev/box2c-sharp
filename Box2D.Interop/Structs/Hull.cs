using System.Runtime.CompilerServices;
using Box2D.Interop;

namespace Box2D;

public partial struct Hull
{
    [NativeTypeName("b2Vec2[8]")]
    public _points_e__FixedBuffer points;

    [NativeTypeName("int32_t")]
    public int count;

    public partial struct _points_e__FixedBuffer
    {
        public System.Numerics.Vector2 e0;
        public System.Numerics.Vector2 e1;
        public System.Numerics.Vector2 e2;
        public System.Numerics.Vector2 e3;
        public System.Numerics.Vector2 e4;
        public System.Numerics.Vector2 e5;
        public System.Numerics.Vector2 e6;
        public System.Numerics.Vector2 e7;

        public unsafe ref System.Numerics.Vector2 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                fixed (System.Numerics.Vector2* pThis = &e0)
                {
                    return ref pThis[index];
                }
            }
        }
    }

    public static unsafe bool Validate(ref Hull hull) {
        return B2.ValidateHull((Hull*) Unsafe.AsPointer(ref hull));
    }
}
