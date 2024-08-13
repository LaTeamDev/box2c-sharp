using System.Numerics;
using Box2D.Interop;

namespace Box2D; 

public sealed class MotorJointDef : Def<b2MotorJointDef> {
    public Body BodyA {
        get => new(_def.bodyIdA);
        set => _def.bodyIdA = value._id;
    }

    public Body BodyB {
        get => new(_def.bodyIdB);
        set => _def.bodyIdB = value._id;
    }

    public Vector2 LinearOffset {
        get => _def.linearOffset;
        set => _def.linearOffset = value;
    }

    public float AngularOffset {
        get => _def.angularOffset;
        set => _def.angularOffset = value;
    }

    public float MaxForce {
        get => _def.maxForce;
        set => _def.maxForce = value;
    }

    public float MaxTorque {
        get => _def.maxTorque;
        set => _def.maxTorque = value;
    }

    public float CorrectionFactor {
        get => _def.correctionFactor;
        set => _def.correctionFactor = value;
    }

    public bool CollideConnected {
        get => _def.collideConnected;
        set => _def.collideConnected = value;
    }
}