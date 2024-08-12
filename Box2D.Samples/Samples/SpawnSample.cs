using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Box2D.Interop;
using ZeroElectric.Vinculum;

namespace Box2D.Samples; 

[SampleName("Simple Spawn idk")]
public class SpawnSample : Sample {
    private World _world;
    private Body _body;
    private Camera2D _camera2D = new();
    public override void Load() {
        _world = new World(new WorldDef {
            Gravity = Vector2.UnitY*9.31f*World.LengthUnitsPerMeter
        });
        _camera2D.zoom = 1f;
        SpawnBorders();
        SpawnBody();
    }

    private void SpawnBorders() {
        var size = new Vector2(GetRenderWidth(), GetRenderHeight());
        var solid = new BodyDef{Position = -size/2};
        var solidShape = new ShapeDef();
        var l = _world.CreateBody(solid);
        l.CreateSegmentShape(solidShape, new Segment(new Vector2(0, 0), new Vector2(0, size.Y)));
        l.CreateSegmentShape(solidShape, new Segment(new Vector2(0, size.Y), new Vector2(size.X, size.Y)));
        l.CreateSegmentShape(solidShape, new Segment(new Vector2(size.X, 0), new Vector2(size.X, size.Y)));
    }

    private void SpawnBody(Vector2 position) {
        var def = new BodyDef {
            AutomaticMass = true,
            Type = BodyType.Dynamic,
            Position = position
        };
        _body = _world.CreateBody(def);
        _body.CreateCircleShape(new ShapeDef(), new Circle(16f));
    }

    private void SpawnBody() => SpawnBody(Vector2.Zero);

    public override void Update() {
        _world.Step(1/60f, 4);
        _camera2D.offset = new Vector2(GetRenderWidth() / 2f, GetRenderHeight() / 2f);
        _camera2D.zoom += GetMouseWheelMove()*0.1f;
        if (IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT)) {
            SpawnBody(GetScreenToWorld2D(GetMousePosition(), _camera2D));
        }
    }

    public override unsafe void Draw() {
        Constants.debugDraw.UseDrawingBounds = false;
        BeginMode2D(_camera2D);
        _world.Draw(Constants.debugDraw);
        EndMode2D();
    }

    public override void Destroy() {
        _world.Dispose();
    }
}