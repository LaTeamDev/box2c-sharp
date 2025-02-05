using Box2D.Interop;

namespace Box2D;

public class CapsuleShape : Shape {
    public CapsuleShape(b2ShapeId id) : base(id) {
        if (B2.Shape_GetType(id) != b2ShapeType.b2_capsuleShape)
            throw new InvalidOperationException();
    }

    internal CapsuleShape(Body body, ShapeDef def, Capsule capsule) :
        this(B2.CreateCapsuleShape(body, ref def._def, ref capsule)) { }
    
    public Capsule Capsule {
        get => B2.Shape_GetCapsule(_id);
        set => B2.Shape_SetCapsule(_id, ref value);
    }
}