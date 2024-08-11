using System.Runtime.CompilerServices;

namespace Box2D.Interop;

public partial struct b2Polygon
{
    [NativeTypeName("b2Vec2[8]")]
    public _vertices_e__FixedBuffer vertices;

    [NativeTypeName("b2Vec2[8]")]
    public _normals_e__FixedBuffer normals;

    public b2Vec2 centroid;

    public float radius;

    [NativeTypeName("int32_t")]
    public int count;

    public partial struct _vertices_e__FixedBuffer
    {
        public b2Vec2 e0;
        public b2Vec2 e1;
        public b2Vec2 e2;
        public b2Vec2 e3;
        public b2Vec2 e4;
        public b2Vec2 e5;
        public b2Vec2 e6;
        public b2Vec2 e7;

        public unsafe ref b2Vec2 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                fixed (b2Vec2* pThis = &e0)
                {
                    return ref pThis[index];
                }
            }
        }
    }

    public partial struct _normals_e__FixedBuffer
    {
        public b2Vec2 e0;
        public b2Vec2 e1;
        public b2Vec2 e2;
        public b2Vec2 e3;
        public b2Vec2 e4;
        public b2Vec2 e5;
        public b2Vec2 e6;
        public b2Vec2 e7;

        public unsafe ref b2Vec2 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                fixed (b2Vec2* pThis = &e0)
                {
                    return ref pThis[index];
                }
            }
        }
    }
}
