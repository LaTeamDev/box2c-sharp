using System.Numerics;

namespace Box2D;

public partial struct Circle
{
    public Vector2 Center;
    public float Radius;

    public Circle(Vector2 center, float radius) {
        Center = center;
        Radius = radius;
    }

    public Circle(float radius) {
        Radius = radius;
    }
}
