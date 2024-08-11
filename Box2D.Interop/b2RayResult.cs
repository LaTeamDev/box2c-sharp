namespace Box2D.Interop;

public partial struct b2RayResult
{
    public b2ShapeId shapeId;

    public b2Vec2 point;

    public b2Vec2 normal;

    public float fraction;

    [NativeTypeName("_Bool")]
    public bool hit;
}
