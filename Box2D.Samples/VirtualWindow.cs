using System.Numerics;
using ZeroElectric.Vinculum;

namespace Box2D; 

public abstract class VirtualWindow {
    public Vector2 Position;
    public Vector2 Size;
    public string Title = "Untitled";

    public virtual void Update() {
        
    }
    
    public void Draw() {
        RayGui.GuiScrollPanel(new Rectangle(Position.X, Position.Y, Size.X, Size.Y), Title, Content, ref Scroll,
            ref View);
        BeginScissorMode((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
            DrawContent();
        EndScissorMode();
    }

    public abstract void DrawContent();

    public Rectangle Content = new();
    public Rectangle View = new();
    public Vector2 Scroll;
}