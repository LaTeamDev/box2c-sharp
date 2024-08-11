namespace Box2D.Interop;

public partial struct b2ManifoldPoint
{
    public b2Vec2 point;

    public b2Vec2 anchorA;

    public b2Vec2 anchorB;

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
