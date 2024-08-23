using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Box2D.Interop;

namespace Box2D; 

public class Body : B2Object<b2BodyId>, IBody {
    public Body(b2BodyId id) : base(id) { }
    
    public static implicit operator Body(b2BodyId o) => new(o);

    public override void Dispose() {
        base.Dispose();
        B2.DestroyBody(_id);
    }

    public override bool IsValid => B2.Body_IsValid(_id);

    public BodyType Type {
        get => (BodyType)B2.Body_GetType(_id);
        set => B2.Body_SetType(_id, (b2BodyType)value);
    }

    public Vector2 Position {
        get => B2.Body_GetPosition(_id);
        set => B2.Body_SetTransform(_id, value, Rotation);
    }

    public Rotation Rotation {
        get => B2.Body_GetRotation(_id);
        set => B2.Body_SetTransform(_id, Position, Rotation);
    }

    public Transform Transform {
        get => B2.Body_GetTransform(_id);
        set => B2.Body_SetTransform(_id, value.Position, value.Rotation);
    }

    public Vector2 GetLocalPoint(Vector2 worldPoint) {
        return B2.Body_GetLocalPoint(_id, worldPoint);
    }

    public Vector2 GetWorldPoint(Vector2 localPoint) {
        return B2.Body_GetWorldPoint(_id, localPoint);
    }

    public Vector2 GetLocalVector(Vector2 worldVector) {
        return B2.Body_GetLocalVector(_id, worldVector);
    }
    
    public Vector2 GetWorldVector(Vector2 localVector) {
        return B2.Body_GetWorldVector(_id, localVector);
    }

    public Vector2 LinearVelocity {
        get => B2.Body_GetLinearVelocity(_id);
        set => B2.Body_SetLinearVelocity(_id, value);
    }
    
    public float AngularVelocity {
        get => B2.Body_GetAngularVelocity(_id);
        set => B2.Body_SetAngularVelocity(_id, value);
    }

    public void ApplyForce(Vector2 force, Vector2 point, bool wake = true) =>
        B2.Body_ApplyForce(_id, force, point, wake);
    
    public void ApplyForce(Vector2 force, bool wake = true) =>
        B2.Body_ApplyForceToCenter(_id, force, wake);

    public void ApplyTorque(float torque, bool wake = true) =>
        B2.Body_ApplyTorque(_id, torque, wake);
    
    public void ApplyLinearImpulse(Vector2 impulse, Vector2 point, bool wake = true) =>
        B2.Body_ApplyLinearImpulse(_id, impulse, point, wake);
    
    public void ApplyLinearImpulse(Vector2 impulse, bool wake = true) =>
        B2.Body_ApplyLinearImpulseToCenter(_id, impulse, wake);
    
    public void ApplyAngularImpulse(float impulse, bool wake = true) =>
        B2.Body_ApplyAngularImpulse(_id, impulse, wake);

    public float Mass => B2.Body_GetMass(_id);
    public float InertiaTensor => B2.Body_GetInertiaTensor(_id);
    public Vector2 LocalCenterOfMass => B2.Body_GetLocalCenterOfMass(_id);
    public Vector2 WorldCenterOfMass => B2.Body_GetWorldCenterOfMass(_id);

    public MassData MassData {
        get => new(B2.Body_GetMassData(_id));
        set => B2.Body_SetMassData(_id, value._massData);
    }

    public void ApplyMassFromShapes() =>
        B2.Body_ApplyMassFromShapes(_id);
    
    public bool AutomaticMass {
        get => B2.Body_GetAutomaticMass(_id);
        set => B2.Body_SetAutomaticMass(_id, value);
    }

    public float LinearDamping {
        get => B2.Body_GetLinearDamping(_id);
        set => B2.Body_SetLinearDamping(_id, value);
    }
    
    public float AngularDamping {
        get => B2.Body_GetAngularDamping(_id);
        set => B2.Body_SetAngularDamping(_id, value);
    }

    public float GravityScale {
        get => B2.Body_GetGravityScale(_id);
        set => B2.Body_SetGravityScale(_id, value);
    }

    public bool IsAwake {
        get => B2.Body_IsAwake(_id);
        set => B2.Body_SetAwake(_id, value);
    }

    public bool EnableSleep {
        get => B2.Body_IsSleepEnabled(_id);
        set => B2.Body_EnableSleep(_id, value);
    }

    public float SleepThreshold {
        get => B2.Body_GetSleepThreshold(_id);
        set => B2.Body_SetSleepThreshold(_id, value);
    }

    public bool IsEnabled {
        get => B2.Body_IsEnabled(_id);
        set { if (value) B2.Body_Enable(_id); else B2.Body_Disable(_id); }
    }

    public bool FixedRotation {
        get => B2.Body_IsFixedRotation(_id);
        set => B2.Body_SetFixedRotation(_id, value);
    }

    public bool IsBullet {
        get => B2.Body_IsBullet(_id);
        set => B2.Body_SetBullet(_id, value);
    }

    public bool HitEvents {
        set => B2.Body_EnableHitEvents(_id, value);
    }

    public int ShapeCount => B2.Body_GetShapeCount(_id);

    public List<Shape> GetShapes() {
        var array = new b2ShapeId[ShapeCount];
        var count = B2.Body_GetShapes(_id, ref array);
        var stuff = array.ToList().GetRange(0, count);
        return stuff.Select(shapeId => new Shape(shapeId)).ToList();
    }

    public int JointCount => B2.Body_GetJointCount(_id);
    
    public List<Joint> GetJoints() {
        var array = new b2JointId[JointCount];
        var count = B2.Body_GetJoints(_id, ref array);
        var stuff = array.ToList().GetRange(0, count);
        return stuff.Select(jointId => new Joint(jointId)).ToList();
    }

    public int ContactCapacity => B2.Body_GetContactCapacity(_id);

    public List<ContactData> GetContactData() {
        var array = new b2ContactData[ContactCapacity];
        var count = B2.Body_GetContactData(_id, ref array);
        var stuff = array.ToList().GetRange(0, count);
        return stuff.Select(contactData => new ContactData(contactData)).ToList();
    }

    public AABB ComputeAABB() => B2.Body_ComputeAABB(_id);

    public Shape CreateCircleShape(ShapeDef def, Circle circle) {
        return new Shape(B2.CreateCircleShape(_id,  ref def._def, ref circle));
    }

    public Shape CreateSegmentShape(ShapeDef def, Segment segment) {
        return new Shape(B2.CreateSegmentShape(_id,  ref def._def, ref segment));
    }
    
    public Shape CreateCapsuleShape(ShapeDef def, Capsule capsule) {
        return new Shape(B2.CreateCapsuleShape(_id,  ref def._def, ref capsule));
    }
    
    public Shape CreatePolygonShape(ShapeDef def, Polygon polygon) {
        return new Shape(B2.CreatePolygonShape(_id,  ref def._def, ref polygon));
    }

    public Chain CreateChain(ChainDef def) =>
        new(B2.CreateChain(_id, ref def._def));
}