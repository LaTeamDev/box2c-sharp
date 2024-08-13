using System.Numerics;
using Box2D.Interop;

namespace Box2D; 

public sealed class MouseJointDef : Def<b2MouseJointDef> {
    public Body BodyA {
        get => new(_def.bodyIdA);
        set => _def.bodyIdA = value._id;
    }

    public Body BodyB {
        get => new(_def.bodyIdB);
        set => _def.bodyIdB = value._id;
    }

    public Vector2 Target {
        get => _def.target;
        set => _def.target = value;
    }

    public float Hertz {
        get => _def.hertz;
        set => _def.hertz = value;
    }

    public float DampingRatio {
        get => _def.dampingRatio;
        set => _def.dampingRatio = value;
    }

    public float MaxForce {
        get => _def.maxForce;
        set => _def.maxForce = value;
    }

    public bool CollideConnected {
        get => _def.collideConnected;
        set => _def.collideConnected = value;
    }
}