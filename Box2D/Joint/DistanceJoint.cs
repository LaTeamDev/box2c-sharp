using Box2D.Interop;

namespace Box2D; 

public class DistanceJoint : Joint {
    public DistanceJoint(b2JointId id) : base(id) {
        if (B2.Joint_GetType(id) != b2JointType.b2_distanceJoint)
            throw new InvalidOperationException();
    }

    public DistanceJoint(World world, DistanceJointDef def) :
        this(B2.CreateDistanceJoint(world, ref def._def)) {
        _world = world;
        _world.JointCache.Add(this);
    }
    
    public static unsafe implicit operator DistanceJoint(b2JointId o) {
        var udata = B2.Joint_GetUserData(o);
        if (udata is null) return new(o);
        var joint = new Pin<Joint>(udata).Target;
        if (joint.Type == JointType.Distance)
            return (DistanceJoint)joint;
        throw new InvalidCastException($"Attempt to cast {joint.GetType()} to {typeof(DistanceJoint)}");
    }

    public float Length {
        get => B2.DistanceJoint_GetLength(_id);
        set => B2.DistanceJoint_SetLength(_id, value);
    }

    public bool SpringEnabled {
        get => B2.DistanceJoint_IsSpringEnabled(_id);
        set => B2.DistanceJoint_EnableSpring(_id, value);
    }

    public float SpringHertz {
        set => B2.DistanceJoint_SetSpringHertz(_id, value);
    }

    public float SpringDampingRatio {
        set => B2.DistanceJoint_SetSpringDampingRatio(_id, value);
    }

    public float Hertz => B2.DistanceJoint_GetHertz(_id);

    public float DampingRatio => B2.DistanceJoint_GetDampingRatio(_id);

    public bool LimitEnabled {
        get => B2.DistanceJoint_IsLimitEnabled(_id);
        set => B2.DistanceJoint_EnableLimit(_id, value);
    }

    public void SetLengthRange(float min, float max) => 
        B2.DistanceJoint_SetLengthRange(_id, min, max);

    public float MinLength {
        get => B2.DistanceJoint_GetMinLength(_id);
        set => SetLengthRange(value, MaxLength);
    }

    public float MaxLength {
        get => B2.DistanceJoint_GetMaxLength(_id);
        set => SetLengthRange(MinLength, value);
    }

    public float CurrentLength => B2.DistanceJoint_GetCurrentLength(_id);

    public bool MotorEnabled {
        get => B2.DistanceJoint_IsMotorEnabled(_id);
        set => B2.DistanceJoint_EnableMotor(_id, value);
    }

    public float MotorSpeed {
        get => B2.DistanceJoint_GetMotorSpeed(_id);
        set => B2.DistanceJoint_SetMotorSpeed(_id, value);
    }

    public float MaxMotorForce {
        get => B2.DistanceJoint_GetMaxMotorForce(_id);
        set => B2.DistanceJoint_SetMaxMotorForce(_id, value);
    }

    public float MotorForce => B2.DistanceJoint_GetMotorForce(_id);
}