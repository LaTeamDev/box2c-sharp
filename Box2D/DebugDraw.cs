using System.Numerics;
using System.Runtime.InteropServices;
using Box2D.Interop;

namespace Box2D; 

public unsafe class DebugDraw {
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void Polygon(Vector2* pos, int count, b2HexColor color, void* sth);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void SolidPolygon(Box2D.Transform transform, Vector2* pos, int count, b2HexColor color, void* sth);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void Circle(Vector2 pos, float radius, b2HexColor color, void* sth);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void SolidCircle(Box2D.Transform transform, float radius, b2HexColor color, void* sth);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void Capsule(Vector2 start, Vector2 end, float radius, b2HexColor color, void* sth);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void SolidCapsule(Vector2 start, Vector2 end, float radius, b2HexColor color, void* sth);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void Segment(Vector2 start, Vector2 end, b2HexColor color, void* sth);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void Transform(Box2D.Transform transform, void* sth);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void Point(Vector2 pos, float radius, b2HexColor color, void* sth);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void String(Vector2 pos, string str, void* sth);
    
    public Polygon? DrawPolygon {
        get => Marshal.GetDelegateForFunctionPointer<Polygon?>(_b2DebugDraw.DrawPolygon);
        set => _b2DebugDraw.DrawPolygon = Marshal.GetFunctionPointerForDelegate(value);
    }

    public SolidPolygon? DrawSolidPolygon {
        get => Marshal.GetDelegateForFunctionPointer<SolidPolygon?>(_b2DebugDraw.DrawSolidPolygon);
        set => _b2DebugDraw.DrawSolidPolygon = Marshal.GetFunctionPointerForDelegate(value);
    }

    public Circle? DrawCircle {
        get => Marshal.GetDelegateForFunctionPointer<Circle?>(_b2DebugDraw.DrawCircle);
        set => _b2DebugDraw.DrawCircle = Marshal.GetFunctionPointerForDelegate(value);
    }

    public SolidCircle? DrawSolidCircle {
        get => Marshal.GetDelegateForFunctionPointer<SolidCircle?>(_b2DebugDraw.DrawSolidCircle);
        set => _b2DebugDraw.DrawSolidCircle = Marshal.GetFunctionPointerForDelegate(value);
    }

    public Capsule? DrawCapsule {
        get => Marshal.GetDelegateForFunctionPointer<Capsule?>(_b2DebugDraw.DrawCapsule);
        set => _b2DebugDraw.DrawCapsule = Marshal.GetFunctionPointerForDelegate(value);
    }

    public SolidCapsule? DrawSolidCapsule {
        get => Marshal.GetDelegateForFunctionPointer<SolidCapsule?>(_b2DebugDraw.DrawSolidCapsule);
        set => _b2DebugDraw.DrawSolidCapsule = Marshal.GetFunctionPointerForDelegate(value);
    }

    public Segment? DrawSegment {
        get => Marshal.GetDelegateForFunctionPointer<Segment?>(_b2DebugDraw.DrawSegment);
        set => _b2DebugDraw.DrawSegment = Marshal.GetFunctionPointerForDelegate(value);
    }

    public Transform? DrawTransform {
        get => Marshal.GetDelegateForFunctionPointer<Transform?>(_b2DebugDraw.DrawTransform);
        set => _b2DebugDraw.DrawTransform = Marshal.GetFunctionPointerForDelegate(value);
    }

    public Point? DrawPoint {
        get => Marshal.GetDelegateForFunctionPointer<Point?>(_b2DebugDraw.DrawPoint);
        set => _b2DebugDraw.DrawPoint = Marshal.GetFunctionPointerForDelegate(value);
    }

    public String? DrawString {
        get => Marshal.GetDelegateForFunctionPointer<String?>(_b2DebugDraw.DrawString);
        set => _b2DebugDraw.DrawString = Marshal.GetFunctionPointerForDelegate(value);
    }
    
    public bool UseDrawingBounds {
        get => _b2DebugDraw.useDrawingBounds;
        set => _b2DebugDraw.useDrawingBounds = value;
    }

    public bool DrawShapes {
        get => _b2DebugDraw.drawShapes;
        set => _b2DebugDraw.drawShapes = value;
    }

    public bool DrawJoints {
        get => _b2DebugDraw.drawJoints;
        set => _b2DebugDraw.drawJoints = value;
    }

    public bool DrawJointExtras {
        get => _b2DebugDraw.drawJointExtras;
        set => _b2DebugDraw.drawJointExtras = value;
    }

    public bool DrawAABBs {
        get => _b2DebugDraw.drawAABBs;
        set => _b2DebugDraw.drawAABBs = value;
    }

    public bool DrawMass {
        get => _b2DebugDraw.drawMass;
        set => _b2DebugDraw.drawMass = value;
    }

    public bool DrawContacts {
        get => _b2DebugDraw.drawContacts;
        set => _b2DebugDraw.drawContacts = value;
    }

    public bool DrawGraphColors {
        get => _b2DebugDraw.drawGraphColors;
        set => _b2DebugDraw.drawGraphColors = value;
    }

    public bool DrawContactNormals {
        get => _b2DebugDraw.drawContactNormals;
        set => _b2DebugDraw.drawContactNormals = value;
    }

    public bool DrawContactImpulses {
        get => _b2DebugDraw.drawContactImpulses;
        set => _b2DebugDraw.drawContactImpulses = value;
    }

    public bool DrawFrictionImpulses {
        get => _b2DebugDraw.drawFrictionImpulses;
        set => _b2DebugDraw.drawFrictionImpulses = value;
    }

    internal b2DebugDraw _b2DebugDraw;
}