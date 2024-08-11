using System.Runtime.InteropServices;

namespace Box2D.Interop;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void b2FinishTaskCallback(void* userTask, void* userContext);
