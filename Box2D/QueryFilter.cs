using Box2D.Interop;

namespace Box2D; 

public class QueryFilter : B2Object<b2QueryFilter> {
    public QueryFilter(b2QueryFilter id) : base(id) { }
    public QueryFilter() : this(new b2QueryFilter()) { }

    public uint CategoryBits {
        get => _id.categoryBits;
        set => _id.categoryBits = value;
    }

    public uint MaskBits {
        get => _id.maskBits;
        set => _id.maskBits = value;
    }

    public override bool IsValid => true;
    
    public static implicit operator QueryFilter(b2QueryFilter o) => new(o);
    public QueryFilter<TEnum> For<TEnum>() where TEnum : Enum {
        return new QueryFilter<TEnum>(_id);
    }
}

public class QueryFilter<TEnum> : QueryFilter where TEnum : Enum {
    public QueryFilter() : this(new b2QueryFilter()) { }
    public QueryFilter(b2QueryFilter id) : base(id) { }

    public TEnum Category {
        get => (TEnum) Enum.ToObject(typeof(TEnum), CategoryBits);
        set => CategoryBits = Convert.ToUInt32(value);
    }

    public TEnum Mask {
        get => (TEnum) Enum.ToObject(typeof(TEnum), MaskBits);
        set => MaskBits = Convert.ToUInt32(value);
    }
}