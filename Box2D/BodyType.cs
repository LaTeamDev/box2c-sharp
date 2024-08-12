using Box2D.Interop;

namespace Box2D; 

public enum BodyType : uint {
    Static = b2BodyType.b2_staticBody,
    Kinematic = b2BodyType.b2_kinematicBody, 
    Dynamic = b2BodyType.b2_dynamicBody
}