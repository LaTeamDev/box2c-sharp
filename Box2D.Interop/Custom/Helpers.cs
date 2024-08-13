using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Box2D.Interop; 

public unsafe partial class B2 {
    public static int Body_GetShapes(b2BodyId bodyId, ref b2ShapeId[] shapeArray) {
        return Body_GetShapes(bodyId, (b2ShapeId*)Unsafe.AsPointer(ref shapeArray), shapeArray.Length);
    }
    public static int Body_GetJoints(b2BodyId bodyId, ref b2JointId[] jointArray) {
        return Body_GetJoints(bodyId, (b2JointId*)Unsafe.AsPointer(ref jointArray), jointArray.Length);
    }
    
    public static int Body_GetContactData(b2BodyId bodyId, ref b2ContactData[] contactData) {
        return Body_GetContactData(bodyId, (b2ContactData*)Unsafe.AsPointer(ref contactData), contactData.Length);
    }
    
    public static b2ShapeId CreateCircleShape(b2BodyId bodyId, ref b2ShapeDef shapeDef, ref Circle circle) => 
        CreateCircleShape(bodyId,  (b2ShapeDef*)Unsafe.AsPointer(ref shapeDef), (Circle*)Unsafe.AsPointer(ref circle));
    
    public static b2ShapeId CreateSegmentShape(b2BodyId bodyId, ref b2ShapeDef shapeDef, ref Segment segment) => 
        CreateSegmentShape(bodyId,  (b2ShapeDef*)Unsafe.AsPointer(ref shapeDef), (Segment*)Unsafe.AsPointer(ref segment));
    public static b2ShapeId CreateCapsuleShape(b2BodyId bodyId, ref b2ShapeDef shapeDef, ref Capsule capsule) => 
        CreateCapsuleShape(bodyId,  (b2ShapeDef*)Unsafe.AsPointer(ref shapeDef), (Capsule*)Unsafe.AsPointer(ref capsule));
    public static b2ShapeId CreatePolygonShape(b2BodyId bodyId, ref b2ShapeDef shapeDef, ref Polygon polyhon) => 
        CreatePolygonShape(bodyId,  (b2ShapeDef*)Unsafe.AsPointer(ref shapeDef), (Polygon*)Unsafe.AsPointer(ref polyhon));

    public static void Shape_SetCircle(b2ShapeId id, ref Circle circle) =>
        Shape_SetCircle(id, (Circle*)Unsafe.AsPointer(ref circle));
    public static void Shape_SetPolygon(b2ShapeId id, ref Polygon polygon) =>
        Shape_SetPolygon(id, (Polygon*)Unsafe.AsPointer(ref polygon));
    public static void Shape_SetSegment(b2ShapeId id, ref Segment segment) =>
        Shape_SetSegment(id, (Segment*)Unsafe.AsPointer(ref segment));
    public static void Shape_SetCapsule(b2ShapeId id, ref Capsule capsule) =>
        Shape_SetCapsule(id, (Capsule*)Unsafe.AsPointer(ref capsule));
    
    public static int Shape_GetContactData(b2ShapeId shapeId, ref b2ContactData[] contactData) {
        return Shape_GetContactData(shapeId, (b2ContactData*)Unsafe.AsPointer(ref contactData), contactData.Length);
    }
    
    static B2() {
        SetAssertFcn(Marshal.GetFunctionPointerForDelegate(B2AssertFcn));
    }

    private static int B2AssertFcn(sbyte* condition, sbyte* name, int number) {
        var conditionStr = Marshal.PtrToStringUTF8((IntPtr) condition);
        var nameStr = Marshal.PtrToStringUTF8((IntPtr) name);
        throw new Box2DAssertionException($"{conditionStr} at {nameStr}:{number}");
    }

    //this stuff is included in math_function.h that we dont generate bindings for
    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2SetLengthUnitsPerMeter", ExactSpelling = true)]
    public static extern void SetLengthUnitsPerMeter(float lengthUnits);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2GetLengthUnitsPerMeter", ExactSpelling = true)]
    public static extern float GetLengthUnitsPerMeter();

    public static void World_OverlapCircle(b2WorldId worldId, ref Circle circle, Transform transform,
        b2QueryFilter filter, b2OverlapResultFcn fcn, void* context) =>
        World_OverlapCircle(worldId, (Circle*) Unsafe.AsPointer(ref circle), transform, filter,
            Marshal.GetFunctionPointerForDelegate(fcn), context);
    
