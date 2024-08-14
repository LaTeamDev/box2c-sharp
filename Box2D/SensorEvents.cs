using Box2D.Interop;

namespace Box2D; 

public class SensorEvents {
    public class Event {
        public Shape SensorShape;
        public Shape VisitorShape;
    }
    public class BeginTouchEvent : Event { }
    public class EndTouchEvent : Event { }
    
    public unsafe SensorEvents(b2SensorEvents sensorEvents) {
        var beginEvents =
            new ReadOnlySpan<b2SensorBeginTouchEvent>(sensorEvents.beginEvents, sensorEvents.beginCount); //Should i make helpers like this in interop?
        var endEvents =
            new ReadOnlySpan<b2SensorBeginTouchEvent>(sensorEvents.endEvents, sensorEvents.endCount);
        foreach (var beginEvent in beginEvents) {
            BeginEvents.Add(new BeginTouchEvent {
                SensorShape = new(beginEvent.sensorShapeId),
                VisitorShape = new(beginEvent.visitorShapeId)
            });
        }
        foreach (var endEvent in endEvents) {
            EndEvents.Add(new EndTouchEvent {
                SensorShape = new(endEvent.sensorShapeId),
                VisitorShape = new(endEvent.visitorShapeId)
            });
        }
    }

    public List<BeginTouchEvent> BeginEvents = new();
    public List<EndTouchEvent> EndEvents = new();
}