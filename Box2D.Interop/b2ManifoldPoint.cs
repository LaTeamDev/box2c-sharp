namespace Box2D.Interop;

public partial struct b2ManifoldPoint
{
    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 point;

    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 anchorA;

    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 anchorB;

    public float separation;

    public float normalImpulse;

    public float tangentImpulse;

    public float maxNormalImpulse;

    public float normalVelocity;

    [NativeTypeName("uint16_t")]
    public ushort id;

    [NativeTypeName("_Bool")]
    public bool persisted;
}
