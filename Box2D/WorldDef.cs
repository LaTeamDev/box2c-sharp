using System.Numerics;
using Box2D.Interop;

namespace Box2D; 

public sealed class WorldDef : Def<b2WorldDef> {
    public int WorkerCount {
        get => _def.workerCount;
        set => _def.workerCount = value;
    }

    public Vector2 Gravity {
        get => _def.gravity;
        set => _def.gravity = value;
    }

    public float ContactHertz {
        get => _def.contactHertz;
        set => _def.contactHertz = value;
    }

    public float JointHertz {
        get => _def.jointHertz;
        set => _def.jointHertz = value;
    }

    public float ContactDampingRatio {
        get => _def.contactDampingRatio;
        set => _def.contactDampingRatio = value;
    }

    public float RestitutionThreshold {
        get => _def.restitutionThreshold;
        set => _def.restitutionThreshold = value;
    }

    public float ContactPushoutVelocity {
        get => _def.contactPushoutVelocity;
        set => _def.contactPushoutVelocity = value;
    }

    public float HitEventThreshold {
        get => _def.hitEventThreshold;
        set => _def.hitEventThreshold = value;
    }

    public float JointDampingRatio {
        get => _def.jointDampingRatio;
        set => _def.jointDampingRatio = value;
    }

    public bool EnableContinous {
        get => _def.enableContinous;
        set => _def.enableContinous = value;
    }

    public bool EnableSleep {
        get => _def.enableSleep;
        set => _def.enableSleep = value;
    }
}