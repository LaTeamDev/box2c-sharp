using Box2D.Interop;

namespace Box2D; 

public class PrismaticJoint : Joint {
    public PrismaticJoint(b2JointId id) : base(id) { }

    public bool SpringEnabled {
        get => B2.PrismaticJoint_IsSpringEnabled(_id);
        set => B2.PrismaticJoint_EnableSpring(_id, value);
    }

    public float SpringHertz {
        get => B2.PrismaticJoint_GetSpringHertz(_id);
        set => B2.PrismaticJoint_SetSpringHertz(_id, value);
    }

    public float SpringDampingRatio {
        get => B2.PrismaticJoint_GetSpringDampingRatio(_id);
        set => B2.PrismaticJoint_SetSpringDampingRatio(_id, value);
    }

    public bool LimitEnabled {
        get => B2.PrismaticJoint_IsLimitEnabled(_id);
        set => B2.PrismaticJoint_EnableLimit(_id, value);
    }

    public float LowerLimit {
        get => B2.PrismaticJoint_GetLowerLimit(_id);
        set => SetLimits(value, UpperLimit);
    }

    public float UpperLimit {
        get => B2.PrismaticJoint_GetUpperLimit(_id);
        set => SetLimits(LowerLimit, value);
    }

    public void SetLimits(float lower, float upper) =>
        B2.PrismaticJoint_SetLimits(_id, lower, upper);

    public bool MotorEnabled {
        get => B2.PrismaticJoint_IsMotorEnabled(_id);
        set => B2.PrismaticJoint_EnableMotor(_id, value);
    }

    public float MotorSpeed {
        get => B2.PrismaticJoint_GetMotorSpeed(_id);
        set => B2.PrismaticJoint_SetMotorSpeed(_id, value);
    }

    public float MaxMotorForce {
        get => B2.PrismaticJoint_GetMaxMotorForce(_id);
        set => B2.PrismaticJoint_SetMaxMotorForce(_id, value);
    }

    public float MotorForce => B2.PrismaticJoint_GetMotorForce(_id);
}