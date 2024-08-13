using System.Numerics;
using Box2D.Interop;

namespace Box2D; 

public class PrismaticJointDef : Def<b2PrismaticJointDef> {
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

    public Vector2 LocalAxisA {
        get => _def.localAxisA;
        set => _def.localAxisA = value;
    }

    public float ReferenceAngle {
        get => _def.referenceAngle;
        set => _def.referenceAngle = value;
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

    public float LowerTranslation {
        get => _def.lowerTranslation;
        set => _def.lowerTranslation = value;
    }

    public float UpperTranslation {
        get => _def.upperTranslation;
        set => _def.upperTranslation = value;
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