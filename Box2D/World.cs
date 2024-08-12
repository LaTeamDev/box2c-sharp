using Box2D.Interop;

namespace Box2D; 

public class World : IDisposable {
    private b2WorldId _id;

    public unsafe World(WorldDef def) {
        using var worldDef = def._b2WorldDef.GcPin();
        _id = B2.CreateWorld(worldDef.Pointer);
    }
    
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
}