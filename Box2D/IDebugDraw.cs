using System.Numerics;
using Box2D.Interop;

namespace Box2D;

public interface IDebugDraw {
    public void Polygon(Span<Vector2> pos, b2HexColor color);
    public void SolidPolygon(Transform transform, Span<Vector2> pos, b2HexColor color);
    public void Circle(Vector2 pos, float radius, b2HexColor color);
    public void SolidCircle(Transform transform, float radius, b2HexColor color);
    public void Capsule(Vector2 start, Vector2 end, float radius, b2HexColor color);
    public void SolidCapsule(Vector2 start, Vector2 end, float radius, b2HexColor color);
    public void Segment(Vector2 start, Vector2 end, b2HexColor color);
    public void Transform(Transform transform);
    public void Point(Vector2 pos, float radius, b2HexColor color);
    public void String(Vector2 pos, string str);

    public AABB DrawingBounds { get; }

    public bool UseDrawingBounds { get; }

    public bool DrawShapes { get; }
    
    public bool DrawJoints { get; }
    
    public bool DrawJointExtras { get; }
    
    public bool DrawAABBs { get; }
    
    public bool DrawMass { get; }
    
    public bool DrawContacts { get; }
    
    public bool DrawGraphColors { get; }
    
    public bool DrawContactNormals { get; }
    
    public bool DrawContactImpulses { get; }
    
    public bool DrawFrictionImpulses { get; }
}