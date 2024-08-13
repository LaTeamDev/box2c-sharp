using System.Numerics;
using Box2D.Interop;

namespace Box2D; 

public sealed class DistanceJointDef : Def<b2DistanceJointDef> {
    public Body BodyA {
        get => new(_def.bodyIdA);
        set => _def.bodyIdA = value._id;
    }

    public Body BodyB {
        get => new(_def.bodyIdB);
        set => _def.bodyIdB = value._id;
    }

    public Vector2 LocalAnchorA {
        get => _def.localAnchorA;
        set => _def.localAnchorA = value;
    }

    public Vector2 LocalAnchorB {
        get => _def.localAnchorB;
        set => _def.localAnchorB = value;
    }

    public float Length {
        get => _def.length;
        set => _def.length = value;
    }

    public bool EnableSpring {
        get => _def.enableSpring;
        set => _def.enableSpring = value;
    }

    public float Hertz {
        get => _def.hertz;
        set => _def.hertz = value;
    }

    public float DampingRatio {
        get => _def.dampingRatio;
        set => _def.dampingRatio = value;
    }

    public bool EnableLimit {
        get => _def.enableLimit;
        set => _def.enableLimit = value;
    }

    public float MinLength {
        get => _def.minLength;
        set => _def.minLength = value;
    }

    public float MaxLength {
        get => _def.maxLength;
        set => _def.maxLength = value;
    }

    public bool EnableMotor {
        get => _def.enableMotor;
        set => _def.enableMotor = value;
    }

    public float MaxMotorForce {
        get => _def.maxMotorForce;
        set => _def.maxMotorForce = value;
    }

    public float MotorSpeed {
        get => _def.motorSpeed;
        set => _def.motorSpeed = value;
    }

    public bool CollideConnected {
        get => _def.collideConnected;
        set => _def.collideConnected = value;
    }
}