using System.Numerics;
using System.Runtime.CompilerServices;
using Box2D.Interop;

namespace Box2D; 

public class Joint : B2Object<b2JointId> {
    
    public Joint(b2JointId id) : base(id) { }
    
    public static implicit operator Joint(b2JointId o) => new(o);

    public override void Dispose() {
        base.Dispose();
        B2.DestroyJoint(_id);
    }

    public override bool IsValid => B2.Joint_IsValid(_id);

    public JointType Type => (JointType) B2.Joint_GetType(_id);
    public Body BodyA => new(B2.Joint_GetBodyA(_id));
    public Body BodyB => new(B2.Joint_GetBodyB(_id));

    public Vector2 LocalAnchorA => B2.Joint_GetLocalAnchorA(_id);
    public Vector2 LocalAnchorB => B2.Joint_GetLocalAnchorB(_id);

    public bool CollideConnected {
        get => B2.Joint_GetCollideConnected(_id);
        set => B2.Joint_SetCollideConnected(_id, value);
    }

    public void WakeBodies() => B2.Joint_WakeBodies(_id);

    public Vector2 ConstraintForce => B2.Joint_GetConstraintForce(_id);

    public float ConstraintTorque => B2.Joint_GetConstraintTorque(_id);
}