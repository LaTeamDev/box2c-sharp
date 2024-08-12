using System.Runtime.InteropServices;

namespace Box2D; 

internal unsafe class PinHelper<T> : IDisposable {
    public PinHelper(T obj) {
        _handle = GCHandle.Alloc(obj, GCHandleType.Pinned);
    }

    private GCHandle _handle;
    public T* Pointer => (T*)_handle.AddrOfPinnedObject();

    public void Dispose() {
        _handle.Free();
    }
}