using Box2D.Interop;

namespace Box2D;

public partial struct Version
{
    public int Major;
    public int Minor;
    public int Revision;

    public static Version Get() => B2.GetVersion();
}
