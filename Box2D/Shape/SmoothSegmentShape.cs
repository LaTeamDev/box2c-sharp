using Box2D.Interop;

namespace Box2D;

public class SmoothSegmentShape : Shape {
    public SmoothSegmentShape(b2ShapeId id) : base(id) {
        if (B2.Shape_GetType(id) != b2ShapeType.b2_smoothSegmentShape)
            throw new InvalidOperationException();
    }
    
    public b2SmoothSegment SmoothSegment {
        get => B2.Shape_GetSmoothSegment(_id);
    }
}