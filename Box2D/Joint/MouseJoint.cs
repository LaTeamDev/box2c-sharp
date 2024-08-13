using System.Numerics;
using Box2D.Interop;

namespace Box2D; 

public class MouseJoint : Joint {
    public MouseJoint(b2JointId id) : base(id) { }

    public Vector2 Target {
        get => B2.MouseJoint_GetTarget(_id);
        set => B2.MouseJoint_SetTarget(_id, value);
    }

    public float SpringHertz {
        get => B2.MouseJoint_GetSpringHertz(_id);
        set => B2.MouseJoint_SetSpringHertz(_id, value);
    }

    public float SpringDampingRatio {
        get => B2.MouseJoint_GetSpringDampingRatio(_id);
        set => B2.MouseJoint_SetSpringDampingRatio(_id, value);
    }

    public float MaxForce {
        get => B2.MouseJoint_GetMaxForce(_id);
        set => B2.MouseJoint_SetMaxForce(_id, value);
    }
}