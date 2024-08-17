using Box2D.Interop;

namespace Box2D; 

public abstract class B2Object<T> : IDisposable {
    internal T _id;
    
    public B2Object(T id) {
        _id = id;
    }
    
    public object? UserData {
        get => __USERDATA_CACHE.TryGetValue(_id, out var result) ? result : null;
        set => __USERDATA_CACHE[_id] = value;
    }
    
    internal static Dictionary<T, object?> __USERDATA_CACHE = new();
    
    public virtual void Dispose() {
        __USERDATA_CACHE.Remove(_id);
    }
    
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
}