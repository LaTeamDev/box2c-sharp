using System.Numerics;
using System.Runtime.CompilerServices;

namespace Box2D; 

public interface IBody {
    public BodyType Type { get; set; }

    public Vector2 Position { get; set; }

    public Rotation Rotation { get; set; }

    public Vector2 LinearVelocity { get; set; }

    public float AngularVelocity { get; set; }

    public float LinearDamping { get; set; }

    public float AngularDamping { get; set; }

    public float GravityScale { get; set; }

    public float SleepThreshold { get; set; }

    public object? UserData { get; set; }

    public bool EnableSleep { get; set; }

    public bool IsAwake { get; set; }

    public bool FixedRotation { get; set; }

    public bool IsBullet { get; set; }

    public bool IsEnabled { get; set; }

    public bool AutomaticMass { get; set; }
}