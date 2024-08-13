using System.Numerics;

namespace Box2D.Interop; 

public unsafe interface IJointDef
{
    b2BodyId BodyIdA { get; set; }
    b2BodyId BodyIdB { get; set; }
    bool CollideConnected { get; set; }
    void* UserData { get; set; }
}

public interface IAnchoredJointDef : IJointDef
{
    Vector2 LocalAnchorA { get; set; }
    Vector2 LocalAnchorB { get; set; }
}

public interface ISpringEnabledJointDef : IAnchoredJointDef
{
    bool EnableSpring { get; set; }
}

public interface ISpringPropertiesJointDef : IJointDef
{
    float Hertz { get; set; }
    float DampingRatio { get; set; }
}

public interface ILimitedJointDef : IAnchoredJointDef
{
    bool EnableLimit { get; set; }
}

public interface IMotorizedJointDef : IAnchoredJointDef
{
    bool EnableMotor { get; set; }
    float MotorSpeed { get; set; }
}

public interface IAxisJointDef : IAnchoredJointDef
{
    Vector2 LocalAxisA { get; set; }
}

public unsafe partial struct b2DistanceJointDef : ISpringEnabledJointDef, ISpringPropertiesJointDef, ILimitedJointDef, IMotorizedJointDef
{
    public b2BodyId BodyIdA { get => bodyIdA; set => bodyIdA = value; }
    public b2BodyId BodyIdB { get => bodyIdB; set => bodyIdB = value; }
    public Vector2 LocalAnchorA { get => localAnchorA; set => localAnchorA = value; }
    public Vector2 LocalAnchorB { get => localAnchorB; set => localAnchorB = value; }
    public bool EnableSpring { get => enableSpring; set => enableSpring = value; }
    public float Hertz { get => hertz; set => hertz = value; }
    public float DampingRatio { get => dampingRatio; set => dampingRatio = value; }
    public bool EnableLimit { get => enableLimit; set => enableLimit = value; }
    public bool EnableMotor { get => enableMotor; set => enableMotor = value; }
    public float MotorSpeed { get => motorSpeed; set => motorSpeed = value; }
    public bool CollideConnected { get => collideConnected; set => collideConnected = value; }
    public void* UserData { get => userData; set => userData = value; }
}

public unsafe partial struct b2MotorJointDef : IJointDef
{
    public b2BodyId BodyIdA { get => bodyIdA; set => bodyIdA = value; }
    public b2BodyId BodyIdB { get => bodyIdB; set => bodyIdB = value; }
    public bool CollideConnected { get => collideConnected; set => collideConnected = value; }
    public void* UserData { get => userData; set => userData = value; }
}

public unsafe partial struct b2MouseJointDef : IJointDef, ISpringPropertiesJointDef
{
    public b2BodyId BodyIdA { get => bodyIdA; set => bodyIdA = value; }
    public b2BodyId BodyIdB { get => bodyIdB; set => bodyIdB = value; }
    public float Hertz { get => hertz; set => hertz = value; }
    public float DampingRatio { get => dampingRatio; set => dampingRatio = value; }
    public bool CollideConnected { get => collideConnected; set => collideConnected = value; }
    public void* UserData { get => userData; set => userData = value; }
}

public unsafe partial struct b2PrismaticJointDef : ISpringEnabledJointDef, ISpringPropertiesJointDef, ILimitedJointDef, IMotorizedJointDef, IAxisJointDef
{
    public b2BodyId BodyIdA { get => bodyIdA; set => bodyIdA = value; }
    public b2BodyId BodyIdB { get => bodyIdB; set => bodyIdB = value; }
    public Vector2 LocalAnchorA { get => localAnchorA; set => localAnchorA = value; }
    public Vector2 LocalAnchorB { get => localAnchorB; set => localAnchorB = value; }
    public Vector2 LocalAxisA { get => localAxisA; set => localAxisA = value; }
    public bool EnableSpring { get => enableSpring; set => enableSpring = value; }
    public float Hertz { get => hertz; set => hertz = value; }
    public float DampingRatio { get => dampingRatio; set => dampingRatio = value; }
    public bool EnableLimit { get => enableLimit; set => enableLimit = value; }
    public bool EnableMotor { get => enableMotor; set => enableMotor = value; }
    public float MotorSpeed { get => motorSpeed; set => motorSpeed = value; }
    public bool CollideConnected { get => collideConnected; set => collideConnected = value; }
    public void* UserData { get => userData; set => userData = value; }
}

public unsafe partial struct b2RevoluteJointDef : ISpringEnabledJointDef, ISpringPropertiesJointDef, ILimitedJointDef, IMotorizedJointDef
{
    public b2BodyId BodyIdA { get => bodyIdA; set => bodyIdA = value; }
    public b2BodyId BodyIdB { get => bodyIdB; set => bodyIdB = value; }
    public Vector2 LocalAnchorA { get => localAnchorA; set => localAnchorA = value; }
    public Vector2 LocalAnchorB { get => localAnchorB; set => localAnchorB = value; }
    public bool EnableSpring { get => enableSpring; set => enableSpring = value; }
    public float Hertz { get => hertz; set => hertz = value; }
    public float DampingRatio { get => dampingRatio; set => dampingRatio = value; }
    public bool EnableLimit { get => enableLimit; set => enableLimit = value; }
    public bool EnableMotor { get => enableMotor; set => enableMotor = value; }
    public float MotorSpeed { get => motorSpeed; set => motorSpeed = value; }
    public bool CollideConnected { get => collideConnected; set => collideConnected = value; }
    public void* UserData { get => userData; set => userData = value; }
}

public unsafe partial struct b2WeldJointDef : IAnchoredJointDef, ISpringPropertiesJointDef
{
    public b2BodyId BodyIdA { get => bodyIdA; set => bodyIdA = value; }
    public b2BodyId BodyIdB { get => bodyIdB; set => bodyIdB = value; }
    public Vector2 LocalAnchorA { get => localAnchorA; set => localAnchorA = value; }
    public Vector2 LocalAnchorB { get => localAnchorB; set => localAnchorB = value; }
    public float Hertz { get => linearHertz; set => linearHertz = value; }
    public float DampingRatio { get => linearDampingRatio; set => linearDampingRatio = value; }
    public bool CollideConnected { get => collideConnected; set => collideConnected = value; }
    public void* UserData { get => userData; set => userData = value; }
}

public unsafe partial struct b2WheelJointDef : ISpringEnabledJointDef, ISpringPropertiesJointDef, ILimitedJointDef, IMotorizedJointDef, IAxisJointDef
{
    public b2BodyId BodyIdA { get => bodyIdA; set => bodyIdA = value; }
    public b2BodyId BodyIdB { get => bodyIdB; set => bodyIdB = value; }
    public Vector2 LocalAnchorA { get => localAnchorA; set => localAnchorA = value; }
    public Vector2 LocalAnchorB { get => localAnchorB; set => localAnchorB = value; }
    public Vector2 LocalAxisA { get => localAxisA; set => localAxisA = value; }
    public bool EnableSpring { get => enableSpring; set => enableSpring = value; }
    public float Hertz { get => hertz; set => hertz = value; }
    public float DampingRatio { get => dampingRatio; set => dampingRatio = value; }
    public bool EnableLimit { get => enableLimit; set => enableLimit = value; }
    public bool EnableMotor { get => enableMotor; set => enableMotor = value; }
    public float MotorSpeed { get => motorSpeed; set => motorSpeed = value; }
    public bool CollideConnected { get => collideConnected; set => collideConnected = value; }
    public void* UserData { get => userData; set => userData = value; }
}