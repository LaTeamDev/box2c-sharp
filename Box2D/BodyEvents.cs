using System.Runtime.CompilerServices;
using Box2D.Interop;

namespace Box2D; 

public class BodyEvents {
    public class BodyMoveEvent {
        public Transform Transform;
        public Body Body;
        public object? UserData;
        public bool FellAsleep;
    }

    public unsafe BodyEvents(b2BodyEvents bodyEvents) {
        var moveEvents =
            new ReadOnlySpan<b2BodyMoveEvent>(bodyEvents.moveEvents, bodyEvents.moveCount); //Should i make helpers like this in interop?
        foreach (var moveEvent in moveEvents) {
            BodyMoveEvents.Add(new BodyMoveEvent {
                Transform = moveEvent.transform,
                Body = new(moveEvent.bodyId),
                UserData = *(object?*)moveEvent.userData,
                FellAsleep = moveEvent.fellAsleep
            });
        }
    }

    public List<BodyMoveEvent> BodyMoveEvents = new();
}