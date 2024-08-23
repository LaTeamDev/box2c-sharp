using Box2D.Interop;

namespace Box2D; 

public class Filter : B2Object<b2Filter> {
    public Filter(b2Filter id) : base(id) { }
    public Filter() : this(new b2Filter()) { }

    public uint CategoryBits {
        get => _id.categoryBits;
        set => _id.categoryBits = value;
    }

    public uint MaskBits {
        get => _id.maskBits;
        set => _id.maskBits = value;
    }

    public int GroupIndex {
        get => _id.groupIndex;
        set => _id.groupIndex = value;
    }

    public override bool IsValid => true;
    
    public static implicit operator Filter(b2Filter o) => new(o);
    public Filter<TEnum> For<TEnum>() where TEnum : Enum {
        return new Filter<TEnum>(_id);
    }
}

public class Filter<TEnum> : Filter where TEnum : Enum {
    public Filter(b2Filter id) : base(id) { }

    public TEnum Category {
        get => (TEnum) Enum.ToObject(typeof(TEnum), CategoryBits);
        set => CategoryBits = Convert.ToUInt32(value);
    }

    public TEnum Mask {
        get => (TEnum) Enum.ToObject(typeof(TEnum), MaskBits);
        set => CategoryBits = Convert.ToUInt32(value);
    }
}