using System;

namespace Box2D.Interop;

public unsafe partial struct b2WorldDef
{
    [NativeTypeName("b2Vec2")]
    public System.Numerics.Vector2 gravity;

    public float restitutionThreshold;

    public float contactPushoutVelocity;

    public float hitEventThreshold;

    public float contactHertz;

    public float contactDampingRatio;

    public float jointHertz;

    public float jointDampingRatio;

    [NativeTypeName("_Bool")]
    public bool enableSleep;

    [NativeTypeName("_Bool")]
    public bool enableContinous;

    [NativeTypeName("int32_t")]
    public int workerCount;

    [NativeTypeName("b2EnqueueTaskCallback *")]
    public IntPtr enqueueTask;

    [NativeTypeName("b2FinishTaskCallback *")]
    public IntPtr finishTask;

    public void* userTaskContext;

    [NativeTypeName("int32_t")]
    public int internalValue;
}
