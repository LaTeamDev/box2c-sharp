using System.Runtime.InteropServices;

namespace Box2D.Interop;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate int b2AssertFcn([NativeTypeName("const char *")] sbyte* condition, [NativeTypeName("const char *")] sbyte* fileName, int lineNumber);
