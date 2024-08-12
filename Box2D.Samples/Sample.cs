namespace Box2D; 

public abstract class Sample {
    public abstract void Load();
    public abstract void Update();
    public abstract void Draw();

    public static List<Sample> All = new();

    public static void Register(Sample sample) {
        All.Add(sample);
    }

    public abstract void Destroy();
}