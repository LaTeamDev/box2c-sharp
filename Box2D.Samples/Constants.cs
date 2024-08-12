using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Box2D.Interop;
using ZeroElectric.Vinculum;

namespace Box2D; 

public static class Constants {
    public static DebugDraw debugDraw = new();

    static unsafe Constants() {
        debugDraw.DrawString = DebugDrawDrawString;
        debugDraw.DrawCircle = DebugDrawDrawCircle;
        debugDraw.DrawCapsule = DebugDrawDrawCapsule;
        debugDraw.DrawPoint = DebugDrawDrawPoint;
        debugDraw.DrawPolygon = DebugDrawDrawPolygon;
        debugDraw.DrawSegment = DebugDrawDrawSegment;
        debugDraw.DrawTransform = DebugDrawDrawTransform;
        debugDraw.DrawSolidCapsule = DebugDrawDrawSolidCapsule;
        debugDraw.DrawSolidCircle = DebugDrawDrawSolidCircle;
        debugDraw.DrawSolidPolygon = DebugDrawDrawSolidPolygon;
        debugDraw.UseDrawingBounds = false;
        debugDraw.DrawShapes = true;
        debugDraw.DrawContacts = true;
        debugDraw.DrawJoints = true;
        debugDraw.DrawMass = true;
        debugDraw.DrawContactImpulses = true;
        debugDraw.DrawContactNormals = true;
        debugDraw.DrawFrictionImpulses = true;
        debugDraw.DrawGraphColors = true;
        debugDraw.DrawJointExtras = true;
        debugDraw.DrawAABBs = true;
    }

    private static unsafe DebugDraw.SolidPolygon DebugDrawDrawSolidPolygon =
        (Transform transform, Vector2* pos, int count, b2HexColor color, void* sth) => {
            //idk how to draw polygons in raylib honestly
            DrawLineStrip(pos, count, color.ToRaylib());
        };

    private static unsafe DebugDraw.SolidCircle DebugDrawDrawSolidCircle =
        (Transform transform, float radius, b2HexColor color, void* sth) => {
            DrawCircleV(transform.Position, radius, color.ToRaylib());
        };

    private static unsafe DebugDraw.SolidCapsule DebugDrawDrawSolidCapsule =
        (Vector2 start, Vector2 end, float radius, b2HexColor color, void* sth) => {
            DrawCircleV(start, radius, color.ToRaylib());
            DrawCircleV(start, radius, color.ToRaylib());
            DrawLineEx(start, end, radius, color.ToRaylib());
        };

    private static unsafe DebugDraw.Transform DebugDrawDrawTransform = (Transform transform, void* sth) => { };

    private static unsafe DebugDraw.Segment DebugDrawDrawSegment = (Vector2 start, Vector2 end, b2HexColor color, void* sth) => {
        DrawLineV(start, end, color.ToRaylib());
    };

    private static unsafe DebugDraw.Polygon DebugDrawDrawPolygon = (Vector2* pos, int count, b2HexColor color, void* sth) => {
        DrawLineStrip(pos, count, color.ToRaylib());
    };

    private static unsafe DebugDraw.Point DebugDrawDrawPoint = (Vector2 pos, float radius, b2HexColor color, void* sth) => {
        DrawRectangleV(pos - Vector2.One * radius / 2, Vector2.One * radius, color.ToRaylib());
    };

    private static unsafe DebugDraw.Capsule DebugDrawDrawCapsule =
        (Vector2 start, Vector2 end, float radius, b2HexColor color, void* sth) => {
            DrawCircleLinesV(start, radius, color.ToRaylib());
            DrawCircleLinesV(start, radius, color.ToRaylib());
            var normal = Vector2.Normalize(end - start);
            var perp = new Vector2(normal.Y, -normal.X);
            DrawLineV(start + perp * radius, end + perp * radius, color.ToRaylib());
            DrawLineV(start - perp * radius, end - perp * radius, color.ToRaylib());
        };

    private static unsafe DebugDraw.Circle DebugDrawDrawCircle = (Vector2 pos, float radius, b2HexColor color, void* sth) => {
        DrawCircleLinesV(pos, radius, color.ToRaylib());
    };

    private static unsafe DebugDraw.String DebugDrawDrawString = (Vector2 pos, string str, void* sth) => {
        DrawText(str, pos.X, pos.Y, 10f, GOLD);
    };
}