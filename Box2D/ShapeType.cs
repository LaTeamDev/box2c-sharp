using Box2D.Interop;

namespace Box2D; 

public enum ShapeType : uint {
    Circle = b2ShapeType.b2_circleShape,
    Capsule = b2ShapeType.b2_capsuleShape,
    Segment = b2ShapeType.b2_segmentShape,
    Polygon = b2ShapeType.b2_polygonShape,
    SmoothSegment = b2ShapeType.b2_smoothSegmentShape,
}