using System.Runtime.CompilerServices;

namespace Box2D.Interop;

public partial struct b2Manifold
{
    [NativeTypeName("b2ManifoldPoint[2]")]
    public _points_e__FixedBuffer points;

    public b2Vec2 normal;

    [NativeTypeName("int32_t")]
    public int pointCount;

    public partial struct _points_e__FixedBuffer
    {
        public b2ManifoldPoint e0;
        public b2ManifoldPoint e1;

        public unsafe ref b2ManifoldPoint this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                fixed (b2ManifoldPoint* pThis = &e0)
                {
                    return ref pThis[index];
                }
            }
        }
    }
}
