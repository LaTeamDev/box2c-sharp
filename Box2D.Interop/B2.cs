using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Box2D.Interop;

public static unsafe partial class B2
{
    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2SetAllocator", ExactSpelling = true)]
    public static extern void SetAllocator([NativeTypeName("b2AllocFcn *")] IntPtr allocFcn, [NativeTypeName("b2FreeFcn *")] IntPtr freeFcn);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2GetByteCount", ExactSpelling = true)]
    public static extern int GetByteCount();

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2SetAssertFcn", ExactSpelling = true)]
    public static extern void SetAssertFcn([NativeTypeName("b2AssertFcn *")] IntPtr assertFcn);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2GetVersion", ExactSpelling = true)]
    public static extern b2Version GetVersion();

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateTimer", ExactSpelling = true)]
    public static extern b2Timer CreateTimer();

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2GetTicks", ExactSpelling = true)]
    [return: NativeTypeName("int64_t")]
    public static extern IntPtr GetTicks(b2Timer* timer);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2GetMilliseconds", ExactSpelling = true)]
    public static extern float GetMilliseconds([NativeTypeName("const b2Timer *")] b2Timer* timer);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2GetMillisecondsAndReset", ExactSpelling = true)]
    public static extern float GetMillisecondsAndReset(b2Timer* timer);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2SleepMilliseconds", ExactSpelling = true)]
    public static extern void SleepMilliseconds(int milliseconds);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Yield", ExactSpelling = true)]
    public static extern void Yield();

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateWorld", ExactSpelling = true)]
    public static extern b2WorldId CreateWorld([NativeTypeName("const b2WorldDef *")] b2WorldDef* def);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DestroyWorld", ExactSpelling = true)]
    public static extern void DestroyWorld(b2WorldId worldId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_IsValid", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool World_IsValid(b2WorldId id);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_Step", ExactSpelling = true)]
    public static extern void World_Step(b2WorldId worldId, float timeStep, int subStepCount);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_Draw", ExactSpelling = true)]
    public static extern void World_Draw(b2WorldId worldId, b2DebugDraw* draw);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetBodyEvents", ExactSpelling = true)]
    public static extern b2BodyEvents World_GetBodyEvents(b2WorldId worldId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetSensorEvents", ExactSpelling = true)]
    public static extern b2SensorEvents World_GetSensorEvents(b2WorldId worldId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetContactEvents", ExactSpelling = true)]
    public static extern b2ContactEvents World_GetContactEvents(b2WorldId worldId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_OverlapAABB", ExactSpelling = true)]
    public static extern void World_OverlapAABB(b2WorldId worldId, b2AABB aabb, b2QueryFilter filter, [NativeTypeName("b2OverlapResultFcn *")] IntPtr fcn, void* context);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_OverlapCircle", ExactSpelling = true)]
    public static extern void World_OverlapCircle(b2WorldId worldId, [NativeTypeName("const b2Circle *")] b2Circle* circle, b2Transform transform, b2QueryFilter filter, [NativeTypeName("b2OverlapResultFcn *")] IntPtr fcn, void* context);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_OverlapCapsule", ExactSpelling = true)]
    public static extern void World_OverlapCapsule(b2WorldId worldId, [NativeTypeName("const b2Capsule *")] b2Capsule* capsule, b2Transform transform, b2QueryFilter filter, [NativeTypeName("b2OverlapResultFcn *")] IntPtr fcn, void* context);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_OverlapPolygon", ExactSpelling = true)]
    public static extern void World_OverlapPolygon(b2WorldId worldId, [NativeTypeName("const b2Polygon *")] b2Polygon* polygon, b2Transform transform, b2QueryFilter filter, [NativeTypeName("b2OverlapResultFcn *")] IntPtr fcn, void* context);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_CastRay", ExactSpelling = true)]
    public static extern void World_CastRay(b2WorldId worldId, b2Vec2 origin, b2Vec2 translation, b2QueryFilter filter, [NativeTypeName("b2CastResultFcn *")] IntPtr fcn, void* context);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_CastRayClosest", ExactSpelling = true)]
    public static extern b2RayResult World_CastRayClosest(b2WorldId worldId, b2Vec2 origin, b2Vec2 translation, b2QueryFilter filter);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_CastCircle", ExactSpelling = true)]
    public static extern void World_CastCircle(b2WorldId worldId, [NativeTypeName("const b2Circle *")] b2Circle* circle, b2Transform originTransform, b2Vec2 translation, b2QueryFilter filter, [NativeTypeName("b2CastResultFcn *")] IntPtr fcn, void* context);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_CastCapsule", ExactSpelling = true)]
    public static extern void World_CastCapsule(b2WorldId worldId, [NativeTypeName("const b2Capsule *")] b2Capsule* capsule, b2Transform originTransform, b2Vec2 translation, b2QueryFilter filter, [NativeTypeName("b2CastResultFcn *")] IntPtr fcn, void* context);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_CastPolygon", ExactSpelling = true)]
    public static extern void World_CastPolygon(b2WorldId worldId, [NativeTypeName("const b2Polygon *")] b2Polygon* polygon, b2Transform originTransform, b2Vec2 translation, b2QueryFilter filter, [NativeTypeName("b2CastResultFcn *")] IntPtr fcn, void* context);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_EnableSleeping", ExactSpelling = true)]
    public static extern void World_EnableSleeping(b2WorldId worldId, [NativeTypeName("_Bool")] bool flag);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_EnableContinuous", ExactSpelling = true)]
    public static extern void World_EnableContinuous(b2WorldId worldId, [NativeTypeName("_Bool")] bool flag);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetRestitutionThreshold", ExactSpelling = true)]
    public static extern void World_SetRestitutionThreshold(b2WorldId worldId, float value);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetHitEventThreshold", ExactSpelling = true)]
    public static extern void World_SetHitEventThreshold(b2WorldId worldId, float value);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetCustomFilterCallback", ExactSpelling = true)]
    public static extern void World_SetCustomFilterCallback(b2WorldId worldId, [NativeTypeName("b2CustomFilterFcn *")] IntPtr fcn, void* context);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetPreSolveCallback", ExactSpelling = true)]
    public static extern void World_SetPreSolveCallback(b2WorldId worldId, [NativeTypeName("b2PreSolveFcn *")] IntPtr fcn, void* context);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetGravity", ExactSpelling = true)]
    public static extern void World_SetGravity(b2WorldId worldId, b2Vec2 gravity);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetGravity", ExactSpelling = true)]
    public static extern b2Vec2 World_GetGravity(b2WorldId worldId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_Explode", ExactSpelling = true)]
    public static extern void World_Explode(b2WorldId worldId, b2Vec2 position, float radius, float impulse);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_SetContactTuning", ExactSpelling = true)]
    public static extern void World_SetContactTuning(b2WorldId worldId, float hertz, float dampingRatio, float pushVelocity);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_EnableWarmStarting", ExactSpelling = true)]
    public static extern void World_EnableWarmStarting(b2WorldId worldId, [NativeTypeName("_Bool")] bool flag);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetProfile", ExactSpelling = true)]
    public static extern b2Profile World_GetProfile(b2WorldId worldId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_GetCounters", ExactSpelling = true)]
    public static extern b2Counters World_GetCounters(b2WorldId worldId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2World_DumpMemoryStats", ExactSpelling = true)]
    public static extern void World_DumpMemoryStats(b2WorldId worldId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateBody", ExactSpelling = true)]
    public static extern b2BodyId CreateBody(b2WorldId worldId, [NativeTypeName("const b2BodyDef *")] b2BodyDef* def);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DestroyBody", ExactSpelling = true)]
    public static extern void DestroyBody(b2BodyId bodyId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_IsValid", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool Body_IsValid(b2BodyId id);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetType", ExactSpelling = true)]
    public static extern b2BodyType Body_GetType(b2BodyId bodyId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_SetType", ExactSpelling = true)]
    public static extern void Body_SetType(b2BodyId bodyId, b2BodyType type);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_SetUserData", ExactSpelling = true)]
    public static extern void Body_SetUserData(b2BodyId bodyId, void* userData);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetUserData", ExactSpelling = true)]
    public static extern void* Body_GetUserData(b2BodyId bodyId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetPosition", ExactSpelling = true)]
    public static extern b2Vec2 Body_GetPosition(b2BodyId bodyId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetRotation", ExactSpelling = true)]
    public static extern b2Rot Body_GetRotation(b2BodyId bodyId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetTransform", ExactSpelling = true)]
    public static extern b2Transform Body_GetTransform(b2BodyId bodyId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_SetTransform", ExactSpelling = true)]
    public static extern void Body_SetTransform(b2BodyId bodyId, b2Vec2 position, b2Rot rotation);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetLocalPoint", ExactSpelling = true)]
    public static extern b2Vec2 Body_GetLocalPoint(b2BodyId bodyId, b2Vec2 worldPoint);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetWorldPoint", ExactSpelling = true)]
    public static extern b2Vec2 Body_GetWorldPoint(b2BodyId bodyId, b2Vec2 localPoint);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetLocalVector", ExactSpelling = true)]
    public static extern b2Vec2 Body_GetLocalVector(b2BodyId bodyId, b2Vec2 worldVector);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetWorldVector", ExactSpelling = true)]
    public static extern b2Vec2 Body_GetWorldVector(b2BodyId bodyId, b2Vec2 localVector);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetLinearVelocity", ExactSpelling = true)]
    public static extern b2Vec2 Body_GetLinearVelocity(b2BodyId bodyId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetAngularVelocity", ExactSpelling = true)]
    public static extern float Body_GetAngularVelocity(b2BodyId bodyId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_SetLinearVelocity", ExactSpelling = true)]
    public static extern void Body_SetLinearVelocity(b2BodyId bodyId, b2Vec2 linearVelocity);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_SetAngularVelocity", ExactSpelling = true)]
    public static extern void Body_SetAngularVelocity(b2BodyId bodyId, float angularVelocity);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_ApplyForce", ExactSpelling = true)]
    public static extern void Body_ApplyForce(b2BodyId bodyId, b2Vec2 force, b2Vec2 point, [NativeTypeName("_Bool")] bool wake);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_ApplyForceToCenter", ExactSpelling = true)]
    public static extern void Body_ApplyForceToCenter(b2BodyId bodyId, b2Vec2 force, [NativeTypeName("_Bool")] bool wake);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_ApplyTorque", ExactSpelling = true)]
    public static extern void Body_ApplyTorque(b2BodyId bodyId, float torque, [NativeTypeName("_Bool")] bool wake);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_ApplyLinearImpulse", ExactSpelling = true)]
    public static extern void Body_ApplyLinearImpulse(b2BodyId bodyId, b2Vec2 impulse, b2Vec2 point, [NativeTypeName("_Bool")] bool wake);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_ApplyLinearImpulseToCenter", ExactSpelling = true)]
    public static extern void Body_ApplyLinearImpulseToCenter(b2BodyId bodyId, b2Vec2 impulse, [NativeTypeName("_Bool")] bool wake);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_ApplyAngularImpulse", ExactSpelling = true)]
    public static extern void Body_ApplyAngularImpulse(b2BodyId bodyId, float impulse, [NativeTypeName("_Bool")] bool wake);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetMass", ExactSpelling = true)]
    public static extern float Body_GetMass(b2BodyId bodyId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetInertiaTensor", ExactSpelling = true)]
    public static extern float Body_GetInertiaTensor(b2BodyId bodyId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetLocalCenterOfMass", ExactSpelling = true)]
    public static extern b2Vec2 Body_GetLocalCenterOfMass(b2BodyId bodyId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetWorldCenterOfMass", ExactSpelling = true)]
    public static extern b2Vec2 Body_GetWorldCenterOfMass(b2BodyId bodyId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_SetMassData", ExactSpelling = true)]
    public static extern void Body_SetMassData(b2BodyId bodyId, b2MassData massData);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetMassData", ExactSpelling = true)]
    public static extern b2MassData Body_GetMassData(b2BodyId bodyId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_ApplyMassFromShapes", ExactSpelling = true)]
    public static extern void Body_ApplyMassFromShapes(b2BodyId bodyId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_SetAutomaticMass", ExactSpelling = true)]
    public static extern void Body_SetAutomaticMass(b2BodyId bodyId, [NativeTypeName("_Bool")] bool automaticMass);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetAutomaticMass", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool Body_GetAutomaticMass(b2BodyId bodyId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_SetLinearDamping", ExactSpelling = true)]
    public static extern void Body_SetLinearDamping(b2BodyId bodyId, float linearDamping);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetLinearDamping", ExactSpelling = true)]
    public static extern float Body_GetLinearDamping(b2BodyId bodyId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_SetAngularDamping", ExactSpelling = true)]
    public static extern void Body_SetAngularDamping(b2BodyId bodyId, float angularDamping);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetAngularDamping", ExactSpelling = true)]
    public static extern float Body_GetAngularDamping(b2BodyId bodyId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_SetGravityScale", ExactSpelling = true)]
    public static extern void Body_SetGravityScale(b2BodyId bodyId, float gravityScale);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetGravityScale", ExactSpelling = true)]
    public static extern float Body_GetGravityScale(b2BodyId bodyId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_IsAwake", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool Body_IsAwake(b2BodyId bodyId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_SetAwake", ExactSpelling = true)]
    public static extern void Body_SetAwake(b2BodyId bodyId, [NativeTypeName("_Bool")] bool awake);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_EnableSleep", ExactSpelling = true)]
    public static extern void Body_EnableSleep(b2BodyId bodyId, [NativeTypeName("_Bool")] bool enableSleep);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_IsSleepEnabled", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool Body_IsSleepEnabled(b2BodyId bodyId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_SetSleepThreshold", ExactSpelling = true)]
    public static extern void Body_SetSleepThreshold(b2BodyId bodyId, float sleepVelocity);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetSleepThreshold", ExactSpelling = true)]
    public static extern float Body_GetSleepThreshold(b2BodyId bodyId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_IsEnabled", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool Body_IsEnabled(b2BodyId bodyId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_Disable", ExactSpelling = true)]
    public static extern void Body_Disable(b2BodyId bodyId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_Enable", ExactSpelling = true)]
    public static extern void Body_Enable(b2BodyId bodyId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_SetFixedRotation", ExactSpelling = true)]
    public static extern void Body_SetFixedRotation(b2BodyId bodyId, [NativeTypeName("_Bool")] bool flag);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_IsFixedRotation", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool Body_IsFixedRotation(b2BodyId bodyId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_SetBullet", ExactSpelling = true)]
    public static extern void Body_SetBullet(b2BodyId bodyId, [NativeTypeName("_Bool")] bool flag);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_IsBullet", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool Body_IsBullet(b2BodyId bodyId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_EnableHitEvents", ExactSpelling = true)]
    public static extern void Body_EnableHitEvents(b2BodyId bodyId, [NativeTypeName("_Bool")] bool enableHitEvents);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetShapeCount", ExactSpelling = true)]
    public static extern int Body_GetShapeCount(b2BodyId bodyId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetShapes", ExactSpelling = true)]
    public static extern int Body_GetShapes(b2BodyId bodyId, b2ShapeId* shapeArray, int capacity);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetJointCount", ExactSpelling = true)]
    public static extern int Body_GetJointCount(b2BodyId bodyId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetJoints", ExactSpelling = true)]
    public static extern int Body_GetJoints(b2BodyId bodyId, b2JointId* jointArray, int capacity);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetContactCapacity", ExactSpelling = true)]
    public static extern int Body_GetContactCapacity(b2BodyId bodyId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_GetContactData", ExactSpelling = true)]
    public static extern int Body_GetContactData(b2BodyId bodyId, b2ContactData* contactData, int capacity);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Body_ComputeAABB", ExactSpelling = true)]
    public static extern b2AABB Body_ComputeAABB(b2BodyId bodyId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateCircleShape", ExactSpelling = true)]
    public static extern b2ShapeId CreateCircleShape(b2BodyId bodyId, [NativeTypeName("const b2ShapeDef *")] b2ShapeDef* def, [NativeTypeName("const b2Circle *")] b2Circle* circle);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateSegmentShape", ExactSpelling = true)]
    public static extern b2ShapeId CreateSegmentShape(b2BodyId bodyId, [NativeTypeName("const b2ShapeDef *")] b2ShapeDef* def, [NativeTypeName("const b2Segment *")] b2Segment* segment);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateCapsuleShape", ExactSpelling = true)]
    public static extern b2ShapeId CreateCapsuleShape(b2BodyId bodyId, [NativeTypeName("const b2ShapeDef *")] b2ShapeDef* def, [NativeTypeName("const b2Capsule *")] b2Capsule* capsule);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreatePolygonShape", ExactSpelling = true)]
    public static extern b2ShapeId CreatePolygonShape(b2BodyId bodyId, [NativeTypeName("const b2ShapeDef *")] b2ShapeDef* def, [NativeTypeName("const b2Polygon *")] b2Polygon* polygon);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DestroyShape", ExactSpelling = true)]
    public static extern void DestroyShape(b2ShapeId shapeId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_IsValid", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool Shape_IsValid(b2ShapeId id);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetType", ExactSpelling = true)]
    public static extern b2ShapeType Shape_GetType(b2ShapeId shapeId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetBody", ExactSpelling = true)]
    public static extern b2BodyId Shape_GetBody(b2ShapeId shapeId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_IsSensor", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool Shape_IsSensor(b2ShapeId shapeId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_SetUserData", ExactSpelling = true)]
    public static extern void Shape_SetUserData(b2ShapeId shapeId, void* userData);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetUserData", ExactSpelling = true)]
    public static extern void* Shape_GetUserData(b2ShapeId shapeId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_SetDensity", ExactSpelling = true)]
    public static extern void Shape_SetDensity(b2ShapeId shapeId, float density);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetDensity", ExactSpelling = true)]
    public static extern float Shape_GetDensity(b2ShapeId shapeId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_SetFriction", ExactSpelling = true)]
    public static extern void Shape_SetFriction(b2ShapeId shapeId, float friction);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetFriction", ExactSpelling = true)]
    public static extern float Shape_GetFriction(b2ShapeId shapeId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_SetRestitution", ExactSpelling = true)]
    public static extern void Shape_SetRestitution(b2ShapeId shapeId, float restitution);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetRestitution", ExactSpelling = true)]
    public static extern float Shape_GetRestitution(b2ShapeId shapeId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetFilter", ExactSpelling = true)]
    public static extern b2Filter Shape_GetFilter(b2ShapeId shapeId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_SetFilter", ExactSpelling = true)]
    public static extern void Shape_SetFilter(b2ShapeId shapeId, b2Filter filter);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_EnableSensorEvents", ExactSpelling = true)]
    public static extern void Shape_EnableSensorEvents(b2ShapeId shapeId, [NativeTypeName("_Bool")] bool flag);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_AreSensorEventsEnabled", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool Shape_AreSensorEventsEnabled(b2ShapeId shapeId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_EnableContactEvents", ExactSpelling = true)]
    public static extern void Shape_EnableContactEvents(b2ShapeId shapeId, [NativeTypeName("_Bool")] bool flag);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_AreContactEventsEnabled", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool Shape_AreContactEventsEnabled(b2ShapeId shapeId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_EnablePreSolveEvents", ExactSpelling = true)]
    public static extern void Shape_EnablePreSolveEvents(b2ShapeId shapeId, [NativeTypeName("_Bool")] bool flag);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_ArePreSolveEventsEnabled", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool Shape_ArePreSolveEventsEnabled(b2ShapeId shapeId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_EnableHitEvents", ExactSpelling = true)]
    public static extern void Shape_EnableHitEvents(b2ShapeId shapeId, [NativeTypeName("_Bool")] bool flag);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_AreHitEventsEnabled", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool Shape_AreHitEventsEnabled(b2ShapeId shapeId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_TestPoint", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool Shape_TestPoint(b2ShapeId shapeId, b2Vec2 point);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_RayCast", ExactSpelling = true)]
    public static extern b2CastOutput Shape_RayCast(b2ShapeId shapeId, b2Vec2 origin, b2Vec2 translation);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetCircle", ExactSpelling = true)]
    public static extern b2Circle Shape_GetCircle(b2ShapeId shapeId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetSegment", ExactSpelling = true)]
    public static extern b2Segment Shape_GetSegment(b2ShapeId shapeId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetSmoothSegment", ExactSpelling = true)]
    public static extern b2SmoothSegment Shape_GetSmoothSegment(b2ShapeId shapeId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetCapsule", ExactSpelling = true)]
    public static extern b2Capsule Shape_GetCapsule(b2ShapeId shapeId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetPolygon", ExactSpelling = true)]
    public static extern b2Polygon Shape_GetPolygon(b2ShapeId shapeId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_SetCircle", ExactSpelling = true)]
    public static extern void Shape_SetCircle(b2ShapeId shapeId, [NativeTypeName("const b2Circle *")] b2Circle* circle);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_SetCapsule", ExactSpelling = true)]
    public static extern void Shape_SetCapsule(b2ShapeId shapeId, [NativeTypeName("const b2Capsule *")] b2Capsule* capsule);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_SetSegment", ExactSpelling = true)]
    public static extern void Shape_SetSegment(b2ShapeId shapeId, [NativeTypeName("const b2Segment *")] b2Segment* segment);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_SetPolygon", ExactSpelling = true)]
    public static extern void Shape_SetPolygon(b2ShapeId shapeId, [NativeTypeName("const b2Polygon *")] b2Polygon* polygon);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetParentChain", ExactSpelling = true)]
    public static extern b2ChainId Shape_GetParentChain(b2ShapeId shapeId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetContactCapacity", ExactSpelling = true)]
    public static extern int Shape_GetContactCapacity(b2ShapeId shapeId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetContactData", ExactSpelling = true)]
    public static extern int Shape_GetContactData(b2ShapeId shapeId, b2ContactData* contactData, int capacity);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetAABB", ExactSpelling = true)]
    public static extern b2AABB Shape_GetAABB(b2ShapeId shapeId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Shape_GetClosestPoint", ExactSpelling = true)]
    public static extern b2Vec2 Shape_GetClosestPoint(b2ShapeId shapeId, b2Vec2 target);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateChain", ExactSpelling = true)]
    public static extern b2ChainId CreateChain(b2BodyId bodyId, [NativeTypeName("const b2ChainDef *")] b2ChainDef* def);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DestroyChain", ExactSpelling = true)]
    public static extern void DestroyChain(b2ChainId chainId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Chain_SetFriction", ExactSpelling = true)]
    public static extern void Chain_SetFriction(b2ChainId chainId, float friction);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Chain_SetRestitution", ExactSpelling = true)]
    public static extern void Chain_SetRestitution(b2ChainId chainId, float restitution);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Chain_IsValid", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool Chain_IsValid(b2ChainId id);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DestroyJoint", ExactSpelling = true)]
    public static extern void DestroyJoint(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_IsValid", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool Joint_IsValid(b2JointId id);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_GetType", ExactSpelling = true)]
    public static extern b2JointType Joint_GetType(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_GetBodyA", ExactSpelling = true)]
    public static extern b2BodyId Joint_GetBodyA(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_GetBodyB", ExactSpelling = true)]
    public static extern b2BodyId Joint_GetBodyB(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_GetLocalAnchorA", ExactSpelling = true)]
    public static extern b2Vec2 Joint_GetLocalAnchorA(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_GetLocalAnchorB", ExactSpelling = true)]
    public static extern b2Vec2 Joint_GetLocalAnchorB(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_SetCollideConnected", ExactSpelling = true)]
    public static extern void Joint_SetCollideConnected(b2JointId jointId, [NativeTypeName("_Bool")] bool shouldCollide);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_GetCollideConnected", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool Joint_GetCollideConnected(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_SetUserData", ExactSpelling = true)]
    public static extern void Joint_SetUserData(b2JointId jointId, void* userData);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_GetUserData", ExactSpelling = true)]
    public static extern void* Joint_GetUserData(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_WakeBodies", ExactSpelling = true)]
    public static extern void Joint_WakeBodies(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_GetConstraintForce", ExactSpelling = true)]
    public static extern b2Vec2 Joint_GetConstraintForce(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Joint_GetConstraintTorque", ExactSpelling = true)]
    public static extern float Joint_GetConstraintTorque(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateDistanceJoint", ExactSpelling = true)]
    public static extern b2JointId CreateDistanceJoint(b2WorldId worldId, [NativeTypeName("const b2DistanceJointDef *")] b2DistanceJointDef* def);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_SetLength", ExactSpelling = true)]
    public static extern void DistanceJoint_SetLength(b2JointId jointId, float length);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_GetLength", ExactSpelling = true)]
    public static extern float DistanceJoint_GetLength(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_EnableSpring", ExactSpelling = true)]
    public static extern void DistanceJoint_EnableSpring(b2JointId jointId, [NativeTypeName("_Bool")] bool enableSpring);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_IsSpringEnabled", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool DistanceJoint_IsSpringEnabled(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_SetSpringHertz", ExactSpelling = true)]
    public static extern void DistanceJoint_SetSpringHertz(b2JointId jointId, float hertz);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_SetSpringDampingRatio", ExactSpelling = true)]
    public static extern void DistanceJoint_SetSpringDampingRatio(b2JointId jointId, float dampingRatio);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_GetHertz", ExactSpelling = true)]
    public static extern float DistanceJoint_GetHertz(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_GetDampingRatio", ExactSpelling = true)]
    public static extern float DistanceJoint_GetDampingRatio(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_EnableLimit", ExactSpelling = true)]
    public static extern void DistanceJoint_EnableLimit(b2JointId jointId, [NativeTypeName("_Bool")] bool enableLimit);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_IsLimitEnabled", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool DistanceJoint_IsLimitEnabled(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_SetLengthRange", ExactSpelling = true)]
    public static extern void DistanceJoint_SetLengthRange(b2JointId jointId, float minLength, float maxLength);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_GetMinLength", ExactSpelling = true)]
    public static extern float DistanceJoint_GetMinLength(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_GetMaxLength", ExactSpelling = true)]
    public static extern float DistanceJoint_GetMaxLength(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_GetCurrentLength", ExactSpelling = true)]
    public static extern float DistanceJoint_GetCurrentLength(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_EnableMotor", ExactSpelling = true)]
    public static extern void DistanceJoint_EnableMotor(b2JointId jointId, [NativeTypeName("_Bool")] bool enableMotor);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_IsMotorEnabled", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool DistanceJoint_IsMotorEnabled(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_SetMotorSpeed", ExactSpelling = true)]
    public static extern void DistanceJoint_SetMotorSpeed(b2JointId jointId, float motorSpeed);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_GetMotorSpeed", ExactSpelling = true)]
    public static extern float DistanceJoint_GetMotorSpeed(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_SetMaxMotorForce", ExactSpelling = true)]
    public static extern void DistanceJoint_SetMaxMotorForce(b2JointId jointId, float force);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_GetMaxMotorForce", ExactSpelling = true)]
    public static extern float DistanceJoint_GetMaxMotorForce(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DistanceJoint_GetMotorForce", ExactSpelling = true)]
    public static extern float DistanceJoint_GetMotorForce(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateMotorJoint", ExactSpelling = true)]
    public static extern b2JointId CreateMotorJoint(b2WorldId worldId, [NativeTypeName("const b2MotorJointDef *")] b2MotorJointDef* def);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MotorJoint_SetLinearOffset", ExactSpelling = true)]
    public static extern void MotorJoint_SetLinearOffset(b2JointId jointId, b2Vec2 linearOffset);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MotorJoint_GetLinearOffset", ExactSpelling = true)]
    public static extern b2Vec2 MotorJoint_GetLinearOffset(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MotorJoint_SetAngularOffset", ExactSpelling = true)]
    public static extern void MotorJoint_SetAngularOffset(b2JointId jointId, float angularOffset);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MotorJoint_GetAngularOffset", ExactSpelling = true)]
    public static extern float MotorJoint_GetAngularOffset(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MotorJoint_SetMaxForce", ExactSpelling = true)]
    public static extern void MotorJoint_SetMaxForce(b2JointId jointId, float maxForce);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MotorJoint_GetMaxForce", ExactSpelling = true)]
    public static extern float MotorJoint_GetMaxForce(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MotorJoint_SetMaxTorque", ExactSpelling = true)]
    public static extern void MotorJoint_SetMaxTorque(b2JointId jointId, float maxTorque);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MotorJoint_GetMaxTorque", ExactSpelling = true)]
    public static extern float MotorJoint_GetMaxTorque(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MotorJoint_SetCorrectionFactor", ExactSpelling = true)]
    public static extern void MotorJoint_SetCorrectionFactor(b2JointId jointId, float correctionFactor);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MotorJoint_GetCorrectionFactor", ExactSpelling = true)]
    public static extern float MotorJoint_GetCorrectionFactor(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateMouseJoint", ExactSpelling = true)]
    public static extern b2JointId CreateMouseJoint(b2WorldId worldId, [NativeTypeName("const b2MouseJointDef *")] b2MouseJointDef* def);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MouseJoint_SetTarget", ExactSpelling = true)]
    public static extern void MouseJoint_SetTarget(b2JointId jointId, b2Vec2 target);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MouseJoint_GetTarget", ExactSpelling = true)]
    public static extern b2Vec2 MouseJoint_GetTarget(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MouseJoint_SetSpringHertz", ExactSpelling = true)]
    public static extern void MouseJoint_SetSpringHertz(b2JointId jointId, float hertz);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MouseJoint_GetSpringHertz", ExactSpelling = true)]
    public static extern float MouseJoint_GetSpringHertz(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MouseJoint_SetSpringDampingRatio", ExactSpelling = true)]
    public static extern void MouseJoint_SetSpringDampingRatio(b2JointId jointId, float dampingRatio);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MouseJoint_GetSpringDampingRatio", ExactSpelling = true)]
    public static extern float MouseJoint_GetSpringDampingRatio(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MouseJoint_SetMaxForce", ExactSpelling = true)]
    public static extern void MouseJoint_SetMaxForce(b2JointId jointId, float maxForce);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MouseJoint_GetMaxForce", ExactSpelling = true)]
    public static extern float MouseJoint_GetMaxForce(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreatePrismaticJoint", ExactSpelling = true)]
    public static extern b2JointId CreatePrismaticJoint(b2WorldId worldId, [NativeTypeName("const b2PrismaticJointDef *")] b2PrismaticJointDef* def);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_EnableSpring", ExactSpelling = true)]
    public static extern void PrismaticJoint_EnableSpring(b2JointId jointId, [NativeTypeName("_Bool")] bool enableSpring);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_IsSpringEnabled", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool PrismaticJoint_IsSpringEnabled(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_SetSpringHertz", ExactSpelling = true)]
    public static extern void PrismaticJoint_SetSpringHertz(b2JointId jointId, float hertz);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_GetSpringHertz", ExactSpelling = true)]
    public static extern float PrismaticJoint_GetSpringHertz(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_SetSpringDampingRatio", ExactSpelling = true)]
    public static extern void PrismaticJoint_SetSpringDampingRatio(b2JointId jointId, float dampingRatio);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_GetSpringDampingRatio", ExactSpelling = true)]
    public static extern float PrismaticJoint_GetSpringDampingRatio(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_EnableLimit", ExactSpelling = true)]
    public static extern void PrismaticJoint_EnableLimit(b2JointId jointId, [NativeTypeName("_Bool")] bool enableLimit);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_IsLimitEnabled", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool PrismaticJoint_IsLimitEnabled(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_GetLowerLimit", ExactSpelling = true)]
    public static extern float PrismaticJoint_GetLowerLimit(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_GetUpperLimit", ExactSpelling = true)]
    public static extern float PrismaticJoint_GetUpperLimit(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_SetLimits", ExactSpelling = true)]
    public static extern void PrismaticJoint_SetLimits(b2JointId jointId, float lower, float upper);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_EnableMotor", ExactSpelling = true)]
    public static extern void PrismaticJoint_EnableMotor(b2JointId jointId, [NativeTypeName("_Bool")] bool enableMotor);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_IsMotorEnabled", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool PrismaticJoint_IsMotorEnabled(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_SetMotorSpeed", ExactSpelling = true)]
    public static extern void PrismaticJoint_SetMotorSpeed(b2JointId jointId, float motorSpeed);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_GetMotorSpeed", ExactSpelling = true)]
    public static extern float PrismaticJoint_GetMotorSpeed(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_SetMaxMotorForce", ExactSpelling = true)]
    public static extern void PrismaticJoint_SetMaxMotorForce(b2JointId jointId, float force);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_GetMaxMotorForce", ExactSpelling = true)]
    public static extern float PrismaticJoint_GetMaxMotorForce(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PrismaticJoint_GetMotorForce", ExactSpelling = true)]
    public static extern float PrismaticJoint_GetMotorForce(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateRevoluteJoint", ExactSpelling = true)]
    public static extern b2JointId CreateRevoluteJoint(b2WorldId worldId, [NativeTypeName("const b2RevoluteJointDef *")] b2RevoluteJointDef* def);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_EnableSpring", ExactSpelling = true)]
    public static extern void RevoluteJoint_EnableSpring(b2JointId jointId, [NativeTypeName("_Bool")] bool enableSpring);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_SetSpringHertz", ExactSpelling = true)]
    public static extern void RevoluteJoint_SetSpringHertz(b2JointId jointId, float hertz);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_GetSpringHertz", ExactSpelling = true)]
    public static extern float RevoluteJoint_GetSpringHertz(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_SetSpringDampingRatio", ExactSpelling = true)]
    public static extern void RevoluteJoint_SetSpringDampingRatio(b2JointId jointId, float dampingRatio);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_GetSpringDampingRatio", ExactSpelling = true)]
    public static extern float RevoluteJoint_GetSpringDampingRatio(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_GetAngle", ExactSpelling = true)]
    public static extern float RevoluteJoint_GetAngle(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_EnableLimit", ExactSpelling = true)]
    public static extern void RevoluteJoint_EnableLimit(b2JointId jointId, [NativeTypeName("_Bool")] bool enableLimit);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_IsLimitEnabled", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool RevoluteJoint_IsLimitEnabled(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_GetLowerLimit", ExactSpelling = true)]
    public static extern float RevoluteJoint_GetLowerLimit(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_GetUpperLimit", ExactSpelling = true)]
    public static extern float RevoluteJoint_GetUpperLimit(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_SetLimits", ExactSpelling = true)]
    public static extern void RevoluteJoint_SetLimits(b2JointId jointId, float lower, float upper);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_EnableMotor", ExactSpelling = true)]
    public static extern void RevoluteJoint_EnableMotor(b2JointId jointId, [NativeTypeName("_Bool")] bool enableMotor);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_IsMotorEnabled", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool RevoluteJoint_IsMotorEnabled(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_SetMotorSpeed", ExactSpelling = true)]
    public static extern void RevoluteJoint_SetMotorSpeed(b2JointId jointId, float motorSpeed);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_GetMotorSpeed", ExactSpelling = true)]
    public static extern float RevoluteJoint_GetMotorSpeed(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_GetMotorTorque", ExactSpelling = true)]
    public static extern float RevoluteJoint_GetMotorTorque(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_SetMaxMotorTorque", ExactSpelling = true)]
    public static extern void RevoluteJoint_SetMaxMotorTorque(b2JointId jointId, float torque);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RevoluteJoint_GetMaxMotorTorque", ExactSpelling = true)]
    public static extern float RevoluteJoint_GetMaxMotorTorque(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateWeldJoint", ExactSpelling = true)]
    public static extern b2JointId CreateWeldJoint(b2WorldId worldId, [NativeTypeName("const b2WeldJointDef *")] b2WeldJointDef* def);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WeldJoint_SetLinearHertz", ExactSpelling = true)]
    public static extern void WeldJoint_SetLinearHertz(b2JointId jointId, float hertz);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WeldJoint_GetLinearHertz", ExactSpelling = true)]
    public static extern float WeldJoint_GetLinearHertz(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WeldJoint_SetLinearDampingRatio", ExactSpelling = true)]
    public static extern void WeldJoint_SetLinearDampingRatio(b2JointId jointId, float dampingRatio);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WeldJoint_GetLinearDampingRatio", ExactSpelling = true)]
    public static extern float WeldJoint_GetLinearDampingRatio(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WeldJoint_SetAngularHertz", ExactSpelling = true)]
    public static extern void WeldJoint_SetAngularHertz(b2JointId jointId, float hertz);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WeldJoint_GetAngularHertz", ExactSpelling = true)]
    public static extern float WeldJoint_GetAngularHertz(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WeldJoint_SetAngularDampingRatio", ExactSpelling = true)]
    public static extern void WeldJoint_SetAngularDampingRatio(b2JointId jointId, float dampingRatio);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WeldJoint_GetAngularDampingRatio", ExactSpelling = true)]
    public static extern float WeldJoint_GetAngularDampingRatio(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CreateWheelJoint", ExactSpelling = true)]
    public static extern b2JointId CreateWheelJoint(b2WorldId worldId, [NativeTypeName("const b2WheelJointDef *")] b2WheelJointDef* def);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_EnableSpring", ExactSpelling = true)]
    public static extern void WheelJoint_EnableSpring(b2JointId jointId, [NativeTypeName("_Bool")] bool enableSpring);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_IsSpringEnabled", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool WheelJoint_IsSpringEnabled(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_SetSpringHertz", ExactSpelling = true)]
    public static extern void WheelJoint_SetSpringHertz(b2JointId jointId, float hertz);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_GetSpringHertz", ExactSpelling = true)]
    public static extern float WheelJoint_GetSpringHertz(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_SetSpringDampingRatio", ExactSpelling = true)]
    public static extern void WheelJoint_SetSpringDampingRatio(b2JointId jointId, float dampingRatio);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_GetSpringDampingRatio", ExactSpelling = true)]
    public static extern float WheelJoint_GetSpringDampingRatio(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_EnableLimit", ExactSpelling = true)]
    public static extern void WheelJoint_EnableLimit(b2JointId jointId, [NativeTypeName("_Bool")] bool enableLimit);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_IsLimitEnabled", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool WheelJoint_IsLimitEnabled(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_GetLowerLimit", ExactSpelling = true)]
    public static extern float WheelJoint_GetLowerLimit(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_GetUpperLimit", ExactSpelling = true)]
    public static extern float WheelJoint_GetUpperLimit(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_SetLimits", ExactSpelling = true)]
    public static extern void WheelJoint_SetLimits(b2JointId jointId, float lower, float upper);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_EnableMotor", ExactSpelling = true)]
    public static extern void WheelJoint_EnableMotor(b2JointId jointId, [NativeTypeName("_Bool")] bool enableMotor);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_IsMotorEnabled", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool WheelJoint_IsMotorEnabled(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_SetMotorSpeed", ExactSpelling = true)]
    public static extern void WheelJoint_SetMotorSpeed(b2JointId jointId, float motorSpeed);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_GetMotorSpeed", ExactSpelling = true)]
    public static extern float WheelJoint_GetMotorSpeed(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_SetMaxMotorTorque", ExactSpelling = true)]
    public static extern void WheelJoint_SetMaxMotorTorque(b2JointId jointId, float torque);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_GetMaxMotorTorque", ExactSpelling = true)]
    public static extern float WheelJoint_GetMaxMotorTorque(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2WheelJoint_GetMotorTorque", ExactSpelling = true)]
    public static extern float WheelJoint_GetMotorTorque(b2JointId jointId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2IsValidRay", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool IsValidRay([NativeTypeName("const b2RayCastInput *")] b2RayCastInput* input);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MakePolygon", ExactSpelling = true)]
    public static extern b2Polygon MakePolygon([NativeTypeName("const b2Hull *")] b2Hull* hull, float radius);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MakeOffsetPolygon", ExactSpelling = true)]
    public static extern b2Polygon MakeOffsetPolygon([NativeTypeName("const b2Hull *")] b2Hull* hull, float radius, b2Transform transform);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MakeSquare", ExactSpelling = true)]
    public static extern b2Polygon MakeSquare(float h);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MakeBox", ExactSpelling = true)]
    public static extern b2Polygon MakeBox(float hx, float hy);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MakeRoundedBox", ExactSpelling = true)]
    public static extern b2Polygon MakeRoundedBox(float hx, float hy, float radius);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MakeOffsetBox", ExactSpelling = true)]
    public static extern b2Polygon MakeOffsetBox(float hx, float hy, b2Vec2 center, float angle);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2TransformPolygon", ExactSpelling = true)]
    public static extern b2Polygon TransformPolygon(b2Transform transform, [NativeTypeName("const b2Polygon *")] b2Polygon* polygon);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ComputeCircleMass", ExactSpelling = true)]
    public static extern b2MassData ComputeCircleMass([NativeTypeName("const b2Circle *")] b2Circle* shape, float density);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ComputeCapsuleMass", ExactSpelling = true)]
    public static extern b2MassData ComputeCapsuleMass([NativeTypeName("const b2Capsule *")] b2Capsule* shape, float density);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ComputePolygonMass", ExactSpelling = true)]
    public static extern b2MassData ComputePolygonMass([NativeTypeName("const b2Polygon *")] b2Polygon* shape, float density);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ComputeCircleAABB", ExactSpelling = true)]
    public static extern b2AABB ComputeCircleAABB([NativeTypeName("const b2Circle *")] b2Circle* shape, b2Transform transform);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ComputeCapsuleAABB", ExactSpelling = true)]
    public static extern b2AABB ComputeCapsuleAABB([NativeTypeName("const b2Capsule *")] b2Capsule* shape, b2Transform transform);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ComputePolygonAABB", ExactSpelling = true)]
    public static extern b2AABB ComputePolygonAABB([NativeTypeName("const b2Polygon *")] b2Polygon* shape, b2Transform transform);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ComputeSegmentAABB", ExactSpelling = true)]
    public static extern b2AABB ComputeSegmentAABB([NativeTypeName("const b2Segment *")] b2Segment* shape, b2Transform transform);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PointInCircle", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool PointInCircle(b2Vec2 point, [NativeTypeName("const b2Circle *")] b2Circle* shape);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PointInCapsule", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool PointInCapsule(b2Vec2 point, [NativeTypeName("const b2Capsule *")] b2Capsule* shape);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2PointInPolygon", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool PointInPolygon(b2Vec2 point, [NativeTypeName("const b2Polygon *")] b2Polygon* shape);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RayCastCircle", ExactSpelling = true)]
    public static extern b2CastOutput RayCastCircle([NativeTypeName("const b2RayCastInput *")] b2RayCastInput* input, [NativeTypeName("const b2Circle *")] b2Circle* shape);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RayCastCapsule", ExactSpelling = true)]
    public static extern b2CastOutput RayCastCapsule([NativeTypeName("const b2RayCastInput *")] b2RayCastInput* input, [NativeTypeName("const b2Capsule *")] b2Capsule* shape);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RayCastSegment", ExactSpelling = true)]
    public static extern b2CastOutput RayCastSegment([NativeTypeName("const b2RayCastInput *")] b2RayCastInput* input, [NativeTypeName("const b2Segment *")] b2Segment* shape, [NativeTypeName("_Bool")] bool oneSided);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2RayCastPolygon", ExactSpelling = true)]
    public static extern b2CastOutput RayCastPolygon([NativeTypeName("const b2RayCastInput *")] b2RayCastInput* input, [NativeTypeName("const b2Polygon *")] b2Polygon* shape);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ShapeCastCircle", ExactSpelling = true)]
    public static extern b2CastOutput ShapeCastCircle([NativeTypeName("const b2ShapeCastInput *")] b2ShapeCastInput* input, [NativeTypeName("const b2Circle *")] b2Circle* shape);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ShapeCastCapsule", ExactSpelling = true)]
    public static extern b2CastOutput ShapeCastCapsule([NativeTypeName("const b2ShapeCastInput *")] b2ShapeCastInput* input, [NativeTypeName("const b2Capsule *")] b2Capsule* shape);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ShapeCastSegment", ExactSpelling = true)]
    public static extern b2CastOutput ShapeCastSegment([NativeTypeName("const b2ShapeCastInput *")] b2ShapeCastInput* input, [NativeTypeName("const b2Segment *")] b2Segment* shape);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ShapeCastPolygon", ExactSpelling = true)]
    public static extern b2CastOutput ShapeCastPolygon([NativeTypeName("const b2ShapeCastInput *")] b2ShapeCastInput* input, [NativeTypeName("const b2Polygon *")] b2Polygon* shape);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ComputeHull", ExactSpelling = true)]
    public static extern b2Hull ComputeHull([NativeTypeName("const b2Vec2 *")] b2Vec2* points, [NativeTypeName("int32_t")] int count);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ValidateHull", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool ValidateHull([NativeTypeName("const b2Hull *")] b2Hull* hull);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2SegmentDistance", ExactSpelling = true)]
    public static extern b2SegmentDistanceResult SegmentDistance(b2Vec2 p1, b2Vec2 q1, b2Vec2 p2, b2Vec2 q2);

    [NativeTypeName("const b2DistanceCache")]
    public static ref readonly b2DistanceCache b2_emptyDistanceCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            ReadOnlySpan<byte> data = new byte[] {
                0x00, 0x00,
                ,

            };

            Debug.Assert(data.Length == Unsafe.SizeOf<b2DistanceCache>());
            return ref Unsafe.As<byte, b2DistanceCache>(ref MemoryMarshal.GetReference(data));
        }
    }

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ShapeDistance", ExactSpelling = true)]
    public static extern b2DistanceOutput ShapeDistance(b2DistanceCache* cache, [NativeTypeName("const b2DistanceInput *")] b2DistanceInput* input, b2Simplex* simplexes, int simplexCapacity);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2ShapeCast", ExactSpelling = true)]
    public static extern b2CastOutput ShapeCast([NativeTypeName("const b2ShapeCastPairInput *")] b2ShapeCastPairInput* input);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2MakeProxy", ExactSpelling = true)]
    public static extern b2DistanceProxy MakeProxy([NativeTypeName("const b2Vec2 *")] b2Vec2* vertices, [NativeTypeName("int32_t")] int count, float radius);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2GetSweepTransform", ExactSpelling = true)]
    public static extern b2Transform GetSweepTransform([NativeTypeName("const b2Sweep *")] b2Sweep* sweep, float time);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2TimeOfImpact", ExactSpelling = true)]
    public static extern b2TOIOutput TimeOfImpact([NativeTypeName("const b2TOIInput *")] b2TOIInput* input);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollideCircles", ExactSpelling = true)]
    public static extern b2Manifold CollideCircles([NativeTypeName("const b2Circle *")] b2Circle* circleA, b2Transform xfA, [NativeTypeName("const b2Circle *")] b2Circle* circleB, b2Transform xfB);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollideCapsuleAndCircle", ExactSpelling = true)]
    public static extern b2Manifold CollideCapsuleAndCircle([NativeTypeName("const b2Capsule *")] b2Capsule* capsuleA, b2Transform xfA, [NativeTypeName("const b2Circle *")] b2Circle* circleB, b2Transform xfB);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollideSegmentAndCircle", ExactSpelling = true)]
    public static extern b2Manifold CollideSegmentAndCircle([NativeTypeName("const b2Segment *")] b2Segment* segmentA, b2Transform xfA, [NativeTypeName("const b2Circle *")] b2Circle* circleB, b2Transform xfB);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollidePolygonAndCircle", ExactSpelling = true)]
    public static extern b2Manifold CollidePolygonAndCircle([NativeTypeName("const b2Polygon *")] b2Polygon* polygonA, b2Transform xfA, [NativeTypeName("const b2Circle *")] b2Circle* circleB, b2Transform xfB);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollideCapsules", ExactSpelling = true)]
    public static extern b2Manifold CollideCapsules([NativeTypeName("const b2Capsule *")] b2Capsule* capsuleA, b2Transform xfA, [NativeTypeName("const b2Capsule *")] b2Capsule* capsuleB, b2Transform xfB);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollideSegmentAndCapsule", ExactSpelling = true)]
    public static extern b2Manifold CollideSegmentAndCapsule([NativeTypeName("const b2Segment *")] b2Segment* segmentA, b2Transform xfA, [NativeTypeName("const b2Capsule *")] b2Capsule* capsuleB, b2Transform xfB);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollidePolygonAndCapsule", ExactSpelling = true)]
    public static extern b2Manifold CollidePolygonAndCapsule([NativeTypeName("const b2Polygon *")] b2Polygon* polygonA, b2Transform xfA, [NativeTypeName("const b2Capsule *")] b2Capsule* capsuleB, b2Transform xfB);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollidePolygons", ExactSpelling = true)]
    public static extern b2Manifold CollidePolygons([NativeTypeName("const b2Polygon *")] b2Polygon* polygonA, b2Transform xfA, [NativeTypeName("const b2Polygon *")] b2Polygon* polygonB, b2Transform xfB);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollideSegmentAndPolygon", ExactSpelling = true)]
    public static extern b2Manifold CollideSegmentAndPolygon([NativeTypeName("const b2Segment *")] b2Segment* segmentA, b2Transform xfA, [NativeTypeName("const b2Polygon *")] b2Polygon* polygonB, b2Transform xfB);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollideSmoothSegmentAndCircle", ExactSpelling = true)]
    public static extern b2Manifold CollideSmoothSegmentAndCircle([NativeTypeName("const b2SmoothSegment *")] b2SmoothSegment* smoothSegmentA, b2Transform xfA, [NativeTypeName("const b2Circle *")] b2Circle* circleB, b2Transform xfB);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollideSmoothSegmentAndCapsule", ExactSpelling = true)]
    public static extern b2Manifold CollideSmoothSegmentAndCapsule([NativeTypeName("const b2SmoothSegment *")] b2SmoothSegment* smoothSegmentA, b2Transform xfA, [NativeTypeName("const b2Capsule *")] b2Capsule* capsuleB, b2Transform xfB, b2DistanceCache* cache);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2CollideSmoothSegmentAndPolygon", ExactSpelling = true)]
    public static extern b2Manifold CollideSmoothSegmentAndPolygon([NativeTypeName("const b2SmoothSegment *")] b2SmoothSegment* smoothSegmentA, b2Transform xfA, [NativeTypeName("const b2Polygon *")] b2Polygon* polygonB, b2Transform xfB, b2DistanceCache* cache);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_Create", ExactSpelling = true)]
    public static extern b2DynamicTree DynamicTree_Create();

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_Destroy", ExactSpelling = true)]
    public static extern void DynamicTree_Destroy(b2DynamicTree* tree);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_CreateProxy", ExactSpelling = true)]
    [return: NativeTypeName("int32_t")]
    public static extern int DynamicTree_CreateProxy(b2DynamicTree* tree, b2AABB aabb, [NativeTypeName("uint32_t")] uint categoryBits, [NativeTypeName("int32_t")] int userData);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_DestroyProxy", ExactSpelling = true)]
    public static extern void DynamicTree_DestroyProxy(b2DynamicTree* tree, [NativeTypeName("int32_t")] int proxyId);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_MoveProxy", ExactSpelling = true)]
    public static extern void DynamicTree_MoveProxy(b2DynamicTree* tree, [NativeTypeName("int32_t")] int proxyId, b2AABB aabb);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_EnlargeProxy", ExactSpelling = true)]
    public static extern void DynamicTree_EnlargeProxy(b2DynamicTree* tree, [NativeTypeName("int32_t")] int proxyId, b2AABB aabb);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_Query", ExactSpelling = true)]
    public static extern void DynamicTree_Query([NativeTypeName("const b2DynamicTree *")] b2DynamicTree* tree, b2AABB aabb, [NativeTypeName("uint32_t")] uint maskBits, [NativeTypeName("b2TreeQueryCallbackFcn *")] IntPtr callback, void* context);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_RayCast", ExactSpelling = true)]
    public static extern void DynamicTree_RayCast([NativeTypeName("const b2DynamicTree *")] b2DynamicTree* tree, [NativeTypeName("const b2RayCastInput *")] b2RayCastInput* input, [NativeTypeName("uint32_t")] uint maskBits, [NativeTypeName("b2TreeRayCastCallbackFcn *")] IntPtr callback, void* context);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_ShapeCast", ExactSpelling = true)]
    public static extern void DynamicTree_ShapeCast([NativeTypeName("const b2DynamicTree *")] b2DynamicTree* tree, [NativeTypeName("const b2ShapeCastInput *")] b2ShapeCastInput* input, [NativeTypeName("uint32_t")] uint maskBits, [NativeTypeName("b2TreeShapeCastCallbackFcn *")] IntPtr callback, void* context);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_Validate", ExactSpelling = true)]
    public static extern void DynamicTree_Validate([NativeTypeName("const b2DynamicTree *")] b2DynamicTree* tree);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_GetHeight", ExactSpelling = true)]
    public static extern int DynamicTree_GetHeight([NativeTypeName("const b2DynamicTree *")] b2DynamicTree* tree);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_GetMaxBalance", ExactSpelling = true)]
    public static extern int DynamicTree_GetMaxBalance([NativeTypeName("const b2DynamicTree *")] b2DynamicTree* tree);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_GetAreaRatio", ExactSpelling = true)]
    public static extern float DynamicTree_GetAreaRatio([NativeTypeName("const b2DynamicTree *")] b2DynamicTree* tree);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_RebuildBottomUp", ExactSpelling = true)]
    public static extern void DynamicTree_RebuildBottomUp(b2DynamicTree* tree);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_GetProxyCount", ExactSpelling = true)]
    public static extern int DynamicTree_GetProxyCount([NativeTypeName("const b2DynamicTree *")] b2DynamicTree* tree);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_Rebuild", ExactSpelling = true)]
    public static extern int DynamicTree_Rebuild(b2DynamicTree* tree, [NativeTypeName("_Bool")] bool fullBuild);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_ShiftOrigin", ExactSpelling = true)]
    public static extern void DynamicTree_ShiftOrigin(b2DynamicTree* tree, b2Vec2 newOrigin);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_GetByteCount", ExactSpelling = true)]
    public static extern int DynamicTree_GetByteCount([NativeTypeName("const b2DynamicTree *")] b2DynamicTree* tree);

    [return: NativeTypeName("int32_t")]
    public static int DynamicTree_GetUserData([NativeTypeName("const b2DynamicTree *")] b2DynamicTree* tree, [NativeTypeName("int32_t")] int proxyId)
    {
        return tree->nodes[proxyId].userData;
    }

    public static b2AABB DynamicTree_GetAABB([NativeTypeName("const b2DynamicTree *")] b2DynamicTree* tree, [NativeTypeName("int32_t")] int proxyId)
    {
        return tree->nodes[proxyId].aabb;
    }

    [NativeTypeName("#define b2_maxPolygonVertices 8")]
    public const int b2_maxPolygonVertices = 8;

    [NativeTypeName("#define b2_defaultCategoryBits ( 0x00000001 )")]
    public const int b2_defaultCategoryBits = (0x00000001);

    [NativeTypeName("#define b2_defaultMaskBits ( 0xFFFFFFFF )")]
    public const uint b2_defaultMaskBits = (0xFFFFFFFF);

    [NativeTypeName("const b2WorldId")]
    public static ref readonly b2WorldId b2_nullWorldId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            ReadOnlySpan<byte> data = new byte[] {
                0x00, 0x00,
                0x00, 0x00
            };

            Debug.Assert(data.Length == Unsafe.SizeOf<b2WorldId>());
            return ref Unsafe.As<byte, b2WorldId>(ref MemoryMarshal.GetReference(data));
        }
    }

    [NativeTypeName("const b2BodyId")]
    public static ref readonly b2BodyId b2_nullBodyId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            ReadOnlySpan<byte> data = new byte[] {
                0x00, 0x00, 0x00, 0x00,
                0x00, 0x00,
                0x00, 0x00
            };

            Debug.Assert(data.Length == Unsafe.SizeOf<b2BodyId>());
            return ref Unsafe.As<byte, b2BodyId>(ref MemoryMarshal.GetReference(data));
        }
    }

    [NativeTypeName("const b2ShapeId")]
    public static ref readonly b2ShapeId b2_nullShapeId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            ReadOnlySpan<byte> data = new byte[] {
                0x00, 0x00, 0x00, 0x00,
                0x00, 0x00,
                0x00, 0x00
            };

            Debug.Assert(data.Length == Unsafe.SizeOf<b2ShapeId>());
            return ref Unsafe.As<byte, b2ShapeId>(ref MemoryMarshal.GetReference(data));
        }
    }

    [NativeTypeName("const b2JointId")]
    public static ref readonly b2JointId b2_nullJointId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            ReadOnlySpan<byte> data = new byte[] {
                0x00, 0x00, 0x00, 0x00,
                0x00, 0x00,
                0x00, 0x00
            };

            Debug.Assert(data.Length == Unsafe.SizeOf<b2JointId>());
            return ref Unsafe.As<byte, b2JointId>(ref MemoryMarshal.GetReference(data));
        }
    }

    [NativeTypeName("const b2ChainId")]
    public static ref readonly b2ChainId b2_nullChainId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            ReadOnlySpan<byte> data = new byte[] {
                0x00, 0x00, 0x00, 0x00,
                0x00, 0x00,
                0x00, 0x00
            };

            Debug.Assert(data.Length == Unsafe.SizeOf<b2ChainId>());
            return ref Unsafe.As<byte, b2ChainId>(ref MemoryMarshal.GetReference(data));
        }
    }

    [NativeTypeName("const b2Vec2")]
    public static ref readonly b2Vec2 b2Vec2_zero
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            ReadOnlySpan<byte> data = new byte[] {
                0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00
            };

            Debug.Assert(data.Length == Unsafe.SizeOf<b2Vec2>());
            return ref Unsafe.As<byte, b2Vec2>(ref MemoryMarshal.GetReference(data));
        }
    }

    [NativeTypeName("const b2Rot")]
    public static ref readonly b2Rot b2Rot_identity
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            ReadOnlySpan<byte> data = new byte[] {
                0x00, 0x00, 0x80, 0x3F,
                0x00, 0x00, 0x00, 0x00
            };

            Debug.Assert(data.Length == Unsafe.SizeOf<b2Rot>());
            return ref Unsafe.As<byte, b2Rot>(ref MemoryMarshal.GetReference(data));
        }
    }

    [NativeTypeName("const b2Transform")]
    public static ref readonly b2Transform b2Transform_identity
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            ReadOnlySpan<byte> data = new byte[] {
                0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x80, 0x3F,
                0x00, 0x00, 0x00, 0x00
            };

            Debug.Assert(data.Length == Unsafe.SizeOf<b2Transform>());
            return ref Unsafe.As<byte, b2Transform>(ref MemoryMarshal.GetReference(data));
        }
    }

    [NativeTypeName("const b2Mat22")]
    public static ref readonly b2Mat22 b2Mat22_zero
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            ReadOnlySpan<byte> data = new byte[] {
                0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00
            };

            Debug.Assert(data.Length == Unsafe.SizeOf<b2Mat22>());
            return ref Unsafe.As<byte, b2Mat22>(ref MemoryMarshal.GetReference(data));
        }
    }

    public static float MinFloat(float a, float b)
    {
        return a < b ? a : b;
    }

    public static float MaxFloat(float a, float b)
    {
        return a > b ? a : b;
    }

    public static float AbsFloat(float a)
    {
        return a < 0 ? -a : a;
    }

    public static float ClampFloat(float a, float lower, float upper)
    {
        return a < lower ? lower : (a > upper ? upper : a);
    }

    public static int MinInt(int a, int b)
    {
        return a < b ? a : b;
    }

    public static int MaxInt(int a, int b)
    {
        return a > b ? a : b;
    }

    public static int AbsInt(int a)
    {
        return a < 0 ? -a : a;
    }

    public static int ClampInt(int a, int lower, int upper)
    {
        return a < lower ? lower : (a > upper ? upper : a);
    }

    public static float Dot(b2Vec2 a, b2Vec2 b)
    {
        return a.x * b.x + a.y * b.y;
    }

    public static float Cross(b2Vec2 a, b2Vec2 b)
    {
        return a.x * b.y - a.y * b.x;
    }

    public static b2Vec2 CrossVS(b2Vec2 v, float s)
    {
        return ;
    }

    public static b2Vec2 CrossSV(float s, b2Vec2 v)
    {
        return ;
    }

    public static b2Vec2 LeftPerp(b2Vec2 v)
    {
        return ;
    }

    public static b2Vec2 RightPerp(b2Vec2 v)
    {
        return ;
    }

    public static b2Vec2 Add(b2Vec2 a, b2Vec2 b)
    {
        return ;
    }

    public static b2Vec2 Sub(b2Vec2 a, b2Vec2 b)
    {
        return ;
    }

    public static b2Vec2 Neg(b2Vec2 a)
    {
        return ;
    }

    public static b2Vec2 Lerp(b2Vec2 a, b2Vec2 b, float t)
    {
        return ;
    }

    public static b2Vec2 Mul(b2Vec2 a, b2Vec2 b)
    {
        return ;
    }

    public static b2Vec2 MulSV(float s, b2Vec2 v)
    {
        return ;
    }

    public static b2Vec2 MulAdd(b2Vec2 a, float s, b2Vec2 b)
    {
        return ;
    }

    public static b2Vec2 MulSub(b2Vec2 a, float s, b2Vec2 b)
    {
        return ;
    }

    public static b2Vec2 Abs(b2Vec2 a)
    {
        b2Vec2 b;

        b.x = AbsFloat(a.x);
        b.y = AbsFloat(a.y);
        return b;
    }

    public static b2Vec2 Min(b2Vec2 a, b2Vec2 b)
    {
        b2Vec2 c;

        c.x = MinFloat(a.x, b.x);
        c.y = MinFloat(a.y, b.y);
        return c;
    }

    public static b2Vec2 Max(b2Vec2 a, b2Vec2 b)
    {
        b2Vec2 c;

        c.x = MaxFloat(a.x, b.x);
        c.y = MaxFloat(a.y, b.y);
        return c;
    }

    public static b2Vec2 Clamp(b2Vec2 v, b2Vec2 a, b2Vec2 b)
    {
        b2Vec2 c;

        c.x = ClampFloat(v.x, a.x, b.x);
        c.y = ClampFloat(v.y, a.y, b.y);
        return c;
    }

    public static float Length(b2Vec2 v)
    {
        return sqrtf(v.x * v.x + v.y * v.y);
    }

    public static float LengthSquared(b2Vec2 v)
    {
        return v.x * v.x + v.y * v.y;
    }

    public static float Distance(b2Vec2 a, b2Vec2 b)
    {
        float dx = b.x - a.x;
        float dy = b.y - a.y;

        return sqrtf(dx * dx + dy * dy);
    }

    public static float DistanceSquared(b2Vec2 a, b2Vec2 b)
    {
        b2Vec2 c = new b2Vec2
        {
            x = b.x - a.x,
            y = b.y - a.y,
        };

        return c.x * c.x + c.y * c.y;
    }

    public static b2Rot MakeRot(float angle)
    {
        b2Rot q = new b2Rot
        {
            c = cosf(angle),
            s = sinf(angle),
        };

        return q;
    }

    public static b2Rot NormalizeRot(b2Rot q)
    {
        float mag = sqrtf(q.s * q.s + q.c * q.c);
        float invMag = mag > 0.0 ? 1.0f / mag : 0.0f;
        b2Rot qn = new b2Rot
        {
            c = q.c * invMag,
            s = q.s * invMag,
        };

        return qn;
    }

    [return: NativeTypeName("_Bool")]
    public static bool IsNormalized(b2Rot q)
    {
        float qq = q.s * q.s + q.c * q.c;

        return (1.0f - 0.0006f < qq && qq < 1.0f + 0.0006f) != 0;
    }

    public static b2Rot NLerp(b2Rot q1, b2Rot q2, float t)
    {
        float omt = 1.0f - t;
        b2Rot q = new b2Rot
        {
            c = omt * q1.c + t * q2.c,
            s = omt * q1.s + t * q2.s,
        };

        return NormalizeRot(q);
    }

    public static b2Rot IntegrateRotation(b2Rot q1, float deltaAngle)
    {
        b2Rot q2 = new b2Rot
        {
            c = q1.c - deltaAngle * q1.s,
            s = q1.s + deltaAngle * q1.c,
        };
        float mag = sqrtf(q2.s * q2.s + q2.c * q2.c);
        float invMag = mag > 0.0 ? 1.0f / mag : 0.0f;
        b2Rot qn = new b2Rot
        {
            c = q2.c * invMag,
            s = q2.s * invMag,
        };

        return qn;
    }

    public static float ComputeAngularVelocity(b2Rot q1, b2Rot q2, float inv_h)
    {
        float omega = inv_h * (q2.s * q1.c - q2.c * q1.s);

        return omega;
    }

    public static float Rot_GetAngle(b2Rot q)
    {
        return atan2f(q.s, q.c);
    }

    public static b2Vec2 Rot_GetXAxis(b2Rot q)
    {
        b2Vec2 v = new b2Vec2
        {
            x = q.c,
            y = q.s,
        };

        return v;
    }

    public static b2Vec2 Rot_GetYAxis(b2Rot q)
    {
        b2Vec2 v = new b2Vec2
        {
            x = -q.s,
            y = q.c,
        };

        return v;
    }

    public static b2Rot MulRot(b2Rot q, b2Rot r)
    {
        b2Rot qr;

        qr.s = q.s * r.c + q.c * r.s;
        qr.c = q.c * r.c - q.s * r.s;
        return qr;
    }

    public static b2Rot InvMulRot(b2Rot q, b2Rot r)
    {
        b2Rot qr;

        qr.s = q.c * r.s - q.s * r.c;
        qr.c = q.c * r.c + q.s * r.s;
        return qr;
    }

    public static float RelativeAngle(b2Rot b, b2Rot a)
    {
        float s = b.s * a.c - b.c * a.s;
        float c = b.c * a.c + b.s * a.s;

        return atan2f(s, c);
    }

    public static float UnwindAngle(float angle)
    {
        if (angle < -3.14159265359f)
        {
            return angle + 2.0f * 3.14159265359f;
        }
        else if (angle > 3.14159265359f)
        {
            return angle - 2.0f * 3.14159265359f;
        }

        return angle;
    }

    public static b2Vec2 RotateVector(b2Rot q, b2Vec2 v)
    {
        return ;
    }

    public static b2Vec2 InvRotateVector(b2Rot q, b2Vec2 v)
    {
        return ;
    }

    public static b2Vec2 TransformPoint(b2Transform t, [NativeTypeName("const b2Vec2")] b2Vec2 p)
    {
        float x = (t.q.c * p.x - t.q.s * p.y) + t.p.x;
        float y = (t.q.s * p.x + t.q.c * p.y) + t.p.y;

        return ;
    }

    public static b2Vec2 InvTransformPoint(b2Transform t, [NativeTypeName("const b2Vec2")] b2Vec2 p)
    {
        float vx = p.x - t.p.x;
        float vy = p.y - t.p.y;

        return ;
    }

    public static b2Transform MulTransforms(b2Transform A, b2Transform B)
    {
        b2Transform C;

        C.q = MulRot(A.q, B.q);
        C.p = Add(RotateVector(A.q, B.p), A.p);
        return C;
    }

    public static b2Transform InvMulTransforms(b2Transform A, b2Transform B)
    {
        b2Transform C;

        C.q = InvMulRot(A.q, B.q);
        C.p = InvRotateVector(A.q, Sub(B.p, A.p));
        return C;
    }

    public static b2Vec2 MulMV(b2Mat22 A, b2Vec2 v)
    {
        b2Vec2 u = new b2Vec2
        {
            x = A.cx.x * v.x + A.cy.x * v.y,
            y = A.cx.y * v.x + A.cy.y * v.y,
        };

        return u;
    }

    public static b2Mat22 GetInverse22(b2Mat22 A)
    {
        float a = A.cx.x, b = A.cy.x, c = A.cx.y, d = A.cy.y;
        float det = a * d - b * c;

        if (det != 0.0f)
        {
            det = 1.0f / det;
        }

        b2Mat22 B = new b2Mat22
        {
            cx = new b2Vec2
            {
                x = det * d,
                y = -det * c,
            },
            cy = new b2Vec2
            {
                x = -det * b,
                y = det * a,
            },
        };

        return B;
    }

    public static b2Vec2 Solve22(b2Mat22 A, b2Vec2 b)
    {
        float a11 = A.cx.x, a12 = A.cy.x, a21 = A.cx.y, a22 = A.cy.y;
        float det = a11 * a22 - a12 * a21;

        if (det != 0.0f)
        {
            det = 1.0f / det;
        }

        b2Vec2 x = new b2Vec2
        {
            x = det * (a22 * b.x - a12 * b.y),
            y = det * (a11 * b.y - a21 * b.x),
        };

        return x;
    }

    [return: NativeTypeName("_Bool")]
    public static bool AABB_Contains(b2AABB a, b2AABB b)
    {
        bool s = (1) != 0;

        s = ((s) ? 1 : 0 && a.lowerBound.x <= b.lowerBound.x) != 0;
        s = ((s) ? 1 : 0 && a.lowerBound.y <= b.lowerBound.y) != 0;
        s = ((s) ? 1 : 0 && b.upperBound.x <= a.upperBound.x) != 0;
        s = ((s) ? 1 : 0 && b.upperBound.y <= a.upperBound.y) != 0;
        return s;
    }

    public static b2Vec2 AABB_Center(b2AABB a)
    {
        b2Vec2 b = new b2Vec2
        {
            x = 0.5f * (a.lowerBound.x + a.upperBound.x),
            y = 0.5f * (a.lowerBound.y + a.upperBound.y),
        };

        return b;
    }

    public static b2Vec2 AABB_Extents(b2AABB a)
    {
        b2Vec2 b = new b2Vec2
        {
            x = 0.5f * (a.upperBound.x - a.lowerBound.x),
            y = 0.5f * (a.upperBound.y - a.lowerBound.y),
        };

        return b;
    }

    public static b2AABB AABB_Union(b2AABB a, b2AABB b)
    {
        b2AABB c;

        c.lowerBound.x = MinFloat(a.lowerBound.x, b.lowerBound.x);
        c.lowerBound.y = MinFloat(a.lowerBound.y, b.lowerBound.y);
        c.upperBound.x = MaxFloat(a.upperBound.x, b.upperBound.x);
        c.upperBound.y = MaxFloat(a.upperBound.y, b.upperBound.y);
        return c;
    }

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2IsValid", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool IsValid(float a);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Vec2_IsValid", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool Vec2_IsValid(b2Vec2 v);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Rot_IsValid", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool Rot_IsValid(b2Rot q);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2AABB_IsValid", ExactSpelling = true)]
    [return: NativeTypeName("_Bool")]
    public static extern bool AABB_IsValid(b2AABB aabb);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Normalize", ExactSpelling = true)]
    public static extern b2Vec2 Normalize(b2Vec2 v);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2NormalizeChecked", ExactSpelling = true)]
    public static extern b2Vec2 NormalizeChecked(b2Vec2 v);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2GetLengthAndNormalize", ExactSpelling = true)]
    public static extern b2Vec2 GetLengthAndNormalize(float* length, b2Vec2 v);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2SetLengthUnitsPerMeter", ExactSpelling = true)]
    public static extern void SetLengthUnitsPerMeter(float lengthUnits);

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2GetLengthUnitsPerMeter", ExactSpelling = true)]
    public static extern float GetLengthUnitsPerMeter();

    [NativeTypeName("#define b2_pi 3.14159265359f")]
    public const float b2_pi = 3.14159265359f;

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DefaultWorldDef", ExactSpelling = true)]
    public static extern b2WorldDef DefaultWorldDef();

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DefaultBodyDef", ExactSpelling = true)]
    public static extern b2BodyDef DefaultBodyDef();

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DefaultFilter", ExactSpelling = true)]
    public static extern b2Filter DefaultFilter();

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DefaultQueryFilter", ExactSpelling = true)]
    public static extern b2QueryFilter DefaultQueryFilter();

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DefaultShapeDef", ExactSpelling = true)]
    public static extern b2ShapeDef DefaultShapeDef();

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DefaultChainDef", ExactSpelling = true)]
    public static extern b2ChainDef DefaultChainDef();

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DefaultDistanceJointDef", ExactSpelling = true)]
    public static extern b2DistanceJointDef DefaultDistanceJointDef();

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DefaultMotorJointDef", ExactSpelling = true)]
    public static extern b2MotorJointDef DefaultMotorJointDef();

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DefaultMouseJointDef", ExactSpelling = true)]
    public static extern b2MouseJointDef DefaultMouseJointDef();

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DefaultPrismaticJointDef", ExactSpelling = true)]
    public static extern b2PrismaticJointDef DefaultPrismaticJointDef();

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DefaultRevoluteJointDef", ExactSpelling = true)]
    public static extern b2RevoluteJointDef DefaultRevoluteJointDef();

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DefaultWeldJointDef", ExactSpelling = true)]
    public static extern b2WeldJointDef DefaultWeldJointDef();

    [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DefaultWheelJointDef", ExactSpelling = true)]
    public static extern b2WheelJointDef DefaultWheelJointDef();
}
