using System.Numerics;
using Box2D.Interop;

namespace Box2D; 

public class BodyDef {
    internal b2BodyDef _b2BodyDef;
    
    public BodyType Type {
        get => (BodyType)_b2BodyDef.type;
        set => _b2BodyDef.type = (b2BodyType)value;
    }

    public Vector2 Position {
        get => _b2BodyDef.position;
        set => _b2BodyDef.position = value;
    }

    public Rotation Rotation {
        get => _b2BodyDef.rotation;
        set => _b2BodyDef.rotation = value;
    }

    public Vector2 LinearVelocity {
        get => _b2BodyDef.position;
        set => _b2BodyDef.position = value;
    }

    public float AngularVelocity {
        get => _b2BodyDef.angularVelocity;
        set => _b2BodyDef.angularVelocity = value;
    }

    public float LinearDamping {
        get => _b2BodyDef.linearDamping;
        set => _b2BodyDef.linearDamping = value;
    }

    public float AngularDamping {
        get => _b2BodyDef.angularDamping;
        set => _b2BodyDef.angularDamping = value;
    }

    public float GravityScale {
        get => _b2BodyDef.gravityScale;
        set => _b2BodyDef.gravityScale = value;
    }

    public float SleepThreshold {
        get => _b2BodyDef.sleepThreshold;
        set => _b2BodyDef.sleepThreshold = value;
    }

    public unsafe void* UserData {
        get => _b2BodyDef.userData;
        set => _b2BodyDef.userData = value;
    }

    public bool EnableSleep {
        get => _b2BodyDef.enableSleep;
        set => _b2BodyDef.enableSleep = value;
    }

    public bool IsAwake {
        get => _b2BodyDef.isAwake;
        set => _b2BodyDef.isAwake = value;
    }

    public bool FixedRotation {
        get => _b2BodyDef.fixedRotation;
        set => _b2BodyDef.fixedRotation = value;
    }

    public bool IsBullet {
        get => _b2BodyDef.isBullet;
        set => _b2BodyDef.isBullet = value;
    }

    public bool IsEnabled {
        get => _b2BodyDef.isEnabled;
        set => _b2BodyDef.isEnabled = value;
    }

    public bool AutomaticMass {
        get => _b2BodyDef.automaticMass;
        set => _b2BodyDef.automaticMass = value;
    }
}