using System.Reflection;
using ZeroElectric.Vinculum;

namespace Box2D; 

public class SampleListVirtualWindow : VirtualWindow {
    private float _buttonSize = 24f;
    private float _buttonSpacing = 4f;

    public SampleListVirtualWindow() {
        Title = "Samples";
    }
    public override void DrawContent() {
        var idx = 0;
        foreach (var sample in Sample.All) {
            var name = sample.GetType().Name;
            var nameAttr = sample.GetType().GetCustomAttribute(typeof(SampleNameAttribute));
            if (nameAttr is not null) {
                name = ((SampleNameAttribute) nameAttr).Name;
            }

            var test = MeasureTextEx(GetFontDefault(), name, 12, 0f);
            if (RayGui.GuiButton(
                    new Rectangle(Position.X + 8f, Position.Y + 24f + 8f + (_buttonSpacing + _buttonSize) * idx,
                        test.X + 12f,
                        _buttonSize), name) != 0) {
                OnSampleSelected?.Invoke(sample, idx);
            };
            idx++;
        }
        //RayGui.GuiLabel(new Rectangle(Position.X + 16f, Position.Y + 32f, 128f, 12f), "fuck");
    }

    public event Action<Sample, int>? OnSampleSelected;
}