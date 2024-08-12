using System.Runtime.InteropServices;

namespace Box2D.Interop;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate float b2CastResultFcn(b2ShapeId shapeId, [NativeTypeName("b2Vec2")] System.Numerics.Vector2 point, [NativeTypeName("b2Vec2")] System.Numerics.Vector2 normal, float fraction, void* context);
