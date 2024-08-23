using System.Numerics;
using System.Runtime.InteropServices;
using ZeroElectric.Vinculum;

namespace Box2D;

public class SampleWindow : Window {
    public override int? TargetFps => 60;
    
    public int CurrentSampleIndex = -1;
    public Sample? CurrentSample => 
        CurrentSampleIndex < Sample.All.Count && 
        CurrentSampleIndex >= 0 ? 
            Sample.All[CurrentSampleIndex] : null;
    public override void Load() {
        World.LengthUnitsPerMeter = 128f;
        Sample.Register(new Samples.SpawnSample());
        Sample.Register(new Samples.MaskedSpawn());
        CurrentSample?.Load();
        _sampleList.Position = Vector2.One * 32f;
        _sampleList.Size = new Vector2(256f, GetScreenHeight() - 64f);
        _sampleList.OnSampleSelected += (sample, i) => {
            CurrentSample?.Destroy();
            CurrentSampleIndex = i;
            CurrentSample?.Load();
        };
    }

    private SampleListVirtualWindow _sampleList = new();
    public override unsafe void Draw() {
        ClearBackground(BLACK);
        CurrentSample?.Draw();
        DrawText(CurrentSample?.GetType().Name??"None", 0, 0, 10f, WHITE);
        _sampleList.Draw();
    }

    public override void Update() {
        CurrentSample?.Update();
        _sampleList.Update();
    }
}