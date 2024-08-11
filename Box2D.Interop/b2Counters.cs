namespace Box2D.Interop;

public unsafe partial struct b2Counters
{
    [NativeTypeName("int32_t")]
    public int staticBodyCount;

    [NativeTypeName("int32_t")]
    public int bodyCount;

    [NativeTypeName("int32_t")]
    public int shapeCount;

    [NativeTypeName("int32_t")]
    public int contactCount;

    [NativeTypeName("int32_t")]
    public int jointCount;

    [NativeTypeName("int32_t")]
    public int islandCount;

    [NativeTypeName("int32_t")]
    public int stackUsed;

    [NativeTypeName("int32_t")]
    public int staticTreeHeight;

    [NativeTypeName("int32_t")]
    public int treeHeight;

    [NativeTypeName("int32_t")]
    public int byteCount;

    [NativeTypeName("int32_t")]
    public int taskCount;

    [NativeTypeName("int32_t[12]")]
    public fixed int colorCounts[12];
}
