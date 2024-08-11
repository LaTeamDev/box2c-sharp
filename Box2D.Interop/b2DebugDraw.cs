using System;

namespace Box2D.Interop;

public unsafe partial struct b2DebugDraw
{
    [NativeTypeName("void (*)(const b2Vec2 *, int, b2HexColor, void *)")]
    public IntPtr DrawPolygon;

    [NativeTypeName("void (*)(b2Transform, const b2Vec2 *, int, float, b2HexColor, void *)")]
    public IntPtr DrawSolidPolygon;

    [NativeTypeName("void (*)(b2Vec2, float, b2HexColor, void *)")]
    public IntPtr DrawCircle;

    [NativeTypeName("void (*)(b2Transform, float, b2HexColor, void *)")]
    public IntPtr DrawSolidCircle;

    [NativeTypeName("void (*)(b2Vec2, b2Vec2, float, b2HexColor, void *)")]
    public IntPtr DrawCapsule;

    [NativeTypeName("void (*)(b2Vec2, b2Vec2, float, b2HexColor, void *)")]
    public IntPtr DrawSolidCapsule;

    [NativeTypeName("void (*)(b2Vec2, b2Vec2, b2HexColor, void *)")]
    public IntPtr DrawSegment;

    [NativeTypeName("void (*)(b2Transform, void *)")]
    public IntPtr DrawTransform;

    [NativeTypeName("void (*)(b2Vec2, float, b2HexColor, void *)")]
    public IntPtr DrawPoint;

    [NativeTypeName("void (*)(b2Vec2, const char *, void *)")]
    public IntPtr DrawString;

    public b2AABB drawingBounds;

    [NativeTypeName("_Bool")]
    public bool useDrawingBounds;

    [NativeTypeName("_Bool")]
    public bool drawShapes;

    [NativeTypeName("_Bool")]
    public bool drawJoints;

    [NativeTypeName("_Bool")]
    public bool drawJointExtras;

    [NativeTypeName("_Bool")]
    public bool drawAABBs;

    [NativeTypeName("_Bool")]
    public bool drawMass;

    [NativeTypeName("_Bool")]
    public bool drawContacts;

    [NativeTypeName("_Bool")]
    public bool drawGraphColors;

    [NativeTypeName("_Bool")]
    public bool drawContactNormals;

    [NativeTypeName("_Bool")]
    public bool drawContactImpulses;

    [NativeTypeName("_Bool")]
    public bool drawFrictionImpulses;

    public void* context;
}
