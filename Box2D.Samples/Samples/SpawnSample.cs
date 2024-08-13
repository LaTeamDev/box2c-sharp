// this files contains some ported code from Box2D 3.0 samples
// MIT License
//
// Copyright (c) 2022 Erin Catto
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

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
    private MouseJoint? _mouseJoint;
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
        _world.OverlapAABB(box, new b2QueryFilter(), QueryCallback, ref queryContext);

        if (queryContext.Body is null) return;
        
        var bodyDef = new BodyDef();
        _groundBodyId = _world.CreateBody(bodyDef);

        var mouseDef = new MouseJointDef();
        mouseDef.BodyA = _groundBodyId;
        mouseDef.BodyB = queryContext.Body;
        mouseDef.Target = p;
        mouseDef.Hertz = 5.0f;
        mouseDef.DampingRatio = 0.7f;
        mouseDef.MaxForce = 1000.0f * queryContext.Body.Mass * World.LengthUnitsPerMeter;
        _mouseJoint = _world.CreateMouseJoint(mouseDef);
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

    public override void Update() {
        _world.Step(1/60f, 4);
        _camera2D.offset = new Vector2(GetRenderWidth() / 2f, GetRenderHeight() / 2f);
        _camera2D.zoom += GetMouseWheelMove()*0.1f;
        var mouseWorldPos = GetScreenToWorld2D(GetMousePosition(), _camera2D);
        if (IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT)) {
            SpawnBody(mouseWorldPos);
        }
        UpdateJoint(mouseWorldPos);
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