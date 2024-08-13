using Box2D.Interop;

namespace Box2D; 

public class WeldJoint : Joint {
    public WeldJoint(b2JointId id) : base(id) { }
    
    public float LinearHertz {
        get => B2.WeldJoint_GetLinearHertz(_id);
        set => B2.WeldJoint_SetLinearHertz(_id, value);
    }

    public float LinearDampingRatio {
        get => B2.WeldJoint_GetLinearDampingRatio(_id);
        set => B2.WeldJoint_SetLinearDampingRatio(_id, value);
    }

    public float AngularHertz {
        get => B2.WeldJoint_GetAngularHertz(_id);
        set => B2.WeldJoint_SetAngularHertz(_id, value);
    }

    public float AngularDampingRatio {
        get => B2.WeldJoint_GetAngularDampingRatio(_id);
        set => B2.WeldJoint_SetAngularDampingRatio(_id, value);
    }
}