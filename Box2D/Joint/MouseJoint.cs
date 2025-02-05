using System.Numerics;
using Box2D.Interop;

namespace Box2D; 

public class MouseJoint : Joint {
    public MouseJoint(b2JointId id) : base(id) {
        if (B2.Joint_GetType(id) != b2JointType.b2_mouseJoint)
            throw new InvalidOperationException();
    }

    public MouseJoint(World world, MouseJointDef def) :
        this(B2.CreateMouseJoint(world, ref def._def)) {
        _world = world;
        _world.JointCache.Add(this);
    }
    public static unsafe implicit operator MouseJoint(b2JointId o) {
        var udata = B2.Joint_GetUserData(o);
        if (udata is null) return new(o);
        var joint = new Pin<Joint>(udata).Target;
        if (joint.Type == JointType.Distance)
            return (MouseJoint)joint;
        throw new InvalidCastException($"Attempt to cast {joint.GetType()} to {typeof(MouseJoint)}");
    }

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