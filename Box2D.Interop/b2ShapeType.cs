namespace Box2D.Interop;

[NativeTypeName("unsigned int")]
public enum b2ShapeType : uint
{
    b2_circleShape,
    b2_capsuleShape,
    b2_segmentShape,
    b2_polygonShape,
    b2_smoothSegmentShape,
    b2_shapeTypeCount,
}
