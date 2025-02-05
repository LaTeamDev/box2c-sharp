using Box2D.Interop;

namespace Box2D;

public class PolygonShape : Shape {
    public PolygonShape(b2ShapeId id) : base(id) {
        if (B2.Shape_GetType(id) != b2ShapeType.b2_polygonShape)
            throw new InvalidOperationException();
    }
    
    internal PolygonShape(Body body, ShapeDef def, Polygon polygon) :
        this(B2.CreatePolygonShape(body, ref def._def, ref polygon)) { }
    
    public Polygon Polygon {
        get => B2.Shape_GetPolygon(_id);
        set => B2.Shape_SetPolygon(_id, ref value);
    }
}