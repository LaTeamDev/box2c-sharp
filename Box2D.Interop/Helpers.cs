using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Box2D.Interop; 

public partial class B2 {
    public static unsafe int Body_GetShapes(b2BodyId bodyId, ref b2ShapeId[] shapeArray) {
        return Body_GetShapes(bodyId, (b2ShapeId*)Unsafe.AsPointer(ref shapeArray), shapeArray.Length);
    }
    public static unsafe int Body_GetJoints(b2BodyId bodyId, ref b2JointId[] jointArray) {
        return Body_GetJoints(bodyId, (b2JointId*)Unsafe.AsPointer(ref jointArray), jointArray.Length);
    }
    
    public static unsafe int Body_GetContactData(b2BodyId bodyId, ref b2ContactData[] contactData) {
        return Body_GetContactData(bodyId, (b2ContactData*)Unsafe.AsPointer(ref contactData), contactData.Length);
    }
    
    public static unsafe b2ShapeId CreateCircleShape(b2BodyId bodyId, ref b2ShapeDef shapeDef, ref Circle circle) => 
        CreateCircleShape(bodyId,  (b2ShapeDef*)Unsafe.AsPointer(ref shapeDef), (Circle*)Unsafe.AsPointer(ref circle));
    
    public static unsafe b2ShapeId CreateSegmentShape(b2BodyId bodyId, ref b2ShapeDef shapeDef, ref Segment segment) => 
        CreateSegmentShape(bodyId,  (b2ShapeDef*)Unsafe.AsPointer(ref shapeDef), (Segment*)Unsafe.AsPointer(ref segment));
    public static unsafe b2ShapeId CreateCapsuleShape(b2BodyId bodyId, ref b2ShapeDef shapeDef, ref Capsule capsule) => 
        CreateCapsuleShape(bodyId,  (b2ShapeDef*)Unsafe.AsPointer(ref shapeDef), (Capsule*)Unsafe.AsPointer(ref capsule));
    public static unsafe b2ShapeId CreatePolygonShape(b2BodyId bodyId, ref b2ShapeDef shapeDef, ref Polygon polyhon) => 
        CreatePolygonShape(bodyId,  (b2ShapeDef*)Unsafe.AsPointer(ref shapeDef), (Polygon*)Unsafe.AsPointer(ref polyhon));

    public static unsafe void Shape_SetCircle(b2ShapeId id, ref Circle circle) =>
        Shape_SetCircle(id, (Circle*)Unsafe.AsPointer(ref circle));
    public static unsafe void Shape_SetPolygon(b2ShapeId id, ref Polygon polygon) =>
        Shape_SetPolygon(id, (Polygon*)Unsafe.AsPointer(ref polygon));
    public static unsafe void Shape_SetSegment(b2ShapeId id, ref Segment segment) =>
        Shape_SetSegment(id, (Segment*)Unsafe.AsPointer(ref segment));
    public static unsafe void Shape_SetCapsule(b2ShapeId id, ref Capsule capsule) =>
        Shape_SetCapsule(id, (Capsule*)Unsafe.AsPointer(ref capsule));
    
    public static unsafe int Shape_GetContactData(b2ShapeId shapeId, ref b2ContactData[] contactData) {
        return Shape_GetContactData(shapeId, (b2ContactData*)Unsafe.AsPointer(ref contactData), contactData.Length);
    }
    
    static B2() {
        unsafe {
            SetAssertFcn(Marshal.GetFunctionPointerForDelegate(B2AssertFcn));
        }
    }

    private static unsafe int B2AssertFcn(sbyte* condition, sbyte* name, int number) {
        var conditionStr = Marshal.PtrToStringUTF8((IntPtr) condition);
        var nameStr = Marshal.PtrToStringUTF8((IntPtr) name);
        throw new Box2DAssertionException($"{conditionStr} at {nameStr}:{number}");
    }

    //this stuff is included in math_function.h that we dont generate bindings for
    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2SetLengthUnitsPerMeter", ExactSpelling = true)]
    public static extern void SetLengthUnitsPerMeter(float lengthUnits);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2GetLengthUnitsPerMeter", ExactSpelling = true)]
    public static extern float GetLengthUnitsPerMeter();
}