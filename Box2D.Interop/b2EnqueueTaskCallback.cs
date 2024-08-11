using System;
using System.Runtime.InteropServices;

namespace Box2D.Interop;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void* b2EnqueueTaskCallback([NativeTypeName("b2TaskCallback *")] IntPtr task, [NativeTypeName("int32_t")] int itemCount, [NativeTypeName("int32_t")] int minRange, void* taskContext, void* userContext);
