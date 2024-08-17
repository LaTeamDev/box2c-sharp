using Box2D.Interop;

namespace Box2D; 

//TODO:
public class ContactData : B2Object<b2ContactData> {
    public ContactData(b2ContactData id) : base(id) { }
    public override bool IsValid { get; }
}