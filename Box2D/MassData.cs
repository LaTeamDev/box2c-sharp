using System.Numerics;
using Box2D.Interop;

namespace Box2D; 

public struct MassData {
    internal b2MassData _massData;
    public float Mass {
        get => _massData.mass;
        set => _massData.mass = value;
    }

    public Vector2 Center {
        get => _massData.center;
        set => _massData.center = value;
    }

    public float RotationalInertia {
        get => _massData.rotationalInertia;
        set => _massData.rotationalInertia = value;
    }

    public MassData(b2MassData massData) {
        _massData = massData;
    }

    public MassData() { }
}