namespace Box2D.Interop; 

public class Box2DAssertionException : Exception {
    internal Box2DAssertionException(string error) : base(error) { }
}