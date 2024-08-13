using Box2D.Interop;

namespace Box2D; 

public enum JointType : uint {
    Distance = b2JointType.b2_distanceJoint,
    Motor = b2JointType.b2_motorJoint,
    Mouse = b2JointType.b2_mouseJoint,
    Prismatic = b2JointType.b2_prismaticJoint,
    Revolute = b2JointType.b2_revoluteJoint,
    Weld = b2JointType.b2_weldJoint,
    Wheel = b2JointType.b2_wheelJoint
}