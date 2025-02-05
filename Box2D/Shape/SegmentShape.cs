using Box2D.Interop;

namespace Box2D;

public class SegmentShape : Shape {
    public SegmentShape(b2ShapeId id) : base(id) {
        if (B2.Shape_GetType(id) != b2ShapeType.b2_segmentShape)
            throw new InvalidOperationException();
    }
    internal SegmentShape(Body body, ShapeDef def, Segment segment) :
        this(B2.CreateSegmentShape(body, ref def._def, ref segment)) { }
    
    public Segment Segment {
        get => B2.Shape_GetSegment(_id);
        set => B2.Shape_SetSegment(_id, ref value);
    }
}