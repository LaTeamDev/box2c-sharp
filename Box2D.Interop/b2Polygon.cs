using System.Runtime.CompilerServices;

namespace Box2D.Interop;

public partial struct b2Polygon
{
    [NativeTypeName("b2Vec2[8]")]
    public _vertices_e__FixedBuffer vertices;

    [NativeTypeName("b2Vec2[8]")]
    public _normals_e__FixedBuffer normals;

    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 centroid;

    public float radius;

    [NativeTypeName("int32_t")]
    public int count;

    public partial struct _vertices_e__FixedBuffer
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

    public partial struct _normals_e__FixedBuffer
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
}
