using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Box2D.Interop;
using ZeroElectric.Vinculum;

namespace Box2D.Samples; 

[SampleName("Simple Stack idk")]
public class StackSample : Sample {
    private World _world;
    public override void Load() {
        _world = new World(); //Create with default settings
        var lol = B2.DefaultBodyDef();
        var def = new BodyDef();
        _world.CreateBody(def);
    }

    public override void Update() {
        _world.Step(1/60f, 4);
    }

    public override unsafe void Draw() {
        _world.Draw(Constants.debugDraw);
    }

    public override void Destroy() {
        _world.Dispose();
    }
}