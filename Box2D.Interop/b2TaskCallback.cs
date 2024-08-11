using System.Runtime.InteropServices;

namespace Box2D.Interop;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void b2TaskCallback([NativeTypeName("int32_t")] int startIndex, [NativeTypeName("int32_t")] int endIndex, [NativeTypeName("uint32_t")] uint workerIndex, void* taskContext);
