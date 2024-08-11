using System.Runtime.InteropServices;

namespace Box2D.Interop;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
[return: NativeTypeName("_Bool")]
public unsafe delegate bool b2TreeQueryCallbackFcn([NativeTypeName("int32_t")] int proxyId, [NativeTypeName("int32_t")] int userData, void* context);
