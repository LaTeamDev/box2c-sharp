namespace Box2D; 

public class SampleNameAttribute : Attribute {
    public string Name;

    public SampleNameAttribute(string name) {
        Name = name;
    }
}