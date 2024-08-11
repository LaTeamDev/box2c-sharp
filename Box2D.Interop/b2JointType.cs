namespace Box2D.Interop;

[NativeTypeName("unsigned int")]
public enum b2JointType : uint
{
    b2_distanceJoint,
    b2_motorJoint,
    b2_mouseJoint,
    b2_prismaticJoint,
    b2_revoluteJoint,
    b2_weldJoint,
    b2_wheelJoint,
}
