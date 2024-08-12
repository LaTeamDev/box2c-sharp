namespace Box2D;

public partial struct Rotation
{
    public float C;

    public float S;
    
    public Rotation Identity => new Rotation {C=1f, S=0f};
}
