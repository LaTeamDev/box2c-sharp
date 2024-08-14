using System.Numerics;
using Box2D.Interop;

namespace Box2D; 

public class ContactEvents {
    public class Event {
        public Shape ShapeA;
        public Shape ShapeB;
    }
    public class BeginTouchEvent : Event { }
    public class EndTouchEvent : Event { }
    public class HitEvent : Event {
        public Vector2 Point;
        public Vector2 Normal;
        public float ApproachSpeed;
    }
    
    public unsafe ContactEvents(b2ContactEvents contactEvents) {
        var beginEvents =
            new ReadOnlySpan<b2ContactBeginTouchEvent>(contactEvents.beginEvents, contactEvents.beginCount); //Should i make helpers like this in interop?
        var endEvents =
            new ReadOnlySpan<b2ContactEndTouchEvent>(contactEvents.endEvents, contactEvents.endCount);
        var hitEvents =
            new ReadOnlySpan<b2ContactHitEvent>(contactEvents.hitEvents, contactEvents.hitCount);
        foreach (var beginEvent in beginEvents) {
            BeginEvents.Add(new BeginTouchEvent {
                ShapeA = new(beginEvent.shapeIdA),
                ShapeB = new(beginEvent.shapeIdB)
            });
        }
        foreach (var endEvent in endEvents) {
            EndEvents.Add(new EndTouchEvent {
                ShapeA = new(endEvent.shapeIdA),
                ShapeB = new(endEvent.shapeIdB)
            });
        }
        foreach (var hitEvent in hitEvents) {
            HitEvents.Add(new HitEvent {
                ShapeA = new(hitEvent.shapeIdA),
                ShapeB = new(hitEvent.shapeIdB),
                Point =  hitEvent.point,
                ApproachSpeed = hitEvent.approachSpeed
            });
        }
    }

    public List<BeginTouchEvent> BeginEvents = new();
    public List<EndTouchEvent> EndEvents = new();
    public List<HitEvent> HitEvents = new();
}