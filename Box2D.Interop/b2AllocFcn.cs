using System.Runtime.InteropServices;

namespace Box2D.Interop;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void* b2AllocFcn([NativeTypeName("unsigned int")] uint size, int alignment);
