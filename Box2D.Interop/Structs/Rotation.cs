using System.Numerics;
using System.Runtime.InteropServices;

namespace Box2D;

public partial struct Rotation
{
    public float C;

    public float S;
    
    public static Rotation Identity => new Rotation {C=1f, S=0f};

    // Used code from https://github.com/erincatto/box2c/blob/main/include/box2d/math_functions.h
    public Rotation(float angle) {
        C = MathF.Cos(angle);
        S = MathF.Sin(angle);
    }

    public Rotation(float cos, float sin) {
        C = cos;
        S = sin;
    }

    public static Rotation Normalize(Rotation q) {
        var mag = MathF.Sqrt(q.S*q.S + q.C * q.C );
        var invMag = mag > 0.0 ? 1.0f / mag : 0.0f;
        return new(q.C * invMag, q.S * invMag);
    }
    
    public static bool IsNormalized(Rotation q) {
        // larger tolerance due to failure on mingw 32-bit <-- original commentary;
        // should we decrease tolerance in c#? TODO: investigate
        var qq = q.S * q.S + q.C * q.C;
        return qq is > 1.0f - 0.0006f and < 1.0f + 0.0006f;
    }
    /// https://fgiesen.wordpress.com/2012/08/15/linear-interpolation-past-present-and-future/
    public static Rotation Lerp(Rotation q1, Rotation q2, float t )
    {
        var omt = 1.0f - t;
        Rotation q = new(
            omt * q1.C + t * q2.C,
            omt * q1.S + t * q2.S
        );

        return Normalize(q);
    }
    /// Integration rotation from angular velocity
	///	@param q1 initial rotation
	///	@param deltaAngle the angular displacement in radians
	public static Rotation Integrate(Rotation q1, float deltaAngle )
	{
		var q2 = new Rotation( q1.C - deltaAngle * q1.S, q1.S + deltaAngle * q1.C );
		var mag = MathF.Sqrt( q2.S * q2.S + q2.C * q2.C );
		var invMag = mag > 0.0 ? 1.0f / mag : 0.0f;
		var qn = new Rotation( q2.C * invMag, q2.S * invMag );
		return qn;
	}

    /// Compute the angular velocity necessary to rotate between two rotations over a give time
    ///	@param q1 initial rotation
    ///	@param q2 final rotation
    ///	@param inv_h inverse time step
    public static float ComputeAngularVelocity(Rotation q1, Rotation q2, float inv_h) 
	    => inv_h * (q2.S * q1.C - q2.C * q1.S);

	/// Get the angle in radians in the range [-pi, pi]
	public float Angle => MathF.Atan2( S, C );
	public Vector2 XAxis => new(C, S);
	public Vector2 YAxis => new(-S, C);

	public static Rotation operator *(Rotation q, Rotation r) => Multiply(q, r);
	public static Rotation Multiply(Rotation q, Rotation r)
	{
		Rotation qr;
		qr.S = q.S * r.C + q.C * r.S;
		qr.C = q.C * r.C - q.S * r.S;
		return qr;
	}

	/// Transpose multiply two rotations: qT * r
	public static Rotation InverseMultiply(Rotation q, Rotation r )
	{
		Rotation qr;
		qr.S = q.C * r.S - q.S * r.C;
		qr.C = q.C * r.C + q.S * r.S;
		return qr;
	}

	/// relative angle between b and a (rot_b * inv(rot_a))
	public static float RelativeAngle( Rotation b, Rotation a )
	{
		var s = b.S * a.C - b.C * a.S;
		var c = b.C * a.C + b.S * a.S;
		return MathF.Atan2( s, c );
	}

	/// Convert an angle in the range [-2*pi, 2*pi] into the range [-pi, pi]
	public static float UnwindAngle( float angle )
	{
		if ( angle < -MathF.PI )
			return angle + 2.0f * MathF.PI;
		if ( angle > MathF.PI )
			return angle - 2.0f * MathF.PI;

		return angle;
	}
	
	public static Vector2 RotateVector( Rotation q, Vector2 v )
		=> new(q.C * v.X - q.S * v.Y, q.S * v.X + q.C * v.Y);
	
	public static Vector2 InverseRotateVector( Rotation q, Vector2 v )
		=> new( q.C * v.X + q.S * v.Y, -q.S * v.X + q.C * v.Y);

	[DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2Rot_IsValid", ExactSpelling = true)]
	private static extern bool _isValid(Rotation rotation);

	public bool IsValid => _isValid(this);
}
