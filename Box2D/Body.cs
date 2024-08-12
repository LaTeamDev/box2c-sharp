using System.Numerics;
using Box2D.Interop;

namespace Box2D; 

public class Body : IDisposable {
    private b2BodyId _id;
    public Body(b2BodyId id) {
        _id = id;
    }

    public void Dispose() {
        B2.DestroyBody(_id);
    }
    
    public bool IsValid => B2.Body_IsValid(_id);

    public BodyType Type {
        get => (BodyType)B2.Body_GetType(_id);
        set => B2.Body_SetType(_id, (b2BodyType)value);
    }

    public unsafe object? UserData {
        get => *(object?*)B2.Body_GetUserData(_id);
        set => B2.Body_SetUserData(_id, &value);
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
    public MassData MassData => (MassData)(object)B2.Body_GetMassData(_id);//will it work? TODO: add setter

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

    public bool Awake {
        get => B2.Body_IsAwake(_id);
        set => B2.Body_SetAwake(_id, value);
    }
}