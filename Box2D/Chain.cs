using Box2D.Interop;

namespace Box2D; 

public class Chain : IDisposable {
    private readonly b2ChainId _id;
    public Chain(b2ChainId id) {
        _id = id;
    }

    public void Dispose() {
        B2.DestroyChain(_id);
    }

    public bool IsValid => B2.Chain_IsValid(_id);

    public float Friction {
        set => B2.Chain_SetFriction(_id, value);
    }

    public float Restitution {
        set => B2.Chain_SetRestitution(_id, value);
    }
    
}