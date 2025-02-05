namespace Box2D.Interop;

public partial struct b2BodyId : IEquatable<b2BodyId> {
    public bool Equals(b2BodyId other) {
        return index1 == other.index1 && world0 == other.world0 && revision == other.revision;
    }

    public override bool Equals(object? obj) {
        return obj is b2BodyId other && Equals(other);
    }

    public override int GetHashCode() {
        return HashCode.Combine(index1, world0, revision);
    }
}

public partial struct b2WorldId : IEquatable<b2WorldId> {
    public bool Equals(b2WorldId other) {
        return index1 == other.index1 && revision == other.revision;
    }

    public override bool Equals(object? obj) {
        return obj is b2WorldId other && Equals(other);
    }

    public override int GetHashCode() {
        return HashCode.Combine(index1, revision);
    }
}