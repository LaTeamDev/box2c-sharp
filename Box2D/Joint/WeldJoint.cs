using Box2D.Interop;

namespace Box2D; 

public class WeldJoint : Joint {
    public WeldJoint(b2JointId id) : base(id) {
        if (B2.Joint_GetType(id) != b2JointType.b2_weldJoint)
            throw new InvalidOperationException();
    }

    public WeldJoint(World world, WeldJointDef def) :
        this(B2.CreateWeldJoint(world, ref def._def)) {
        _world = world;
        _world.JointCache.Add(this);
    }
    
    public static unsafe implicit operator WeldJoint(b2JointId o) {
        var udata = B2.Joint_GetUserData(o);
        if (udata is null) return new(o);
        var joint = new Pin<Joint>(udata).Target;
        if (joint.Type == JointType.Weld)
            return (WeldJoint)joint;
        throw new InvalidCastException($"Attempt to cast {joint.GetType()} to {typeof(WeldJoint)}");
    }
    
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