using Box2D.Interop;

namespace Box2D; 

public class Chain : B2Object<b2ChainId> {
    public Chain(b2ChainId id) : base(id) { }
    public static implicit operator Chain(b2ChainId o) => new(o);

    public override void Dispose() {
        base.Dispose();
        B2.DestroyChain(_id);
    }

    public override bool IsValid => B2.Chain_IsValid(_id);

    public float Friction {
        set => B2.Chain_SetFriction(_id, value);
    }

    public float Restitution {
        set => B2.Chain_SetRestitution(_id, value);
    }
    
}