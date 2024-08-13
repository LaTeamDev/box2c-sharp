using System.Numerics;
using Box2D.Interop;

namespace Box2D; 

public class RevoluteJointDef : Def<b2RevoluteJointDef> {
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

    public float LowerAngle {
        get => _def.lowerAngle;
        set => _def.lowerAngle = value;
    }

    public float UpperAngle {
        get => _def.upperAngle;
        set => _def.upperAngle = value;
    }

    public bool EnableMotor {
        get => _def.enableMotor;
        set => _def.enableMotor = value;
    }

    public float MaxMotorTorque {
        get => _def.maxMotorTorque;
        set => _def.maxMotorTorque = value;
    }

    public float MotorSpeed {
        get => _def.MotorSpeed;
        set => _def.MotorSpeed = value;
    }

    public float DrawSize {
        get => _def.drawSize;
        set => _def.drawSize = value;
    }

    public bool CollideConnected {
        get => _def.collideConnected;
        set => _def.collideConnected = value;
    }
}