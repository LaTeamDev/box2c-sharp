namespace Box2D.Interop;

public partial struct Segment
{
    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 point1;

    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 point2;
}
