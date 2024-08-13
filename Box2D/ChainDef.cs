using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Box2D.Interop;

namespace Box2D; 

public sealed class ChainDef : Def<b2ChainDef> {
    public unsafe object? UserData {
        get => *(object?*)_def.userData;
        set => _def.userData = Unsafe.AsPointer(ref value);
    }

    public unsafe Span<Vector2> Points {
        get => new(_def.points, _def.count*sizeof(Vector2));
        set {
            _def.points = *(Vector2**)&value;
            _def.count = value.Length;
        }
    }
    
    public float Friction {
        get => _def.friction;
        set => _def.friction = value;
    }

    public float Restitution {
        get => _def.restitution;
        set => _def.restitution = value;
    }

    public b2Filter Filter {
        get => _def.filter;
        set => _def.filter = value;
    }

    public bool IsLoop {
        get => _def.isLoop;
        set => _def.isLoop = value;
    }
}