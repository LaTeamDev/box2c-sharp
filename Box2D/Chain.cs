using Box2D.Interop;

namespace Box2D; 

public class Chain : B2Object<b2ChainId> {
    public Chain(b2ChainId id) : base(id) { }

    public static implicit operator Chain(b2ChainId o) {
        if (!_chainCache.TryGetValue(o, out var chain)) 
            return _chainCache[o] = new(o);
        return chain;
    }

    private static Dictionary<b2ChainId, Chain> _chainCache = new(); 

    public Chain(Body body, ChainDef def) {
        _id = B2.CreateChain(body._id, ref def._def);
        _chainCache.Add(_id, this);
    }

    public override void Dispose(bool disposing) {
        _chainCache.Remove(_id);
        if (!disposing) return;
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