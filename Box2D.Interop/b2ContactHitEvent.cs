namespace Box2D.Interop;

public partial struct b2ContactHitEvent
{
    public b2ShapeId shapeIdA;

    public b2ShapeId shapeIdB;

    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 point;

    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 normal;

    public float approachSpeed;
}
