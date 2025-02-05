using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Box2D.Interop;

namespace Box2D;

public unsafe class World : B2Object<b2WorldId> {
    public World(WorldDef def) {
        fixed(b2WorldDef* ptr = &def._def)
            _id = B2.CreateWorld(ptr);
        _worldIdCache.Add(_id, this);
    }

    public World(b2WorldId id) : base(id) { }

    public World() : this(new WorldDef()) { }

    private static readonly Dictionary<b2WorldId, World> _worldIdCache = new();
    
    internal List<Body> BodyCache = [];
    
    public static unsafe implicit operator World(b2WorldId o) {
        if (_worldIdCache.TryGetValue(o, out var world)) return world;
        return _worldIdCache[o] = new(o);
    }

    public override void Dispose(bool disposing) {
        if (!disposing) return;
        foreach (var body in BodyCache) {
            body.Dispose(false);
        }
        BodyCache = null!;
        B2.DestroyWorld(_id);
        _worldIdCache.Remove(this);
    }

    public override bool IsValid => B2.World_IsValid(_id);

    public virtual void Step(float timeStep, int subStepCount) =>
        B2.World_Step(_id, timeStep, subStepCount);

    public void Draw(IDebugDraw debugDraw) {
        using var draw = new ManagedDebugDraw(debugDraw);
        B2.World_Draw(_id, (b2DebugDraw*)Unsafe.AsPointer(ref draw.@interface));
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

    private abstract class OverlapResultContext {
        public abstract bool RunFunc(Shape shape);
    }
    private class OverlapResultContext<T>(OverlapResultFcn<T> func, T? obj) : OverlapResultContext {
        public override bool RunFunc(Shape shape) =>
            func(shape, obj);
    }
    
    public delegate bool OverlapResultFcn<in T>(Shape shape, T? context);
    
    private static b2OverlapResultFcn _overlapResultFcn = (shapeId, context) =>
        new Pin<OverlapResultContext>(context).Target.RunFunc(shapeId);

    public void OverlapAABB<T>(AABB aabb, QueryFilter filter, OverlapResultFcn<T> fcn, T? context) {
        var ctx = new OverlapResultContext<T>(fcn, context);
        using var pin = ctx.Pin();
        B2.World_OverlapAABB(_id, aabb, filter, _overlapResultFcn, (void*)pin.Pointer);
    }

    public void OverlapCircle<T>(ref Circle circle, Transform transform, QueryFilter filter, OverlapResultFcn<T> fcn, T context) {
        var ctx = new OverlapResultContext<T>(fcn, context);
        using var pin = ctx.Pin();
        B2.World_OverlapCircle(_id, ref circle, transform, filter, _overlapResultFcn, (void*)pin.Pointer);
    }
    
    public void OverlapCapsule<T>(ref Capsule capsule, Transform transform, QueryFilter filter, OverlapResultFcn<T> fcn, ref T context) {
        var ctx = new OverlapResultContext<T>(fcn, context);
        using var pin = ctx.Pin();
        B2.World_OverlapCapsule(_id, ref capsule, transform, filter, _overlapResultFcn, (void*)pin.Pointer);
    }
    
    public void OverlapPolygon<T>(ref Polygon polygon, Transform transform, QueryFilter filter, OverlapResultFcn<T> fcn, ref T context){
        var ctx = new OverlapResultContext<T>(fcn, context);
        using var pin = ctx.Pin();
        B2.World_OverlapPolygon(_id, ref polygon, transform, filter, _overlapResultFcn, (void*)pin.Pointer);
    }
    
    private abstract class CastResultContext {
        public abstract float RunFunc(Shape shape, Vector2 point, Vector2 normal, float fraction);
    }
    private class CastResultContext<T>(CastResultFcn<T> func, T? obj) : CastResultContext {
        public override float RunFunc(Shape shape, Vector2 point, Vector2 normal, float fraction) =>
            func(shape, point, normal, fraction, obj);
    }
    
    public delegate float CastResultFcn<in T>(Shape shape, Vector2 point, Vector2 normal, float fraction, T? context);

    private static b2CastResultFcn _castResultFcn = (shapeId, point, normal, fraction, context) =>
        new Pin<CastResultContext>(context).Target.RunFunc(shapeId, point, normal, fraction);
    
    public void CastRay<T>(Vector2 origin, Vector2 translation, QueryFilter filter, CastResultFcn<T> fcn, T? context) {
        var ctx = new CastResultContext<T>(fcn, context);
        using var pin = ctx.Pin();
        B2.World_CastRay(_id, origin, translation, filter, _castResultFcn, (void*)pin.Pointer);
    }

    public void CastRay(Vector2 origin, Vector2 translation, QueryFilter filter) =>
        B2.World_CastRayClosest(_id, origin, translation, filter);

    public void CastCircle<T>(ref Circle circle, Transform originTransform, Vector2 translation, QueryFilter filter,
        CastResultFcn<T> fcn, ref T context) {
        var ctx = new CastResultContext<T>(fcn, context);
        using var pin = ctx.Pin();
        B2.World_CastCircle(_id, ref circle, originTransform, translation, filter, _castResultFcn, (void*)pin.Pointer);
    }

    public void CastCapsule<T>(ref Capsule capsule, Transform originTransform, Vector2 translation, QueryFilter filter,
        CastResultFcn<T> fcn, T? context) {
        var ctx = new CastResultContext<T>(fcn, context);
        using var pin = ctx.Pin();
        B2.World_CastCapsule(_id, ref capsule, originTransform, translation, filter, _castResultFcn, (void*)pin.Pointer);
    }

    public void CastPolygon<T>(ref Polygon polygon, Transform originTransform, Vector2 translation, QueryFilter filter,
        CastResultFcn<T> fcn, T? context) {
        var ctx = new CastResultContext<T>(fcn, context);
        using var pin = ctx.Pin();
        B2.World_CastPolygon(_id, ref polygon, originTransform, translation, filter, _castResultFcn, (void*)pin.Pointer);
    }

    private abstract class CustomFilterContext {
        public abstract bool RunFunc(Shape shapeA, Shape shapeB);
    }
    private class CustomFilterContext<T>(CustomFilterFcn<T> func, T? obj) :CustomFilterContext {
        public override bool RunFunc(Shape shapeA, Shape shapeB) =>
            func(shapeA, shapeB, obj);
    }
    
    public delegate bool CustomFilterFcn<in T>(Shape shapeA, Shape shapeB, T? context);
    
    private static b2CustomFilterFcn _customFilter = (shapeA, shapeB, context) =>
        new Pin<CustomFilterContext>(context).Target.RunFunc(shapeA, shapeB);

    private Pin<CustomFilterContext>? _customFilterContext;

    public void SetCustomFilterCallback<T>(CustomFilterFcn<T> fcn, T? context) {
        _customFilterContext?.Dispose();
        _customFilterContext = ((CustomFilterContext)new CustomFilterContext<T>(fcn, context)).Pin();
        B2.World_SetCustomFilterCallback(_id, _customFilter, (void*)_customFilterContext.Pointer);
    }

    public void RemoveCustomFilterCallback() {
        _customFilterContext?.Dispose();
        _customFilterContext = null;
        B2.World_SetCustomFilterCallback(_id, 0, null);
    }

    private abstract class PreSolveContext {
        public abstract bool RunFunc(Shape shapeA, Shape shapeB, ref b2Manifold manifold);
    }
    private class PreSolveContext<T>(PreSolveFcn<T> func, T? obj) : PreSolveContext {
        public override bool RunFunc(Shape shapeA, Shape shapeB, ref b2Manifold manifold) =>
            func(shapeA, shapeB, ref manifold, obj);
    }
    public delegate bool PreSolveFcn<in T>(Shape shapeA, Shape shapeB, ref b2Manifold manifold, T? context);

    private Pin<PreSolveContext>? _preSolveContext;
    
    private static b2PreSolveFcn _preSolve = (shapeA, shapeB, manifold, context) =>
        new Pin<PreSolveContext>(context).Target.RunFunc(shapeA, shapeB, ref Unsafe.AsRef<b2Manifold>(manifold));

    public void SetPreSolveCallback<T>(PreSolveFcn<T> callback, ref T context) {
        _preSolveContext?.Dispose();
        _preSolveContext = ((PreSolveContext)new PreSolveContext<T>(callback, context)).Pin();
        B2.World_SetPreSolveCallback(_id, _preSolve, (void*)_preSolveContext.Pointer);
    }

    public void RemovePreSolveCallback() {
        _preSolveContext?.Dispose();
        _preSolveContext = null;
        B2.World_SetPreSolveCallback(_id, 0, null);
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