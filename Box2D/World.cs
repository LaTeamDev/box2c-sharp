using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Box2D.Interop;

namespace Box2D; 

public class World : IDisposable {
    private b2WorldId _id;

    public unsafe World(WorldDef def) {
        using var worldDef = def._b2WorldDef.GcPin();
        _id = B2.CreateWorld(worldDef.Pointer);
    }

    public World() : this(new WorldDef()) {}
    
    public void Dispose() {
        B2.DestroyWorld(_id);
    }

    public bool IsValid => B2.World_IsValid(_id);

    public void Step(float timeStep, int subStepCount) =>
        B2.World_Step(_id, timeStep, subStepCount);

    public unsafe void Draw(DebugDraw debugDraw) {
        using var pin = debugDraw._b2DebugDraw.GcPin();
        B2.World_Draw(_id, pin.Pointer);
    }

    public unsafe Body CreateBody(BodyDef bodyDef) {
        using var pin = bodyDef._b2BodyDef.GcPin();
        return new Body(B2.CreateBody(_id, pin.Pointer));
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

    //Function past this is just a straight binding with little to no changes to tie with
    //oop stuff i made
    //TODO: FIXME
    
    public b2BodyEvents GetBodyEvents() =>
        B2.World_GetBodyEvents(_id);

    public b2SensorEvents GetSensorEvents() =>
        B2.World_GetSensorEvents(_id);

    public b2ContactEvents GetContactEvents() =>
        B2.World_GetContactEvents(_id);

    public unsafe void OverlapAABB(AABB aabb, b2QueryFilter filter, b2OverlapResultFcn fcn, object? context = null) =>
        B2.World_OverlapAABB(_id, aabb, filter, Marshal.GetFunctionPointerForDelegate(fcn), &context);
    
    public unsafe void OverlapCircle(ref Circle circle, Transform transform, b2QueryFilter filter, b2OverlapResultFcn fcn, object? context = null) =>
        B2.World_OverlapCircle(_id, ref circle, transform, filter, fcn, &context);
    
    public unsafe void OverlapCapsule(ref Capsule capsule, Transform transform, b2QueryFilter filter, b2OverlapResultFcn fcn, object? context = null) =>
        B2.World_OverlapCapsule(_id, ref capsule, transform, filter, fcn, &context);
    
    public unsafe void OverlapPolygon(ref Polygon polygon, Transform transform, b2QueryFilter filter, b2OverlapResultFcn fcn, object? context = null) =>
        B2.World_OverlapPolygon(_id, ref polygon, transform, filter, fcn, &context);

    public unsafe void CastRay(Vector2 origin, Vector2 translation, b2QueryFilter filter, b2CastResultFcn fcn,
        object? context) =>
        B2.World_CastRay(_id, origin, translation, filter, fcn, &context);

    public unsafe void CastRay(Vector2 origin, Vector2 translation, b2QueryFilter filter) =>
        B2.World_CastRayClosest(_id, origin, translation, filter);
    
    public unsafe void CastCircle(ref Circle circle, Transform originTransform, Vector2 translation, b2QueryFilter filter, b2CastResultFcn fcn, object? context) =>
        B2.World_CastCircle(_id, ref circle, originTransform, translation, filter, fcn, &context);
    
    public unsafe void CastCapsule(ref Capsule capsule, Transform originTransform, Vector2 translation, b2QueryFilter filter, b2CastResultFcn fcn, object? context) =>
        B2.World_CastCapsule(_id, ref capsule, originTransform, translation, filter, fcn, &context);
    
    public unsafe void CastPolygon(ref Polygon polygon, Transform originTransform, Vector2 translation, b2QueryFilter filter, b2CastResultFcn fcn, object? context) =>
        B2.World_CastPolygon(_id, ref polygon, originTransform, translation, filter, fcn, &context);
    
    public unsafe void SetCustomFilterCallback(b2CustomFilterFcn callback, object? context) =>
        B2.World_SetCustomFilterCallback(_id, Marshal.GetFunctionPointerForDelegate(callback), &context);
    
    public unsafe void SetPreSolveCallback(b2CustomFilterFcn callback, object? context) =>
        B2.World_SetPreSolveCallback(_id, Marshal.GetFunctionPointerForDelegate(callback), &context);

    public b2Profile Profile => B2.World_GetProfile(_id);

    public b2Counters Counters => B2.World_GetCounters(_id);

    public void DumpMemoryStats() =>
        B2.World_DumpMemoryStats(_id);
}