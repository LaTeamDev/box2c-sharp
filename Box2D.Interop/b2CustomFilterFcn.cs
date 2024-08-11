using System.Runtime.InteropServices;

namespace Box2D.Interop;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
[return: NativeTypeName("_Bool")]
public unsafe delegate bool b2CustomFilterFcn(b2ShapeId shapeIdA, b2ShapeId shapeIdB, void* context);
