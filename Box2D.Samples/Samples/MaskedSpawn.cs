using System.Numerics;
using ZeroElectric.Vinculum;

namespace Box2D.Samples; 

public class MaskedSpawn : Sample {
    private Body _body;

    [Flags]
    private enum Filter : uint {
        None = 0,
        Walls = 1u << 0,
        One = 1u << 1,
        Another = 1u << 2,
        All = Walls | One | Another
    }
    
    private void SpawnBody(Vector2 position, Filter filter) {
        var def = new BodyDef {
            AutomaticMass = true,
            Type = BodyType.Dynamic,
            Position = position
        };
        _body = World.CreateBody(def);
        _body.CreateCircleShape(new ShapeDef {
            Filter = new Filter<Filter> {
                Category = filter,
                Mask = Filter.All ^ filter
            }
        }, new Circle(16f));
    }

    public override void Update() {
        base.Update();
        if (IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT)) {
            SpawnBody(MouseWorldPos, IsKeyDown(KeyboardKey.KEY_LEFT_SHIFT) ? Filter.One : Filter.Another);
        }
    }
}