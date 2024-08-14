using System.Numerics;
using System.Runtime.CompilerServices;
using Box2D.Interop;

namespace Box2D; 

public sealed class BodyDef : Def<b2BodyDef>, IBody {
    public BodyType Type {
        get => (BodyType)_def.type;
        set => _def.type = (b2BodyType)value;
    }

    public Vector2 Position {
        get => _def.position;
        set => _def.position = value;
    }

    public Rotation Rotation {
        get => _def.rotation;
        set => _def.rotation = value;
    }

    public Vector2 LinearVelocity {
        get => _def.linearVelocity;
        set => _def.linearVelocity = value;
    }

    public float AngularVelocity {
        get => _def.angularVelocity;
        set => _def.angularVelocity = value;
    }

    public float LinearDamping {
        get => _def.linearDamping;
        set => _def.linearDamping = value;
    }

    public float AngularDamping {
        get => _def.angularDamping;
        set => _def.angularDamping = value;
    }

    public float GravityScale {
        get => _def.gravityScale;
        set => _def.gravityScale = value;
    }

    public float SleepThreshold {
        get => _def.sleepThreshold;
        set => _def.sleepThreshold = value;
    }

    public unsafe object? UserData {
        get => *(object?*)_def.userData;
        set => _def.userData = Unsafe.AsPointer(ref value);
    }

    public bool EnableSleep {
        get => _def.enableSleep;
        set => _def.enableSleep = value;
    }

    public bool IsAwake {
        get => _def.isAwake;
        set => _def.isAwake = value;
    }

    public bool FixedRotation {
        get => _def.fixedRotation;
        set => _def.fixedRotation = value;
    }

    public bool IsBullet {
        get => _def.isBullet;
        set => _def.isBullet = value;
    }

    public bool IsEnabled {
        get => _def.isEnabled;
        set => _def.isEnabled = value;
    }

    public bool AutomaticMass {
        get => _def.automaticMass;
        set => _def.automaticMass = value;
    }
}