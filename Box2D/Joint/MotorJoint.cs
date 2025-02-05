using System.Numerics;
using Box2D.Interop;

namespace Box2D; 

public class MotorJoint : Joint {
    public MotorJoint(b2JointId id) : base(id) {
        if (B2.Joint_GetType(id) != b2JointType.b2_motorJoint)
            throw new InvalidOperationException();
    }

    public MotorJoint(World world, MotorJointDef def) :
        this(B2.CreateMotorJoint(world, ref def._def)) {
        _world = world;
        _world.JointCache.Add(this);
    }
    
    public static unsafe implicit operator MotorJoint(b2JointId o) {
        var udata = B2.Joint_GetUserData(o);
        if (udata is null) return new(o);
        var joint = new Pin<Joint>(udata).Target;
        if (joint.Type == JointType.Motor)
            return (MotorJoint)joint;
        throw new InvalidCastException($"Attempt to cast {joint.GetType()} to {typeof(MotorJoint)}");
    }

    public Vector2 LinearOffset {
        get => B2.MotorJoint_GetLinearOffset(_id);
        set => B2.MotorJoint_SetLinearOffset(_id, value);
    }

    public float AngularOffset {
        get => B2.MotorJoint_GetAngularOffset(_id);
        set => B2.MotorJoint_SetAngularOffset(_id, value);
    }

    public float MaxForce {
        get => B2.MotorJoint_GetMaxForce(_id);
        set => B2.MotorJoint_SetMaxForce(_id, value);
    }

    public float MaxTorque {
        get => B2.MotorJoint_GetMaxTorque(_id);
        set => B2.MotorJoint_SetMaxTorque(_id, value);
    }

    public float CorrectionFactor {
        get => B2.MotorJoint_GetCorrectionFactor(_id);
        set => B2.MotorJoint_SetCorrectionFactor(_id, value);
    }
}