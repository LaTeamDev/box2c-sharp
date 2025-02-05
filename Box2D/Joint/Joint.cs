using System.Numerics;
using System.Runtime.CompilerServices;
using Box2D.Interop;

namespace Box2D; 

public abstract class Joint : B2Object<b2JointId> {
    internal protected World _world;
    
    public unsafe Joint(b2JointId id) : base(id) {
        var udata = B2.Joint_GetUserData(id);
        if (udata is not null) {
            throw new Exception($"Joint {id.index1} has already userdata! have you used native functions?");
        }
        B2.Joint_SetUserData(id, (void*)this.Pin().Pointer);
    }
    
    public static unsafe implicit operator Joint(b2JointId o) {
        var udata = B2.Joint_GetUserData(o);
        if (udata is null) throw new Exception("no such joint exists in managed");
        var pin = new Pin<Joint>(udata);
        return pin.Target;
    }

    public override unsafe void Dispose(bool disposing) {
        new Pin<Body>(B2.Joint_GetUserData(_id), true).Dispose();
        if (!disposing) return;
        B2.DestroyJoint(_id);
        _world.JointCache.Remove(this);
    }

    public override bool IsValid => B2.Joint_IsValid(_id);

    public JointType Type => (JointType) B2.Joint_GetType(_id);
    public Body BodyA => B2.Joint_GetBodyA(_id);
    public Body BodyB => B2.Joint_GetBodyB(_id);

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