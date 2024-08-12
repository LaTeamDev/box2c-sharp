using Box2D.Interop;

namespace Box2D; 

public class ContactData {
    internal b2ContactData _id;

    public ContactData(b2ContactData id) {
        _id = id;
    }
}