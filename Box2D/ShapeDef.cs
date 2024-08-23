using Box2D.Interop;

namespace Box2D; 

public class ShapeDef : Def<b2ShapeDef>, IShape {
    public float Friction {
        get => _def.friction;
        set => _def.friction = value;
    }

    public float Restitution {
        get => _def.restitution;
        set => _def.restitution = value;
    }

    public float Density {
        get => _def.density;
        set => _def.density = value;
    }

    public Filter Filter {
        get => new(_def.filter);
        set => _def.filter = value;
    }

    public uint CustomColor {
        get => _def.customColor;
        set => _def.customColor = value;
    }

    public bool IsSensor {
        get => _def.isSensor;
        set => _def.isSensor = value;
    }

    public bool EnableSensorEvents {
        get => _def.enableSensorEvents;
        set => _def.enableSensorEvents = value;
    }

    public bool EnableContactEvents {
        get => _def.enableContactEvents;
        set => _def.enableContactEvents = value;
    }

    public bool EnableHitEvents {
        get => _def.enableHitEvents;
        set => _def.enableHitEvents = value;
    }

    public bool EnablePreSolveEvents {
        get => _def.enablePreSolveEvents;
        set => _def.enablePreSolveEvents = value;
    }

    public bool ForceContactCreation {
        get => _def.forceContactCreation;
        set => _def.forceContactCreation = value;
    }
}