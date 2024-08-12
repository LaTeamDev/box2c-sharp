using System.Numerics;
using Box2D.Interop;

namespace Box2D; 

public class WorldDef {
    internal b2WorldDef _b2WorldDef = B2.DefaultWorldDef();
    public int WorkerCount {
        get => _b2WorldDef.workerCount;
        set => _b2WorldDef.workerCount = value;
    }

    public Vector2 Gravity {
        get => _b2WorldDef.gravity;
        set => _b2WorldDef.gravity = value;
    }

    public float ContactHertz {
        get => _b2WorldDef.contactHertz;
        set => _b2WorldDef.contactHertz = value;
    }

    public float JointHertz {
        get => _b2WorldDef.jointHertz;
        set => _b2WorldDef.jointHertz = value;
    }

    public float ContactDampingRatio {
        get => _b2WorldDef.contactDampingRatio;
        set => _b2WorldDef.contactDampingRatio = value;
    }

    public float RestitutionThreshold {
        get => _b2WorldDef.restitutionThreshold;
        set => _b2WorldDef.restitutionThreshold = value;
    }

    public float ContactPushoutVelocity {
        get => _b2WorldDef.contactPushoutVelocity;
        set => _b2WorldDef.contactPushoutVelocity = value;
    }

    public float HitEventThreshold {
        get => _b2WorldDef.hitEventThreshold;
        set => _b2WorldDef.hitEventThreshold = value;
    }

    public float JointDampingRatio {
        get => _b2WorldDef.jointDampingRatio;
        set => _b2WorldDef.jointDampingRatio = value;
    }

    public bool EnableContinous {
        get => _b2WorldDef.enableContinous;
        set => _b2WorldDef.enableContinous = value;
    }

    public bool EnableSleep {
        get => _b2WorldDef.enableSleep;
        set => _b2WorldDef.enableSleep = value;
    }
}