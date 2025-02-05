using System.Numerics;
using Box2D.Interop;

namespace Box2D;

public class RaylibDebugDraw : IDebugDraw {
    public unsafe void Polygon(Span<Vector2> pos, b2HexColor color) {
        //idk how to draw polygons in raylib honestly
        fixed(Vector2* ptr = pos)
            DrawLineStrip(ptr, pos.Length, color.ToRaylib());
    }
    
    public unsafe void SolidPolygon(Transform transform, Span<Vector2> pos, b2HexColor color) {
        fixed(Vector2* ptr = pos)
            DrawLineStrip(ptr, pos.Length, color.ToRaylib());
    }
    public void Circle(Vector2 pos, float radius, b2HexColor color) {
        DrawCircleLinesV(pos, radius, color.ToRaylib());
    }
    public void SolidCircle(Transform transform, float radius, b2HexColor color) {
        DrawCircleV(transform.Position, radius, color.ToRaylib());
    }
    public void Capsule(Vector2 start, Vector2 end, float radius, b2HexColor color) {
        DrawCircleLinesV(start, radius, color.ToRaylib());
        DrawCircleLinesV(start, radius, color.ToRaylib());
        var normal = Vector2.Normalize(end - start);
        var perp = new Vector2(normal.Y, -normal.X);
        DrawLineV(start + perp * radius, end + perp * radius, color.ToRaylib());
        DrawLineV(start - perp * radius, end - perp * radius, color.ToRaylib());
    }
    public void SolidCapsule(Vector2 start, Vector2 end, float radius, b2HexColor color) {
        DrawCircleV(start, radius, color.ToRaylib());
        DrawCircleV(start, radius, color.ToRaylib());
        DrawLineEx(start, end, radius, color.ToRaylib());
    }
    public void Segment(Vector2 start, Vector2 end, b2HexColor color) {
        DrawLineV(start, end, color.ToRaylib());
    }
    public void Transform(Transform transform) { }
    public void Point(Vector2 pos, float radius, b2HexColor color) {
        DrawRectangleV(pos - Vector2.One * radius / 2, Vector2.One * radius, color.ToRaylib());
    }
    public void String(Vector2 pos, string str) {
        DrawText(str, pos.X, pos.Y, 10f, GOLD);
    }

    public AABB DrawingBounds => new();
    public bool UseDrawingBounds => false;
    public bool DrawShapes => true;
    public bool DrawJoints => true;
    public bool DrawJointExtras => true;
    public bool DrawAABBs => true;
    public bool DrawMass => true;
    public bool DrawContacts => true;
    public bool DrawGraphColors => true;
    public bool DrawContactNormals => true;
    public bool DrawContactImpulses => true;
    public bool DrawFrictionImpulses => true;
}