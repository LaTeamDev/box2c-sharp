using System.Numerics;
using System.Runtime.InteropServices;
using Box2D.Interop;

namespace Box2D; 

public unsafe class DebugDraw {
    public delegate void Polygon(Vector2* pos, int count, b2HexColor color, void* sth);
    public delegate void SolidPolygon(Box2D.Transform transform, Vector2* pos, int count, b2HexColor color, void* sth);
    public delegate void Circle(Vector2 pos, float radius, b2HexColor color, void* sth);
    public delegate void SolidCircle(Box2D.Transform transform, float radius, b2HexColor color, void* sth);
    public delegate void Capsule(Vector2 start, Vector2 end, float radius, b2HexColor color, void* sth);
    public delegate void SolidCapsule(Vector2 start, Vector2 end, float radius, b2HexColor color, void* sth);
    public delegate void Segment(Vector2 start, Vector2 end, b2HexColor color, void* sth);
    public delegate void Transform(Box2D.Transform transform, void* sth);
    public delegate void Point(Vector2 pos, float radius, b2HexColor color, void* sth);
    public delegate void String(Vector2 pos, string str, void* sth);

    private Polygon? _drawPolygon;
    public Polygon? DrawPolygon {
        get => _drawPolygon;
        set {
            _drawPolygon = value;
            _b2DebugDraw.DrawPolygon = Marshal.GetFunctionPointerForDelegate(_drawPolygon);
        }
    }
    private SolidPolygon? _drawSolidPolygon;
    public SolidPolygon? DrawSolidPolygon {
        get => _drawSolidPolygon;
        set {
            _drawSolidPolygon = value;
            _b2DebugDraw.DrawSolidPolygon = Marshal.GetFunctionPointerForDelegate(_drawSolidPolygon);
        }
    }

    private Circle? _drawCircle;
    public Circle? DrawCircle {
        get => _drawCircle;
        set {
            _drawCircle = value;
            _b2DebugDraw.DrawCircle = Marshal.GetFunctionPointerForDelegate(_drawCircle);
        }
    }

    private SolidCircle? _drawSolidCircle;
    public SolidCircle? DrawSolidCircle {
        get => _drawSolidCircle;
        set {
            _drawSolidCircle = value;
            _b2DebugDraw.DrawSolidCircle = Marshal.GetFunctionPointerForDelegate(_drawSolidCircle);
        }
    }

    private Capsule? _drawCapsule;
    public Capsule? DrawCapsule {
        get => _drawCapsule;
        set {
            _drawCapsule = value;
            _b2DebugDraw.DrawCapsule = Marshal.GetFunctionPointerForDelegate(_drawCapsule);
        }
    }

    private SolidCapsule? _drawSolidCapsule;
    public SolidCapsule? DrawSolidCapsule {
        get => _drawSolidCapsule;
        set {
            _drawSolidCapsule = value;
            _b2DebugDraw.DrawSolidCapsule = Marshal.GetFunctionPointerForDelegate(_drawSolidCapsule);
        }
    }

    private Segment? _drawSegment;
    public Segment? DrawSegment {
        get => _drawSegment;
        set {
            _drawSegment = value;
            _b2DebugDraw.DrawSegment = Marshal.GetFunctionPointerForDelegate(_drawSegment);
        }
    }

    private Transform? _drawTransform;
    public Transform? DrawTransform {
        get => _drawTransform;
        set {
            _drawTransform = value;
            _b2DebugDraw.DrawTransform = Marshal.GetFunctionPointerForDelegate(_drawTransform);
        }
    }

    private Point? _drawPoint;
    public Point? DrawPoint {
        get => _drawPoint;
        set {
            _drawPoint = value;
            _b2DebugDraw.DrawPoint = Marshal.GetFunctionPointerForDelegate(_drawPoint);
        }
    }

    private String? _drawString;
    public String? DrawString {
        get => _drawString;
        set {
            _drawString = value;
            _b2DebugDraw.DrawString = Marshal.GetFunctionPointerForDelegate(_drawString);
        }
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

    public bool DrawAabBs {
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