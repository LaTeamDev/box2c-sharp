using System.Numerics;
using Box2D.Interop;

namespace Box2D; 

public class WeldJointDef : Def<b2WeldJointDef> {
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

    public float LinearHertz {
        get => _def.linearHertz;
        set => _def.linearHertz = value;
    }

    public float AngularHertz {
        get => _def.angularHertz;
        set => _def.angularHertz = value;
    }

    public float LinearDampingRatio {
        get => _def.linearDampingRatio;
        set => _def.linearDampingRatio = value;
    }

    public float AngularDampingRatio {
        get => _def.angularDampingRatio;
        set => _def.angularDampingRatio = value;
    }

    public bool CollideConnected {
        get => _def.collideConnected;
        set => _def.collideConnected = value;
    }
}