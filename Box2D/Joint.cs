using Box2D.Interop;

namespace Box2D; 

public class Joint {
    internal b2JointId _id;

    public Joint(b2JointId id) {
        _id = id;
    }
}