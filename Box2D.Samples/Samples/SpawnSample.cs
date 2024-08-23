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
    private Body _body;
    
    public override void Load() {
        base.Load();
        SpawnBody();
    }
    
    private void SpawnBody(Vector2 position) {
        var def = new BodyDef {
            AutomaticMass = true,
            Type = BodyType.Dynamic,
            Position = position
        };
        _body = World.CreateBody(def);
        _body.CreateCircleShape(new ShapeDef(), new Circle(16f));
    }

    private void SpawnBody() => SpawnBody(Vector2.Zero);

    public override void Update() {
        base.Update();
        if (IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT)) {
            SpawnBody(MouseWorldPos);
        }
    }
}