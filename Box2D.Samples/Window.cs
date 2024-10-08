using ZeroElectric.Vinculum;

namespace Box2D; 

public abstract class Window {
    public virtual int Width => 800;
    public virtual int Height => 450;
    public virtual string Title => "Untitled";
    public virtual int? TargetFps => null;

    public abstract void Load();

    public abstract void Draw();

    public abstract void Update();

    public void Run() {
        SetConfigFlags(ConfigFlags.FLAG_MSAA_4X_HINT);
        SetConfigFlags(ConfigFlags.FLAG_WINDOW_RESIZABLE);
        InitWindow(Width, Height, Title);
        if (TargetFps is not null) SetTargetFPS(TargetFps??0);
        Load();
        while (!WindowShouldClose())
        {
            Update();
            BeginDrawing();
            Draw();
            EndDrawing();
        }
        CloseWindow();
    }
}