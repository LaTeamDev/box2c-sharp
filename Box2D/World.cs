using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Box2D.Interop;

namespace Box2D;

public unsafe class World : IDisposable {
    private b2WorldId _id;

    public World(WorldDef def) {
        fixed(b2WorldDef* ptr = &def._def)
            _id = B2.CreateWorld(ptr);
    }

    public World() : this(new WorldDef()) { }

    public void Dispose() {
        B2.DestroyWorld(_id);
    }

    public bool IsValid => B2.World_IsValid(_id);

    public virtual void Step(float timeStep, int subStepCount) =>
        B2.World_Step(_id, timeStep, subStepCount);

    public void Draw(IDebugDraw debugDraw) {
        using var draw = new ManagedDebugDraw(debugDraw);
        B2.World_Draw(_id, (b2DebugDraw*)Unsafe.AsPointer(ref draw.@interface));
    }

    public Body CreateBody(BodyDef bodyDef) {
        fixed (b2BodyDef* ptr = &bodyDef._def) {
            var body = new Body(B2.CreateBody(_id, ptr));
            body.UserData = bodyDef.UserData;
            return body;
        }
    }

    public static float LengthUnitsPerMeter {
        get => B2.GetLengthUnitsPerMeter();
        set => B2.SetLengthUnitsPerMeter(value);
    }

    public bool Sleeping {
        set => B2.World_EnableSleeping(_id, value);
    }

    public bool Continuous {
        set => B2.World_EnableContinuous(_id, value);
    }

    public float RestitutionThreshold {
        set => B2.World_SetRestitutionThreshold(_id, value);
    }

    public float HitEventThreshold {
        set => B2.World_SetHitEventThreshold(_id, value);
    }

    public Vector2 Gravity {
        get => B2.World_GetGravity(_id);
        set => B2.World_SetGravity(_id, value);
    }

    public void Explode(Vector2 position, float radius, float impulse) =>
        B2.World_Explode(_id, position, radius, impulse);

    public void SetContactTuning(float hertz, float dampingRatio, float pushVelocity) =>
        B2.World_SetContactTuning(_id, hertz, dampingRatio, pushVelocity);

    public bool WarmStarting {
        set => B2.World_EnableWarmStarting(_id, value);
    }
    
    public BodyEvents GetBodyEvents() => B2.World_GetBodyEvents(_id);

    public SensorEvents GetSensorEvents() => B2.World_GetSensorEvents(_id);

    public ContactEvents GetContactEvents() => B2.World_GetContactEvents(_id);

    public delegate bool OverlapResultFcn<T>(Shape shape, ref T context);

    private static b2OverlapResultFcn _overlapResultBuilder<T>(
        OverlapResultFcn<T> fcn) => (shapeId, context) => fcn(shapeId, ref Unsafe.AsRef<T>(context));

    public void OverlapAABB<T>(AABB aabb, QueryFilter filter, OverlapResultFcn<T> fcn, ref T context) =>
        B2.World_OverlapAABB(_id, aabb, filter, _overlapResultBuilder(fcn), Unsafe.AsPointer(ref context));

    
    public void OverlapCircle<T>(ref Circle circle, Transform transform, QueryFilter filter, OverlapResultFcn<T> fcn, ref T context) =>
        B2.World_OverlapCircle(_id, ref circle, transform, filter, _overlapResultBuilder(fcn), Unsafe.AsPointer(ref context));
    
    public void OverlapCapsule<T>(ref Capsule capsule, Transform transform, QueryFilter filter, OverlapResultFcn<T> fcn, ref T context) =>
        B2.World_OverlapCapsule(_id, ref capsule, transform, filter, _overlapResultBuilder(fcn), Unsafe.AsPointer(ref context));
    
    public void OverlapPolygon<T>(ref Polygon polygon, Transform transform, QueryFilter filter, OverlapResultFcn<T> fcn, ref T context) =>
        B2.World_OverlapPolygon(_id, ref polygon, transform, filter, _overlapResultBuilder(fcn), Unsafe.AsPointer(ref context));

    public delegate float CastResultFcn<T>(Shape shape, Vector2 point, Vector2 normal, float fraction, ref T context);
    private static b2CastResultFcn _castResultBuilder<T>(
        CastResultFcn<T> fcn) => (shapeId, point, normal, fraction, context) => fcn(new Shape(shapeId), point, normal, fraction, ref Unsafe.AsRef<T>(context));
    
