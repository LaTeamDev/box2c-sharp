using System.Numerics;
using Box2D.Interop;
using ZeroElectric.Vinculum;

namespace Box2D; 

public abstract class Sample {
    public World World;
    private Camera2D _camera2D = new();
    private MouseJoint? _mouseJoint;
    public virtual void Load() {
        World = new World(new WorldDef {
            Gravity = Vector2.UnitY*9.31f*World.LengthUnitsPerMeter
        });
        _camera2D.zoom = 1f;
        SpawnBorders();

    }

    private void SpawnBorders() {
        var size = new Vector2(GetRenderWidth(), GetRenderHeight());
        var solid = new BodyDef{Position = -size/2};
        var solidShape = new ShapeDef();
        var l = World.CreateBody(solid);
        l.CreateSegmentShape(solidShape, new Segment(new Vector2(0, 0), new Vector2(0, size.Y)));
        l.CreateSegmentShape(solidShape, new Segment(new Vector2(0, size.Y), new Vector2(size.X, size.Y)));
        l.CreateSegmentShape(solidShape, new Segment(new Vector2(size.X, 0), new Vector2(size.X, size.Y)));
    }

    private class QueryContext {
        public Vector2 Point;
        public Body? Body;
    }

    private unsafe World.OverlapResultFcn<QueryContext> QueryCallback = (Shape shape, ref QueryContext context) => {
        var body = shape.Body;
        var bodyType = body.Type;
        if (bodyType != BodyType.Dynamic) {
            // continue query
            return true;
        }

        var overlap = shape.TestPoint(context.Point);
        if (!overlap) return true;
        // found shape
        context.Body = body;
        return false;
    };

    private Body? _groundBodyId;

    private void SpawnJoint(Vector2 p)
    {
        if (_mouseJoint is not null) return;
        if (!IsMouseButtonDown(MouseButton.MOUSE_BUTTON_RIGHT)) return;
        
        // Make a small box.
        AABB box;
        var d = new Vector2( 0.001f, 0.001f );
        box.LowerBound = p - d;
        box.UpperBound = p + d;

        // Query the world for overlapping shapes.
        var queryContext = new QueryContext {Point = p, Body = null };
        World.OverlapAABB(box, new b2QueryFilter(), QueryCallback, ref queryContext);

        if (queryContext.Body is null) return;
        
        var bodyDef = new BodyDef();
        _groundBodyId = World.CreateBody(bodyDef);

        var mouseDef = new MouseJointDef();
        mouseDef.BodyA = _groundBodyId;
        mouseDef.BodyB = queryContext.Body;
        mouseDef.Target = p;
        mouseDef.Hertz = 5.0f;
        mouseDef.DampingRatio = 0.7f;
        mouseDef.MaxForce = 1000.0f * queryContext.Body.Mass * World.LengthUnitsPerMeter;
        _mouseJoint = World.CreateMouseJoint(mouseDef);
        queryContext.Body.IsAwake = true;
    }

    private void RemoveJoint() {
        if (_mouseJoint == null) return;
        if (_mouseJoint.IsValid == false )
        {
            _mouseJoint = null;
        }

        if (IsMouseButtonDown(MouseButton.MOUSE_BUTTON_RIGHT)) return;
        
        _mouseJoint?.Dispose();
        _mouseJoint = null;

        _groundBodyId?.Dispose();
        _groundBodyId = null;
    }

    private void MoveJoint(Vector2 p) {
        if (_mouseJoint == null) return;
        if (!_mouseJoint.IsValid) return;
        _mouseJoint.Target = p;
        _mouseJoint.BodyB.IsAwake = true;
    }

    private void UpdateJoint(Vector2 p) {
        SpawnJoint(p);
        MoveJoint(p);
        RemoveJoint();
    }

    public Vector2 MouseWorldPos;
    public virtual void Update() {
        World.Step(1/60f, 4);
        _camera2D.offset = new Vector2(GetRenderWidth() / 2f, GetRenderHeight() / 2f);
        _camera2D.zoom += GetMouseWheelMove()*0.1f;
        MouseWorldPos = GetScreenToWorld2D(GetMousePosition(), _camera2D);
        UpdateJoint(MouseWorldPos);
    }


    public static List<Sample> All = new();

    public static void Register(Sample sample) {
        All.Add(sample);
    }

    public virtual unsafe void Draw() {
        Constants.debugDraw.UseDrawingBounds = false;
        BeginMode2D(_camera2D);
        World.Draw(Constants.debugDraw);
        EndMode2D();
    }

    public virtual void Destroy() {
        World.Dispose();
    }
}