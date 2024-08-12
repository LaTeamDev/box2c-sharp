namespace Box2D.Interop;

public partial struct b2RayResult
{
    public b2ShapeId shapeId;

    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 point;

    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 normal;

    public float fraction;

    [NativeTypeName("_Bool")]
    public bool hit;
}
