using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Box2D.Interop;

namespace Box2D; 

internal sealed unsafe class ManagedDebugDraw : IDisposable {
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void DrawPolygon(Vector2* vector, int count, b2HexColor color, void* ctx) {
        var draw = GCHandle.FromIntPtr((IntPtr)ctx).Target as IDebugDraw;
        draw?.Polygon(new Span<Vector2>(vector, count), color);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void DrawSolidPolygon(Transform transform, Vector2* vector, int count, b2HexColor color, void* ctx) {
        var draw = GCHandle.FromIntPtr((IntPtr)ctx).Target as IDebugDraw;
        var array = new Span<Vector2>(vector, count);
        draw?.SolidPolygon(transform, array, color);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void DrawCircle(Vector2 pos, float radius, b2HexColor color, void* ctx) {
        var draw = GCHandle.FromIntPtr((IntPtr)ctx).Target as IDebugDraw;
        draw?.Circle(pos, radius, color);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void DrawSolidCircle(Transform transform, float radius, b2HexColor color, void* ctx) {
        var draw = GCHandle.FromIntPtr((IntPtr)ctx).Target as IDebugDraw;
        draw.SolidCircle(transform, radius, color);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void DrawCapsule(Vector2 start, Vector2 end, float radius, b2HexColor color, void* ctx) {
        var draw = GCHandle.FromIntPtr((IntPtr)ctx).Target as IDebugDraw;
        draw.Capsule(start, end, radius, color);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void DrawSolidCapsule(Vector2 start, Vector2 end, float radius, b2HexColor color, void* ctx) {
        var draw = GCHandle.FromIntPtr((IntPtr)ctx).Target as IDebugDraw;
        draw.SolidCapsule(start, end, radius, color);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void DrawSegment(Vector2 start, Vector2 end, b2HexColor color, void* ctx) {
        var draw = GCHandle.FromIntPtr((IntPtr)ctx).Target as IDebugDraw;
        draw.Segment(start, end, color);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void DrawTransform(Transform transform, void* ctx) {
        var draw = GCHandle.FromIntPtr((IntPtr)ctx).Target as IDebugDraw;
        draw.Transform(transform);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void DrawPoint(Vector2 pos, float radius, b2HexColor color, void* ctx) {
        var draw = GCHandle.FromIntPtr((IntPtr)ctx).Target as IDebugDraw;
        draw.Point(pos, radius, color);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void DrawString(Vector2 pos, IntPtr strPtr, void* ctx) {
        var draw = GCHandle.FromIntPtr((IntPtr)ctx).Target as IDebugDraw;
        var str = Marshal.PtrToStringUTF8(strPtr);
        if (str is null) return;
        draw.String(pos, str);
    }

    private readonly Pin<IDebugDraw> _context;

    private static delegate*unmanaged[Cdecl]<Vector2*, int, b2HexColor, void*, void> _drawPolygon = &DrawPolygon;
    private static delegate*unmanaged[Cdecl]<Transform, Vector2*, int, b2HexColor, void*, void> _drawSolidPolygon = &DrawSolidPolygon;
    private static delegate*unmanaged[Cdecl]<Vector2, float, b2HexColor, void*, void> _drawCircle = &DrawCircle;
    private static delegate*unmanaged[Cdecl]<Transform, float, b2HexColor, void*, void> _drawSolidCircle = &DrawSolidCircle;
    private static delegate*unmanaged[Cdecl]<Vector2, Vector2, float, b2HexColor, void*, void> _drawCapsule = &DrawCapsule;
    private static delegate*unmanaged[Cdecl]<Vector2, Vector2, float, b2HexColor, void*, void> _drawSolidCapsule = &DrawSolidCapsule;
    private static delegate*unmanaged[Cdecl]<Vector2, Vector2, b2HexColor, void*, void> _drawSegment = &DrawSegment;
    private static delegate*unmanaged[Cdecl]<Transform, void*, void> _drawTransform = &DrawTransform;
    private static delegate*unmanaged[Cdecl]<Vector2, float, b2HexColor, void*, void> _drawPoint = &DrawPoint;
    private static delegate*unmanaged[Cdecl]<Vector2, IntPtr, void*, void> _drawString = &DrawString;
    
    public ManagedDebugDraw(IDebugDraw draw) {
        _context = draw.Pin();
        @interface = new b2DebugDraw {
            drawingBounds = draw.DrawingBounds,
            useDrawingBounds = draw.UseDrawingBounds,
            drawShapes = draw.DrawShapes,
            drawJoints = draw.DrawJoints,
            drawJointExtras = draw.DrawJointExtras,
            drawAABBs = draw.DrawAABBs,
            drawMass = draw.DrawMass,
            drawContacts = draw.DrawContacts,
            drawGraphColors = draw.DrawGraphColors,
            drawContactNormals = draw.DrawContactNormals,
            drawContactImpulses = draw.DrawContactImpulses,
            drawFrictionImpulses = draw.DrawFrictionImpulses,
            context = (void*)_context.Pointer,
            DrawPolygon = (IntPtr)_drawPolygon,
            DrawSolidPolygon = (IntPtr)_drawSolidPolygon,
            DrawCircle = (IntPtr)_drawCircle,
            DrawSolidCircle = (IntPtr)_drawSolidCircle,
            DrawCapsule = (IntPtr)_drawCapsule,
            DrawSolidCapsule = (IntPtr)_drawSolidCapsule,
            DrawSegment = (IntPtr)_drawSegment,
            DrawTransform = (IntPtr)_drawTransform,
            DrawPoint = (IntPtr)_drawPoint,
            DrawString = (IntPtr)_drawString,
        };
    }

    public b2DebugDraw @interface;

    public void Dispose() {
        _context.Dispose();
    }
}