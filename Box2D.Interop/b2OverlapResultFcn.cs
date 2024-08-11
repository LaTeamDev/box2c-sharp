using System.Runtime.InteropServices;

namespace Box2D.Interop;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
[return: NativeTypeName("_Bool")]
public unsafe delegate bool b2OverlapResultFcn(b2ShapeId shapeId, void* context);
