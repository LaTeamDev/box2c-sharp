using Box2D.Interop;

namespace Box2D; 

public abstract class B2Object<T> : IDisposable {
    internal T _id;

    protected B2Object() { }
    
    public B2Object(T id) {
        _id = id;
    }

    public virtual void Dispose() {
        Dispose(true);
    }

    public abstract void Dispose(bool disposing);
    public override int GetHashCode() => _id.GetHashCode();
    
    public override bool Equals(object? obj)
    {
        if (obj is not B2Object<T> type)
            return false;
        if (type._id is not T id)
            return false;
        return _id.Equals(id);
    }
    public abstract bool IsValid { get; }
    
    public static implicit operator T(B2Object<T> o) => o._id;
}