    public void CastRay<T>(Vector2 origin, Vector2 translation, QueryFilter filter, CastResultFcn<T> fcn,
        ref T context) =>
        B2.World_CastRay(_id, origin, translation, filter, _castResultBuilder(fcn), Unsafe.AsPointer(ref context));

    public void CastRay(Vector2 origin, Vector2 translation, QueryFilter filter) =>
        B2.World_CastRayClosest(_id, origin, translation, filter);
    
    public void CastCircle<T>(ref Circle circle, Transform originTransform, Vector2 translation, QueryFilter filter, CastResultFcn<T> fcn, ref T context) =>
        B2.World_CastCircle(_id, ref circle, originTransform, translation, filter, _castResultBuilder(fcn), Unsafe.AsPointer(ref context));
    
    public void CastCapsule<T>(ref Capsule capsule, Transform originTransform, Vector2 translation, QueryFilter filter, CastResultFcn<T> fcn, ref T context) =>
        B2.World_CastCapsule(_id, ref capsule, originTransform, translation, filter, _castResultBuilder(fcn), Unsafe.AsPointer(ref context));
    
    public void CastPolygon<T>(ref Polygon polygon, Transform originTransform, Vector2 translation, QueryFilter filter, CastResultFcn<T> fcn, ref T context) =>
        B2.World_CastPolygon(_id, ref polygon, originTransform, translation, filter, _castResultBuilder(fcn), Unsafe.AsPointer(ref context));

    public delegate bool CustomFilterFcn<T>(Shape shapeA, Shape shapeB, ref T context);
    private static b2CustomFilterFcn _customFilterBuilder<T>(
        CustomFilterFcn<T> fcn) => (shapeIdA, shapeIdB, context) => fcn(new Shape(shapeIdA), new Shape(shapeIdB), ref Unsafe.AsRef<T>(context));

    private b2CustomFilterFcn _customFilterCallback;

    public void SetCustomFilterCallback<T>(CustomFilterFcn<T> callback, ref T context) {
        _customFilterCallback = _customFilterBuilder(callback);
        B2.World_SetCustomFilterCallback(_id, _customFilterCallback, Unsafe.AsPointer(ref context));
    }

    // im not sure about b2Manifold and whatever magic stuff behind Unsafe.AsRef
    public delegate bool PreSolveFcn<T>(Shape shapeA, Shape shapeB, ref b2Manifold manifold, ref T context);
    private static b2PreSolveFcn _preSolveBuilder<T>(
        PreSolveFcn<T> fcn) => (shapeIdA, shapeIdB, manifold, context) => fcn(new Shape(shapeIdA), new Shape(shapeIdB), ref Unsafe.AsRef<b2Manifold>(manifold), ref Unsafe.AsRef<T>(context));

    private b2PreSolveFcn _preSolveCallback;

    public void SetPreSolveCallback<T>(PreSolveFcn<T> callback, ref T context) {
        _preSolveCallback = _preSolveBuilder(callback);
        B2.World_SetPreSolveCallback(_id, _preSolveCallback, Unsafe.AsPointer(ref context));
    }

    public b2Profile Profile => B2.World_GetProfile(_id);

    public b2Counters Counters => B2.World_GetCounters(_id);

    public void DumpMemoryStats() =>
        B2.World_DumpMemoryStats(_id);

    public DistanceJoint CreateDistanceJoint(DistanceJointDef def) => new(B2.CreateDistanceJoint(_id, ref def._def));
    public MotorJoint CreateMotorJoint(MotorJointDef def) => new(B2.CreateMotorJoint(_id, ref def._def));
    public MouseJoint CreateMouseJoint(MouseJointDef def) => new(B2.CreateMouseJoint(_id, ref def._def));
    public PrismaticJoint CreatePrismaticJoint(PrismaticJointDef def) => new(B2.CreatePrismaticJoint(_id, ref def._def));
    public RevoluteJoint CreateRevoluteJoint(RevoluteJointDef def) => new(B2.CreateRevoluteJoint(_id, ref def._def));
    public WeldJoint CreateWeldJoint(WeldJointDef def) => new(B2.CreateWeldJoint(_id, ref def._def));
    public WheelJoint CreateWheelJoint(WheelJointDef def) => new(B2.CreateWheelJoint(_id, ref def._def));
}