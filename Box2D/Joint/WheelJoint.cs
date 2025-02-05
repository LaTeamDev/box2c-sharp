using Box2D.Interop;

namespace Box2D; 

public class WheelJoint : Joint {
    public WheelJoint(b2JointId id) : base(id) {
        if (B2.Joint_GetType(id) != b2JointType.b2_wheelJoint)
            throw new InvalidOperationException();
    }

    public WheelJoint(World world, WheelJointDef def) :
        this(B2.CreateWheelJoint(world, ref def._def)) {
        _world = world;
        _world.JointCache.Add(this);
    }
    
    public static unsafe implicit operator WheelJoint(b2JointId o) {
        var udata = B2.Joint_GetUserData(o);
        if (udata is null) return new(o);
        var joint = new Pin<Joint>(udata).Target;
        if (joint.Type == JointType.Distance)
            return (WheelJoint)joint;
        throw new InvalidCastException($"Attempt to cast {joint.GetType()} to {typeof(WheelJoint)}");
    }

    public bool SpringEnabled {
        get => B2.WheelJoint_IsSpringEnabled(_id);
        set => B2.WheelJoint_EnableSpring(_id, value);
    }

    public float SpringHertz {
        get => B2.WheelJoint_GetSpringHertz(_id);
        set => B2.WheelJoint_SetSpringHertz(_id, value);
    }

    public float SpringDampingRatio {
        get => B2.WheelJoint_GetSpringDampingRatio(_id);
        set => B2.WheelJoint_SetSpringDampingRatio(_id, value);
    }

    public bool LimitEnabled {
        get => B2.WheelJoint_IsLimitEnabled(_id);
        set => B2.WheelJoint_EnableLimit(_id, value);
    }
    
    public float LowerLimit {
        get => B2.WheelJoint_GetLowerLimit(_id);
        set => SetLimits(value, UpperLimit);
    }

    public float UpperLimit {
        get => B2.WheelJoint_GetUpperLimit(_id);
        set => SetLimits(LowerLimit, value);
    }

    public void SetLimits(float lower, float upper) =>
        B2.WheelJoint_SetLimits(_id, lower, upper);
    
    public bool MotorEnabled {
        get => B2.WheelJoint_IsMotorEnabled(_id);
        set => B2.WheelJoint_EnableMotor(_id, value);
    }

    public float MotorSpeed {
        get => B2.WheelJoint_GetMotorSpeed(_id);
        set => B2.WheelJoint_SetMotorSpeed(_id, value);
    }

    public float MotorTorque {
        get => B2.WheelJoint_GetMotorTorque(_id);
    }

    public float MaxMotorTorque {
        get => B2.WheelJoint_GetMaxMotorTorque(_id);
        set => B2.WheelJoint_SetMaxMotorTorque(_id, value);
    }
}