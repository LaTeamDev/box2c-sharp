using System.Numerics;

namespace Box2D.Interop;

public partial struct Segment
{
    [NativeTypeName("b2Vec2")]
    public Vector2 Start;

    [NativeTypeName("b2Vec2")]
    public Vector2 End;

    public Segment(Vector2 start, Vector2 end) {
        Start = start;
        End = end;
    }
}
