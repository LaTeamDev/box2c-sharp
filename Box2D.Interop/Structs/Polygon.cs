using System.Numerics;
using System.Runtime.CompilerServices;
using Box2D.Interop;

namespace Box2D;

public partial struct Polygon
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

    public static unsafe Polygon Make(ref Hull hull, float radius)
        => B2.MakePolygon((Hull*)Unsafe.AsPointer(ref hull), radius);
    public static unsafe Polygon Make(ref Hull hull, float radius, Transform transform)
        => B2.MakeOffsetPolygon((Hull*)Unsafe.AsPointer(ref hull), radius, transform);

    public static Polygon MakeSquare(float size) => B2.MakeSquare(size);
    public static Polygon MakeBox(float hx, float hy) => B2.MakeBox(hx, hy);
    public static Polygon MakeBox(float hx, float hy, float radius) => B2.MakeRoundedBox(hx, hy, radius);
    public static Polygon MakeBox(float hx, float hy, Vector2 center, float angle) => B2.MakeOffsetBox(hx, hy, center, angle);

    public static unsafe Polygon Transform(ref Polygon polygon, Transform transform) =>
        B2.TransformPolygon(transform, (Polygon*)Unsafe.AsPointer(ref polygon));
    
    public static unsafe b2MassData ComputeMass(ref Polygon shape, float density) =>
        B2.ComputePolygonMass((Polygon*)Unsafe.AsPointer(ref shape), density);
    
    public static unsafe AABB ComputePolygonAABB(ref Polygon shape, Transform transform) =>
        B2.ComputePolygonAABB((Polygon*)Unsafe.AsPointer(ref shape), transform);

    public static unsafe bool IsPointIn(ref Polygon shape, Vector2 point) =>
        B2.PointInPolygon(point, (Polygon*) Unsafe.AsPointer(ref shape));

    public static unsafe b2CastOutput RayCast(ref Polygon shape, ref b2RayCastInput input) =>
        B2.RayCastPolygon((b2RayCastInput*) Unsafe.AsPointer(ref input), (Polygon*) Unsafe.AsPointer(ref shape));
    
    public static unsafe b2CastOutput ShapeCast(ref Polygon shape, ref b2ShapeCastInput input) =>
        B2.ShapeCastPolygon((b2ShapeCastInput*) Unsafe.AsPointer(ref input), (Polygon*) Unsafe.AsPointer(ref shape));
}
