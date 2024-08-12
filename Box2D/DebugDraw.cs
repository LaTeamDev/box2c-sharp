using System.Numerics;
using System.Runtime.InteropServices;
using Box2D.Interop;

namespace Box2D; 

public unsafe class DebugDraw {
    public delegate void Polygon(Vector2* pos, int count, b2HexColor color, void* sth);
    public delegate void SolidPolygon(Box2D.Transform transform, Vector2* pos, int count, b2HexColor color, void* sth);
    public delegate void Circle(Vector2 pos, float radius, b2HexColor color, void* sth);
    public delegate void SolidCircle(Transform transform, float radius, b2HexColor color, void* sth);
    public delegate void Capsule(Vector2 start, Vector2 end, float radius, b2HexColor color, void* sth);
    public delegate void SolidCapsule(Vector2 start, Vector2 end, float radius, b2HexColor color, void* sth);
    public delegate void Segment(Vector2 start, Vector2 end, b2HexColor color, void* sth);
    public delegate void Transform(Box2D.Transform transform, void* sth);
    public delegate void Point(Vector2 pos, float radius, b2HexColor color, void* sth);
    public delegate void DrawString(Vector2 pos, string str, void* sth);

    private Polygon? _drawPolygon;
    public Polygon? DrawPolygon {
        get => _drawPolygon;
        set {
            _drawPolygon = value;
            _b2DebugDraw.DrawPolygon = Marshal.GetFunctionPointerForDelegate(_drawPolygon);
        }
    } //TODO: make this for other delegates
    
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