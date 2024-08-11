namespace Box2D.Interop;

[NativeTypeName("unsigned int")]
public enum b2BodyType : uint
{
    b2_staticBody = 0,
    b2_kinematicBody = 1,
    b2_dynamicBody = 2,
    b2_bodyTypeCount,
}