    public static void World_OverlapCapsule(b2WorldId worldId, ref Capsule capsule, Transform transform,
        b2QueryFilter filter, b2OverlapResultFcn fcn, void* context) =>
        World_OverlapCapsule(worldId, (Capsule*) Unsafe.AsPointer(ref capsule), transform, filter,
            Marshal.GetFunctionPointerForDelegate(fcn), context);
    
    public static void World_OverlapPolygon(b2WorldId worldId, ref Polygon polygon, Transform transform,
        b2QueryFilter filter, b2OverlapResultFcn fcn, void* context) =>
        World_OverlapPolygon(worldId, (Polygon*) Unsafe.AsPointer(ref polygon), transform, filter,
            Marshal.GetFunctionPointerForDelegate(fcn), context);

    public static void World_CastRay(b2WorldId worldId, System.Numerics.Vector2 origin,
        System.Numerics.Vector2 translation, b2QueryFilter filter, b2CastResultFcn fcn, void* context) =>
        World_CastRay(worldId, origin, translation, filter, Marshal.GetFunctionPointerForDelegate(fcn), context);

    public static void World_CastCircle(b2WorldId worldId, ref Circle circle, Transform originTransform,
        Vector2 translation, b2QueryFilter filter, b2CastResultFcn fcn, void* context) =>
        World_CastCircle(worldId, (Circle*)Unsafe.AsPointer(ref circle), originTransform, translation, filter,
            Marshal.GetFunctionPointerForDelegate(fcn), context);
    public static void World_CastCapsule(b2WorldId worldId, ref Capsule capsule, Transform originTransform,
        Vector2 translation, b2QueryFilter filter, b2CastResultFcn fcn, void* context) =>
        World_CastCapsule(worldId, (Capsule*)Unsafe.AsPointer(ref capsule), originTransform, translation, filter,
            Marshal.GetFunctionPointerForDelegate(fcn), context);
    
    public static void World_CastPolygon(b2WorldId worldId, ref Polygon polygon, Transform originTransform,
        Vector2 translation, b2QueryFilter filter, b2CastResultFcn fcn, void* context) =>
        World_CastPolygon(worldId, (Polygon*)Unsafe.AsPointer(ref polygon), originTransform, translation, filter,
            Marshal.GetFunctionPointerForDelegate(fcn), context);

    public static b2ChainId CreateChain(b2BodyId bodyId, ref b2ChainDef chainDef) =>
        CreateChain(bodyId, (b2ChainDef*)Unsafe.AsPointer(ref chainDef));

    public static b2JointId CreateDistanceJoint(b2WorldId worldId, ref b2DistanceJointDef distanceJointDef) =>
        CreateDistanceJoint(worldId, (b2DistanceJointDef*) Unsafe.AsPointer(ref distanceJointDef));

    public static b2JointId CreateMotorJoint(b2WorldId worldId, ref b2MotorJointDef jointDef) =>
        CreateMotorJoint(worldId, (b2MotorJointDef*) Unsafe.AsPointer(ref jointDef));

    public static b2JointId CreateMouseJoint(b2WorldId worldId, ref b2MouseJointDef jointDef) =>
        CreateMouseJoint(worldId, (b2MouseJointDef*) Unsafe.AsPointer(ref jointDef));

    public static b2JointId CreatePrismaticJoint(b2WorldId worldId, ref b2PrismaticJointDef jointDef) =>
        CreatePrismaticJoint(worldId, (b2PrismaticJointDef*) Unsafe.AsPointer(ref jointDef));

    public static b2JointId CreateRevoluteJoint(b2WorldId worldId, ref b2RevoluteJointDef jointDef) =>
        CreateRevoluteJoint(worldId, (b2RevoluteJointDef*) Unsafe.AsPointer(ref jointDef));

    public static b2JointId CreateWeldJoint(b2WorldId worldId, ref b2WeldJointDef jointDef) =>
        CreateWeldJoint(worldId, (b2WeldJointDef*) Unsafe.AsPointer(ref jointDef));

    public static b2JointId CreateWheelJoint(b2WorldId worldId, ref b2WheelJointDef jointDef) =>
        CreateWheelJoint(worldId, (b2WheelJointDef*) Unsafe.AsPointer(ref jointDef));
    
}