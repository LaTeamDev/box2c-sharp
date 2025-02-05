using System.Numerics;
using Box2D.Interop;

namespace Box2D; 

public abstract class Shape : B2Object<b2ShapeId>, IShape {
    public unsafe Shape(b2ShapeId id) : base(id) {
        var udata = B2.Shape_GetUserData(id);
        if (udata is not null) {
            throw new Exception($"Shape {id.index1} has already userdata! have you used native functions?");
        }
        B2.Shape_SetUserData(id, (void*)this.Pin().Pointer);
    }
    
    public static unsafe implicit operator Shape(b2ShapeId o) {
        var udata = B2.Shape_GetUserData(o);
        if (udata is null) throw new Exception();
        var pin = new Pin<Shape>(udata);
        return pin.Target;
    }
    
    public override void Dispose(bool disposing) {
        if (!disposing) return;
        B2.DestroyShape(_id);
    }
    
    public object? UserData { get; set; }
    
    public override int GetHashCode() => _id.GetHashCode();
    public override bool Equals(object? obj)
    {
        if (obj is not Shape body)
            return false;
        return _id.Equals(body._id);
    }

    public override bool IsValid => B2.Shape_IsValid(_id);
    public ShapeType Type => (ShapeType) B2.Shape_GetType(_id);
    public Body Body => B2.Shape_GetBody(_id);
    public bool IsSensor => B2.Shape_IsSensor(_id);
    public float Density {
        get => B2.Shape_GetDensity(_id);
        set => B2.Shape_SetDensity(_id, value);
    }
    
    public float Friction {
        get => B2.Shape_GetFriction(_id);
        set => B2.Shape_SetFriction(_id, value);
    }

    public float Restitution {
        get => B2.Shape_GetRestitution(_id);
        set => B2.Shape_SetRestitution(_id, value);
    }

    public Filter Filter {
        get => B2.Shape_GetFilter(_id);
        set => B2.Shape_SetFilter(_id, value);
    }

    public bool EnableSensorEvents {
        get => B2.Shape_AreSensorEventsEnabled(_id);
        set => B2.Shape_EnableSensorEvents(_id, value);
    }

    public bool EnableContactEvents {
        get => B2.Shape_AreContactEventsEnabled(_id);
        set => B2.Shape_EnableContactEvents(_id, value);
    }

    public bool EnablePreSolveEvents {
        get => B2.Shape_ArePreSolveEventsEnabled(_id);
        set => B2.Shape_EnablePreSolveEvents(_id, value);
    }

    public bool EnableHitEvents {
        get => B2.Shape_AreHitEventsEnabled(_id);
        set => B2.Shape_EnableHitEvents(_id, value);
    }

    public bool TestPoint(Vector2 point) =>
        B2.Shape_TestPoint(_id, point);

    public b2CastOutput RayCast(Vector2 origin, Vector2 translation) =>
        B2.Shape_RayCast(_id, origin, translation);

    public Chain? ParentChain {
        get {
            var shapeId = B2.Shape_GetParentChain(_id);
            if (shapeId.Equals(B2.b2_nullChainId)) return null;
            return shapeId;
        }
    }

    public int GetContactCapacity() => B2.Shape_GetContactCapacity(_id);

    public List<ContactData> GetContactData() {
        var array = new b2ContactData[GetContactCapacity()];
        var count = B2.Shape_GetContactData(_id, ref array);
        var stuff = array.ToList().GetRange(0, count);
        return stuff.Select(contactData => new ContactData(contactData)).ToList();
    }

    public AABB AABB {
        get => B2.Shape_GetAABB(_id);
    }

    public Vector2 GetClosestPoint(Vector2 target) =>
        B2.Shape_GetClosestPoint(_id, target);
}