using System.Numerics;
using Box2D.Interop;

namespace Box2D; 

public class MotorJoint : Joint {
    public MotorJoint(b2JointId id) : base(id) { }

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