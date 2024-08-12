using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZeroElectric.Vinculum;

namespace Box2D; 

public static class Constants {
    public static DebugDraw debugDraw = new();

    static unsafe Constants() {
        debugDraw.DrawString = (pos, str, sth) => {
            DrawText(str, pos.X, pos.Y, 10f, GOLD);
        };
        debugDraw.DrawCircle = (pos, radius, color, sth) => {
            DrawCircleLinesV(pos, radius, color.ToRaylib());
        };
        debugDraw.DrawCapsule = (start, end, radius, color, sth) => {
            DrawCircleLinesV(start, radius, color.ToRaylib());
            DrawCircleLinesV(start, radius, color.ToRaylib());
            var normal = Vector2.Normalize(end - start);
            var perp = new Vector2(normal.Y, -normal.X);
            DrawLineV(start+perp*radius, end+perp*radius, color.ToRaylib());
            DrawLineV(start-perp*radius, end-perp*radius, color.ToRaylib());
        };
        debugDraw.DrawPoint = (pos, radius, color, sth) => {
            DrawRectangleV(pos-Vector2.One*radius/2, Vector2.One*radius, color.ToRaylib());
        };
        debugDraw.DrawPolygon = (pos, count, color, sth) => {
            DrawLineStrip(pos, count, color.ToRaylib());
        };
        debugDraw.DrawSegment = (start, end, color, sth) => {
            DrawLineV(start, end, color.ToRaylib());
        };
        debugDraw.DrawTransform = (transform, sth) => {
            
        };
        debugDraw.DrawSolidCapsule = (start, end, radius, color, sth) => {
            DrawCircleV(start, radius, color.ToRaylib());
            DrawCircleV(start, radius, color.ToRaylib());
            DrawLineEx(start, end, radius, color.ToRaylib());
        };
        debugDraw.DrawSolidCircle = (transform, radius, color, sth) => {
            DrawCircleV(transform.Position, radius, color.ToRaylib());
        };
        debugDraw.DrawSolidPolygon = (transform, pos, count, color, sth) => {
            //idk how to draw polygons in raylib honestly
            DrawLineStrip(pos, count, color.ToRaylib());
        };
    }
}