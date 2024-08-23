using Box2D.Interop;

namespace Box2D; 

public interface IShape {
    public float Friction { get; set; }

    public float Restitution { get; set; }

    public float Density { get; set; }

    public Filter Filter { get; set; }

    public bool IsSensor { get; }

    public bool EnableSensorEvents { get; set; }

    public bool EnableContactEvents { get; set; }

    public bool EnableHitEvents { get; set; }

    public bool EnablePreSolveEvents { get; set; }
}