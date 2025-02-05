using Box2D.Interop;

namespace Box2D;

public class CircleShape : Shape {
    public CircleShape(b2ShapeId id) : base(id) {
        if (B2.Shape_GetType(id) != b2ShapeType.b2_circleShape)
            throw new InvalidOperationException();
    }

    internal CircleShape(Body body, ShapeDef def, Circle circle) :
        this(B2.CreateCircleShape(body, ref def._def, ref circle)) { }
    
    public Circle Circle {
        get => B2.Shape_GetCircle(_id);
        set => B2.Shape_SetCircle(_id, ref value);
    }
}