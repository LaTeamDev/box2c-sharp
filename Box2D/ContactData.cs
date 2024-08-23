using Box2D.Interop;

namespace Box2D; 

//TODO:
public class ContactData : B2Object<b2ContactData> {
    public ContactData(b2ContactData id) : base(id) { }
    public b2Manifold Manifold {
        get => _id.manifold;
        set => _id.manifold = value;
    }

    public Shape ShapeA {
        get => _id.shapeIdA;
        set => _id.shapeIdA = value;
    }

    public Shape ShapeB {
        get => _id.shapeIdB;
        set => _id.shapeIdB = value;
    }

    public override bool IsValid => true;
}