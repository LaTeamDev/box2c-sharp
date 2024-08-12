using Box2D.Interop;

namespace Box2D; 

public class ShapeDef {
    internal b2ShapeDef _shapeDef = B2.DefaultShapeDef();
    
    public float Friction {
        get => _shapeDef.friction;
        set => _shapeDef.friction = value;
    }

    public float Restitution {
        get => _shapeDef.restitution;
        set => _shapeDef.restitution = value;
    }

    public float Density {
        get => _shapeDef.density;
        set => _shapeDef.density = value;
    }

    public b2Filter Filter {
        get => _shapeDef.filter;
        set => _shapeDef.filter = value;
    }

    public uint CustomColor {
        get => _shapeDef.customColor;
        set => _shapeDef.customColor = value;
    }

    public bool IsSensor {
        get => _shapeDef.isSensor;
        set => _shapeDef.isSensor = value;
    }

    public bool EnableSensorEvents {
        get => _shapeDef.enableSensorEvents;
        set => _shapeDef.enableSensorEvents = value;
    }

    public bool EnableContactEvents {
        get => _shapeDef.enableContactEvents;
        set => _shapeDef.enableContactEvents = value;
    }

    public bool EnableHitEvents {
        get => _shapeDef.enableHitEvents;
        set => _shapeDef.enableHitEvents = value;
    }

    public bool EnablePreSolveEvents {
        get => _shapeDef.enablePreSolveEvents;
        set => _shapeDef.enablePreSolveEvents = value;
    }

    public bool ForceContactCreation {
        get => _shapeDef.forceContactCreation;
        set => _shapeDef.forceContactCreation = value;
    }
}