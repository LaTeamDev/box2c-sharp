namespace Box2D.Interop;

public unsafe partial struct b2DynamicTree
{
    public b2TreeNode* nodes;

    [NativeTypeName("int32_t")]
    public int root;

    [NativeTypeName("int32_t")]
    public int nodeCount;

    [NativeTypeName("int32_t")]
    public int nodeCapacity;

    [NativeTypeName("int32_t")]
    public int freeList;

    [NativeTypeName("int32_t")]
    public int proxyCount;

    [NativeTypeName("int32_t *")]
    public int* leafIndices;

    public b2AABB* leafBoxes;

    public b2Vec2* leafCenters;

    [NativeTypeName("int32_t *")]
    public int* binIndices;

    [NativeTypeName("int32_t")]
    public int rebuildCapacity;
}
