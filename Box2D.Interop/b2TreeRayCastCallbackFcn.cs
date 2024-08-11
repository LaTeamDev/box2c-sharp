using System.Runtime.InteropServices;

namespace Box2D.Interop;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate float b2TreeRayCastCallbackFcn([NativeTypeName("const b2RayCastInput *")] b2RayCastInput* input, [NativeTypeName("int32_t")] int proxyId, [NativeTypeName("int32_t")] int userData, void* context);
