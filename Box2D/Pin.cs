using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Box2D;

internal class Pin<T> : IDisposable {
    private GCHandle _handle;
    public IntPtr Addr => _handle.AddrOfPinnedObject();
    public IntPtr Pointer => GCHandle.ToIntPtr(_handle);
    
    public bool IsAllocated => _handle.IsAllocated;
    public bool IsOwner { get; }
    
    public Pin(T obj, GCHandleType type = GCHandleType.Normal) {
        _handle = GCHandle.Alloc(obj, type);
        IsOwner = true;
    }

    public Pin(IntPtr ptr, bool takeOwnership = false) {
        _handle = GCHandle.FromIntPtr(ptr);
        IsOwner = takeOwnership;
    }
    public unsafe Pin(void* ptr, bool takeOwnership = false) : this((IntPtr)ptr, takeOwnership) { }
    
    public bool TryGetTarget([MaybeNullWhen(false)] out T target)
    {
        if (!IsAllocated) {
            target = default;
            return false;
        }

        try {
            if (_handle.Target is T value) {
                target = value;
                return true;
            }
        }
        catch (InvalidOperationException) { }

        target = default;
        return false;
    }

    public T Target {
        get {
            if (!IsAllocated) 
                throw new MemberAccessException("Attempt to get target from deallocated pin");
            if (_handle.Target is not T target)
                throw new InvalidCastException("Attempt to cast value (wrong pin)");
            return target;
        }
    }

    
    public void Dispose() {
        if (IsOwner && IsAllocated)
            _handle.Free();
    }
}

internal static class PinExtension {
    public static Pin<T> Pin<T>(this T obj, GCHandleType type = GCHandleType.Normal) => new(obj, type);
    public static Pin<T> AsPin<T>(this IntPtr ptr, bool takeOwnership = false) => new(ptr, takeOwnership);
}