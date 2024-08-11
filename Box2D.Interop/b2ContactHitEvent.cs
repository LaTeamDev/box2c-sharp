namespace Box2D.Interop;

public partial struct b2ContactHitEvent
{
    public b2ShapeId shapeIdA;

    public b2ShapeId shapeIdB;

    public b2Vec2 point;

    public b2Vec2 normal;

    public float approachSpeed;
}
