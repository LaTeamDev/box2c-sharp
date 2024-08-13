using System.Numerics;
using Box2D.Interop;

namespace Box2D; 

public class Shape : IDisposable, IShape {
    internal readonly b2ShapeId _id;

    public Shape(b2ShapeId id) {
        _id = id;
    }
    
    public void Dispose() {
        B2.DestroyShape(_id);
    }
    
    public override int GetHashCode() => _id.GetHashCode();
    public override bool Equals(object? obj)
    {
        if (obj is not Shape body)
            return false;
        return _id.Equals(body._id);
    }

    public bool IsValid => B2.Shape_IsValid(_id);
    public ShapeType Type => (ShapeType) B2.Shape_GetType(_id);
    public Body Body => new Body(B2.Shape_GetBody(_id)); // is this will work well???
    public bool IsSensor => B2.Shape_IsSensor(_id);
    public unsafe object? UserData {
        get => *(object?*)B2.Shape_GetUserData(_id);
        set => B2.Shape_SetUserData(_id, &value);
    }

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

    public b2Filter Filter {
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

    public Circle Circle {
        get => B2.Shape_GetCircle(_id);
        set => B2.Shape_SetCircle(_id, ref value);
    }

    public Segment Segment {
        get => B2.Shape_GetSegment(_id);
        set => B2.Shape_SetSegment(_id, ref value);
    }

    public b2SmoothSegment SmoothSegment {
        get => B2.Shape_GetSmoothSegment(_id);
    }

    public Polygon Polygon {
        get => B2.Shape_GetPolygon(_id);
        set => B2.Shape_SetPolygon(_id, ref value);
    }

    public Capsule Capsule {
        get => B2.Shape_GetCapsule(_id);
        set => B2.Shape_SetCapsule(_id, ref value);
    }

    public b2ChainId ParentChain {
        get => B2.Shape_GetParentChain(_id);
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