using NUnit.Framework;
using System;
using static Box2D.Interop.B2;

namespace Box2D.Interop.UnitTests;

/// <summary>Provides validation of the <see cref="B2" /> class.</summary>
public static unsafe partial class B2Tests
{
    /// <summary>Validates that the value of the <see cref="b2_emptyDistanceCache" /> property is correct.</summary>
    [Test]
    public static void b2_emptyDistanceCacheTest()
    {
        Assert.That(b2_emptyDistanceCache.count, Is.EqualTo(0));
        Assert.That(b2_emptyDistanceCache.indexA, Is.EqualTo(default));
        Assert.That(b2_emptyDistanceCache.indexB, Is.EqualTo(default));
    }

    /// <summary>Validates that the value of the <see cref="b2_nullWorldId" /> property is correct.</summary>
    [Test]
    public static void b2_nullWorldIdTest()
    {
        Assert.That(b2_nullWorldId.index1, Is.EqualTo(0));
        Assert.That(b2_nullWorldId.revision, Is.EqualTo(default));
    }

    /// <summary>Validates that the value of the <see cref="b2_nullBodyId" /> property is correct.</summary>
    [Test]
    public static void b2_nullBodyIdTest()
    {
        Assert.That(b2_nullBodyId.index1, Is.EqualTo(0));
        Assert.That(b2_nullBodyId.world0, Is.EqualTo(default));
        Assert.That(b2_nullBodyId.revision, Is.EqualTo(default));
    }

    /// <summary>Validates that the value of the <see cref="b2_nullShapeId" /> property is correct.</summary>
    [Test]
    public static void b2_nullShapeIdTest()
    {
        Assert.That(b2_nullShapeId.index1, Is.EqualTo(0));
        Assert.That(b2_nullShapeId.world0, Is.EqualTo(default));
        Assert.That(b2_nullShapeId.revision, Is.EqualTo(default));
    }

    /// <summary>Validates that the value of the <see cref="b2_nullJointId" /> property is correct.</summary>
    [Test]
    public static void b2_nullJointIdTest()
    {
        Assert.That(b2_nullJointId.index1, Is.EqualTo(0));
        Assert.That(b2_nullJointId.world0, Is.EqualTo(default));
        Assert.That(b2_nullJointId.revision, Is.EqualTo(default));
    }

    /// <summary>Validates that the value of the <see cref="b2_nullChainId" /> property is correct.</summary>
    [Test]
    public static void b2_nullChainIdTest()
    {
        Assert.That(b2_nullChainId.index1, Is.EqualTo(0));
        Assert.That(b2_nullChainId.world0, Is.EqualTo(default));
        Assert.That(b2_nullChainId.revision, Is.EqualTo(default));
    }
}
