using System.Runtime.InteropServices;

namespace Box2D.Interop;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate float b2TreeShapeCastCallbackFcn([NativeTypeName("const b2ShapeCastInput *")] b2ShapeCastInput* input, [NativeTypeName("int32_t")] int proxyId, [NativeTypeName("int32_t")] int userData, void* context);
