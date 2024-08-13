using Box2D.Interop;

namespace Box2D; 

public class DistanceJoint : Joint {
    public DistanceJoint(b2JointId id) : base(id) { }

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