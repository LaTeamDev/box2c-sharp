using Box2D.Interop;

namespace Box2D; 

public class RevoluteJoint : Joint {
    public RevoluteJoint(b2JointId id) : base(id) { }

    public bool SpringEnabled {
        set => B2.RevoluteJoint_EnableSpring(_id, value);
    }

    public float SpringHertz { 
        get => B2.RevoluteJoint_GetSpringHertz(_id);
        set => B2.RevoluteJoint_SetSpringHertz(_id, value);
    }

    public float SpringDampingRatio {
        get => B2.RevoluteJoint_GetSpringDampingRatio(_id);
        set => B2.RevoluteJoint_SetSpringDampingRatio(_id, value);
    }

    public float Angle {
        get => B2.RevoluteJoint_GetAngle(_id);
    }

    public bool LimitEnabled {
        get => B2.RevoluteJoint_IsLimitEnabled(_id);
        set => B2.RevoluteJoint_EnableLimit(_id, value);
    }
    
    public float LowerLimit {
        get => B2.RevoluteJoint_GetLowerLimit(_id);
        set => SetLimits(value, UpperLimit);
    }

    public float UpperLimit {
        get => B2.RevoluteJoint_GetUpperLimit(_id);
        set => SetLimits(LowerLimit, value);
    }

    public void SetLimits(float lower, float upper) =>
        B2.RevoluteJoint_SetLimits(_id, lower, upper);

    public bool MotorEnabled {
        get => B2.RevoluteJoint_IsMotorEnabled(_id);
        set => B2.RevoluteJoint_EnableMotor(_id, value);
    }

    public float MotorSpeed {
        get => B2.RevoluteJoint_GetMotorSpeed(_id);
        set => B2.RevoluteJoint_SetMotorSpeed(_id, value);
    }

    public float MotorTorque {
        get => B2.RevoluteJoint_GetMotorTorque(_id);
    }

    public float MaxMotorTorque {
        get => B2.RevoluteJoint_GetMaxMotorTorque(_id);
        set => B2.RevoluteJoint_SetMaxMotorTorque(_id, value);
    }
}