using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Box2D.Interop;

public unsafe partial struct b2TreeNode
{
    [NativeTypeName("b2AABB")]
    public AABB aabb;

    [NativeTypeName("uint32_t")]
    public uint categoryBits;

    [NativeTypeName("__AnonymousRecord_collision_L608_C2")]
    public _Anonymous_e__Union Anonymous;

    [NativeTypeName("int32_t")]
    public int child1;

    [NativeTypeName("int32_t")]
    public int child2;

    [NativeTypeName("int32_t")]
    public int userData;

    [NativeTypeName("int16_t")]
    public short height;

    [NativeTypeName("_Bool")]
    public bool enlarged;

    [NativeTypeName("char[9]")]
    public fixed sbyte pad[9];

    public ref int parent
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            fixed (_Anonymous_e__Union* pField = &Anonymous)
            {
                return ref pField->parent;
            }
        }
    }

    public ref int next
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            fixed (_Anonymous_e__Union* pField = &Anonymous)
            {
                return ref pField->next;
            }
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public partial struct _Anonymous_e__Union
    {
        [FieldOffset(0)]
        [NativeTypeName("int32_t")]
        public int parent;

        [FieldOffset(0)]
        [NativeTypeName("int32_t")]
        public int next;
    }
}
