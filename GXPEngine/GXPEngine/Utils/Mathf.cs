using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using GXPEngine.Core;

namespace GXPEngine
{
    /// <summary>
    /// Contains several functions for doing floating point Math
    /// </summary>
    public static class Mathff
    {
        /// <summary>
        /// Constant PI
        /// </summary>
        public const float PI = (float)Math.PI;


        public const double DBL_EPSILON = 9.99999943962493E-11;
        /// <summary>
        /// Returns the absolute value of specified number
        /// </summary>
        public static int Abs(int value)
        {
            return (value < 0) ? -value : value;
        }

        /// <summary>
        /// Returns the absolute value of specified number
        /// </summary>
        public static float Abs(float value)
        {
            return (value < 0) ? -value : value;
        }

        /// <summary>
        /// Returns the acosine of the specified number
        /// </summary>
        public static float Acos(float f)
        {
            return (float)Math.Acos(f);
        }

        /// <summary>
        /// Returns the arctangent of the specified number
        /// </summary>
        public static float Atan(float f)
        {
            return (float)Math.Atan(f);
        }

        /// <summary>
        /// Returns the angle whose tangent is the quotent of the specified values
        /// </summary>
        public static float Atan2(float y, float x)
        {
            return (float)Math.Atan2(y, x);
        }

        /// <summary>
        /// Returns the smallest integer bigger greater than or equal to the specified number
        /// </summary>
        public static int Ceiling(float a)
        {
            return (int)Math.Ceiling(a);
        }

        /// <summary>
        /// Returns the cosine of the specified number
        /// </summary>
        public static float Cos(float f)
        {
            return (float)Math.Cos(f);
        }

        /// <summary>
        /// Returns the hyperbolic cosine of the specified number
        /// </summary>
        public static float Cosh(float value)
        {
            return (float)Math.Cosh(value);
        }

        /// <summary>
        /// Returns e raised to the given number
        /// </summary>
        public static float Exp(float f)
        {
            return (float)Math.Exp(f);
        }

        /// <summary>
        /// Returns the largest integer less than or equal to the specified value
        /// </summary>
        public static int Floor(float f)
        {
            return (int)Math.Floor(f);
        }

        /// <summary>
        /// Returns the natural logarithm of the specified number
        /// </summary>
        public static float Log(float f)
        {
            return (float)Math.Log(f);
        }

        /// <summary>
        /// Returns the log10 of the specified number
        /// </summary>
        public static float Log10(float f)
        {
            return (float)Math.Log10(f);
        }

        /// <summary>
        /// Returns the biggest of the two specified values
        /// </summary>
        public static float Max(float value1, float value2)
        {
            return (value2 > value1) ? value2 : value1;
        }

        /// <summary>
        /// Returns the biggest of the two specified values
        /// </summary>
        public static int Max(int value1, int value2)
        {
            return (value2 > value1) ? value2 : value1;
        }

        /// <summary>
        /// Returns the smallest of the two specified values
        /// </summary>
        public static float Min(float value1, float value2)
        {
            return (value2 < value1) ? value2 : value1;
        }

        /// <summary>
        /// Returns the smallest of the two specified values
        /// </summary>
        public static int Min(int value1, int value2)
        {
            return (value2 < value1) ? value2 : value1;
        }

        /// <summary>
        /// Returns x raised to the power of y
        /// </summary>
        public static float Pow(float x, float y)
        {
            return (float)Math.Pow(x, y);
        }

        /// <summary>
        /// Returns the nearest integer to the specified value
        /// </summary>
        public static int Round(float f)
        {
            return (int)Math.Round(f);
        }

        /// <summary>
        /// Returns a value indicating the sign of the specified number (-1=negative, 0=zero, 1=positive)
        /// </summary>
        public static int Sign(float f)
        {
            if (f < 0) return -1;
            if (f > 0) return 1;
            return 0;
        }

        /// <summary>
        /// Returns a value indicating the sign of the specified number (-1=negative, 0=zero, 1=positive)
        /// </summary>
        public static int Sign(int f)
        {
            if (f < 0) return -1;
            if (f > 0) return 1;
            return 0;
        }

        /// <summary>
        /// Returns the sine of the specified number
        /// </summary>
        public static float Sin(float f)
        {
            return (float)Math.Sin(f);
        }

        /// <summary>
        /// Returns the hyperbolic sine of the specified number
        /// </summary>
        public static float Sinh(float value)
        {
            return (float)Math.Sinh(value);
        }

        /// <summary>
        /// Returns the square root of the specified number
        /// </summary>
        public static float Sqrt(float f)
        {
            return (float)Math.Sqrt(f);
        }

        /// <summary>
        /// Returns the tangent of the specified number
        /// </summary>
        public static float Tan(float f)
        {
            return (float)Math.Tan(f);
        }

        /// <summary>
        /// Returns the hyperbolic tangent of the specified number
        /// </summary>
        public static float Tanh(float value)
        {
            return (float)Math.Tanh(value);
        }

        /// <summary>
        /// Calculates the integral part of the specified number
        /// </summary>
        public static float Truncate(float f)
        {
            return (float)Math.Truncate(f);
        }

        /// <summary>
        /// Clamps f in the range [min,max]:
        /// Returns min if f<min, max if f>max, and f otherwise.
        /// </summary>
        public static float Clamp(float f, float min, float max)
        {
            return f < min ? min : (f > max ? max : f);
        }

    }
    public struct Mathf
    {
        //
        // Summary:
        //     The well-known 3.14159265358979... value (Read Only).
        public const float PI = (float)Math.PI;


        public const double DBL_EPSILON = 9.99999943962493E-11;
        //
        // Summary:
        //     A representation of positive infinity (Read Only).
        public const float Infinity = float.PositiveInfinity;

        //
        // Summary:
        //     A representation of negative infinity (Read Only).
        public const float NegativeInfinity = float.NegativeInfinity;

        //
        // Summary:
        //     Degrees-to-radians conversion constant (Read Only).
        public const float Deg2Rad = (float)Math.PI / 180f;

        //
        // Summary:
        //     Radians-to-degrees conversion constant (Read Only).
        public const float Rad2Deg = 57.29578f;

        //
        // Summary:
        //     A tiny floating point value (Read Only).
        //public static readonly float Epsilon = (MathfInternal.IsFlushToZeroEnabled ? MathfInternal.FloatMinNormal : MathfInternal.FloatMinDenormal);

        //
        // Summary:
        //     Returns the closest power of two value.
        //
        // Parameters:
        //   value:
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern int ClosestPowerOfTwo(int value);

        //
        // Summary:
        //     Returns true if the value is power of two.
        //
        // Parameters:
        //   value:
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool IsPowerOfTwo(int value);

        //
        // Summary:
        //     Returns the next power of two that is equal to, or greater than, the argument.
        //
        // Parameters:
        //   value:
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern int NextPowerOfTwo(int value);

        //
        // Summary:
        //     Converts the given value from gamma (sRGB) to linear color space.
        //
        // Parameters:
        //   value:
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern float GammaToLinearSpace(float value);

        //
        // Summary:
        //     Converts the given value from linear to gamma (sRGB) color space.
        //
        // Parameters:
        //   value:
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern float LinearToGammaSpace(float value);

        //
        // Summary:
        //     Convert a color temperature in Kelvin to RGB color.
        //
        // Parameters:
        //   kelvin:
        //     Temperature in Kelvin. Range 1000 to 40000 Kelvin.
        //
        // Returns:
        //     Correlated Color Temperature as floating point RGB color.
        public static Color CorrelatedColorTemperatureToRGB(float kelvin)
        {
            CorrelatedColorTemperatureToRGB_Injected(kelvin, out var ret);
            return ret;
        }

        //
        // Summary:
        //     Encode a floating point value into a 16-bit representation.
        //
        // Parameters:
        //   val:
        //     The floating point value to convert.
        //
        // Returns:
        //     The converted half-precision float, stored in a 16-bit unsigned integer.
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern ushort FloatToHalf(float val);

        //
        // Summary:
        //     Convert a half precision float to a 32-bit floating point value.
        //
        // Parameters:
        //   val:
        //     The half precision value to convert.
        //
        // Returns:
        //     The decoded 32-bit float.

        //
        // Summary:
        //     Generate 2D Perlin noise.
        //
        // Parameters:
        //   x:
        //     X-coordinate of sample point.
        //
        //   y:
        //     Y-coordinate of sample point.
        //
        // Returns:
        //     Value between 0.0 and 1.0. (Return value might be slightly below 0.0 or beyond
        //     1.0.)

        //
        // Summary:
        //     Returns the sine of angle f.
        //
        // Parameters:
        //   f:
        //     The input angle, in radians.
        //
        // Returns:
        //     The return value between -1 and +1.
        public static float Sin(float f)
        {
            return (float)Math.Sin(f);
        }

        //
        // Summary:
        //     Returns the cosine of angle f.
        //
        // Parameters:
        //   f:
        //     The input angle, in radians.
        //
        // Returns:
        //     The return value between -1 and 1.
        public static float Cos(float f)
        {
            return (float)Math.Cos(f);
        }

        //
        // Summary:
        //     Returns the tangent of angle f in radians.
        //
        // Parameters:
        //   f:
        public static float Tan(float f)
        {
            return (float)Math.Tan(f);
        }

        //
        // Summary:
        //     Returns the arc-sine of f - the angle in radians whose sine is f.
        //
        // Parameters:
        //   f:
        public static float Asin(float f)
        {
            return (float)Math.Asin(f);
        }

        //
        // Summary:
        //     Returns the arc-cosine of f - the angle in radians whose cosine is f.
        //
        // Parameters:
        //   f:
        public static float Acos(float f)
        {
            return (float)Math.Acos(f);
        }

        //
        // Summary:
        //     Returns the arc-tangent of f - the angle in radians whose tangent is f.
        //
        // Parameters:
        //   f:
        public static float Atan(float f)
        {
            return (float)Math.Atan(f);
        }

        //
        // Summary:
        //     Returns the angle in radians whose Tan is y/x.
        //
        // Parameters:
        //   y:
        //
        //   x:
        public static float Atan2(float y, float x)
        {
            return (float)Math.Atan2(y, x);
        }

        //
        // Summary:
        //     Returns square root of f.
        //
        // Parameters:
        //   f:
        public static float Sqrt(float f)
        {
            return (float)Math.Sqrt(f);
        }

        //
        // Summary:
        //     Returns the absolute value of f.
        //
        // Parameters:
        //   f:
        public static float Abs(float f)
        {
            return Math.Abs(f);
        }

        //
        // Summary:
        //     Returns the absolute value of value.
        //
        // Parameters:
        //   value:
        public static int Abs(int value)
        {
            return Math.Abs(value);
        }

        //
        // Summary:
        //     Returns the smallest of two or more values.
        //
        // Parameters:
        //   a:
        //
        //   b:
        //
        //   values:
        public static float Min(float a, float b)
        {
            return (a < b) ? a : b;
        }

        //
        // Summary:
        //     Returns the smallest of two or more values.
        //
        // Parameters:
        //   a:
        //
        //   b:
        //
        //   values:
        public static float Min(params float[] values)
        {
            int num = values.Length;
            if (num == 0)
            {
                return 0f;
            }

            float num2 = values[0];
            for (int i = 1; i < num; i++)
            {
                if (values[i] < num2)
                {
                    num2 = values[i];
                }
            }

            return num2;
        }

        //
        // Summary:
        //     Returns the smallest of two or more values.
        //
        // Parameters:
        //   a:
        //
        //   b:
        //
        //   values:
        public static int Min(int a, int b)
        {
            return (a < b) ? a : b;
        }

        //
        // Summary:
        //     Returns the smallest of two or more values.
        //
        // Parameters:
        //   a:
        //
        //   b:
        //
        //   values:
        public static int Min(params int[] values)
        {
            int num = values.Length;
            if (num == 0)
            {
                return 0;
            }

            int num2 = values[0];
            for (int i = 1; i < num; i++)
            {
                if (values[i] < num2)
                {
                    num2 = values[i];
                }
            }

            return num2;
        }

        //
        // Summary:
        //     Returns largest of two or more values.
        //
        // Parameters:
        //   a:
        //
        //   b:
        //
        //   values:
        public static float Max(float a, float b)
        {
            return (a > b) ? a : b;
        }

        //
        // Summary:
        //     Returns largest of two or more values.
        //
        // Parameters:
        //   a:
        //
        //   b:
        //
        //   values:
        public static float Max(params float[] values)
        {
            int num = values.Length;
            if (num == 0)
            {
                return 0f;
            }

            float num2 = values[0];
            for (int i = 1; i < num; i++)
            {
                if (values[i] > num2)
                {
                    num2 = values[i];
                }
            }

            return num2;
        }

        //
        // Summary:
        //     Returns the largest of two or more values.
        //
        // Parameters:
        //   a:
        //
        //   b:
        //
        //   values:
        public static int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        //
        // Summary:
        //     Returns the largest of two or more values.
        //
        // Parameters:
        //   a:
        //
        //   b:
        //
        //   values:
        public static int Max(params int[] values)
        {
            int num = values.Length;
            if (num == 0)
            {
                return 0;
            }

            int num2 = values[0];
            for (int i = 1; i < num; i++)
            {
                if (values[i] > num2)
                {
                    num2 = values[i];
                }
            }

            return num2;
        }

        //
        // Summary:
        //     Returns f raised to power p.
        //
        // Parameters:
        //   f:
        //
        //   p:
        public static float Pow(float f, float p)
        {
            return (float)Math.Pow(f, p);
        }

        //
        // Summary:
        //     Returns e raised to the specified power.
        //
        // Parameters:
        //   power:
        public static float Exp(float power)
        {
            return (float)Math.Exp(power);
        }

        //
        // Summary:
        //     Returns the logarithm of a specified number in a specified base.
        //
        // Parameters:
        //   f:
        //
        //   p:
        public static float Log(float f, float p)
        {
            return (float)Math.Log(f, p);
        }

        //
        // Summary:
        //     Returns the natural (base e) logarithm of a specified number.
        //
        // Parameters:
        //   f:
        public static float Log(float f)
        {
            return (float)Math.Log(f);
        }

        //
        // Summary:
        //     Returns the base 10 logarithm of a specified number.
        //
        // Parameters:
        //   f:
        public static float Log10(float f)
        {
            return (float)Math.Log10(f);
        }

        //
        // Summary:
        //     Returns the smallest integer greater to or equal to f.
        //
        // Parameters:
        //   f:
        public static float Ceil(float f)
        {
            return (float)Math.Ceiling(f);
        }

        //
        // Summary:
        //     Returns the largest integer smaller than or equal to f.
        //
        // Parameters:
        //   f:
        public static float Floor(float f)
        {
            return (float)Math.Floor(f);
        }

        //
        // Summary:
        //     Returns f rounded to the nearest integer.
        //
        // Parameters:
        //   f:
        public static float Round(float f)
        {
            return (float)Math.Round(f);
        }

        //
        // Summary:
        //     Returns the smallest integer greater to or equal to f.
        //
        // Parameters:
        //   f:
        public static int CeilToInt(float f)
        {
            return (int)Math.Ceiling(f);
        }

        //
        // Summary:
        //     Returns the largest integer smaller to or equal to f.
        //
        // Parameters:
        //   f:
        public static int FloorToInt(float f)
        {
            return (int)Math.Floor(f);
        }

        //
        // Summary:
        //     Returns f rounded to the nearest integer.
        //
        // Parameters:
        //   f:
        public static int RoundToInt(float f)
        {
            return (int)Math.Round(f);
        }

        //
        // Summary:
        //     Returns the sign of f.
        //
        // Parameters:
        //   f:
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sign(float f)
        {
            return (f >= 0f) ? 1f : (-1f);
        }

        //
        // Summary:
        //     Clamps the given value between the given minimum float and maximum float values.
        //     Returns the given value if it is within the minimum and maximum range.
        //
        // Parameters:
        //   value:
        //     The floating point value to restrict inside the range defined by the minimum
        //     and maximum values.
        //
        //   min:
        //     The minimum floating point value to compare against.
        //
        //   max:
        //     The maximum floating point value to compare against.
        //
        // Returns:
        //     The float result between the minimum and maximum values.
        public static float Clamp(float value, float min, float max)
        {
            if (value < min)
            {
                value = min;
            }
            else if (value > max)
            {
                value = max;
            }

            return value;
        }

        //
        // Summary:
        //     Clamps the given value between a range defined by the given minimum integer and
        //     maximum integer values. Returns the given value if it is within min and max.
        //
        // Parameters:
        //   value:
        //     The integer point value to restrict inside the min-to-max range.
        //
        //   min:
        //     The minimum integer point value to compare against.
        //
        //   max:
        //     The maximum integer point value to compare against.
        //
        // Returns:
        //     The int result between min and max values.
        public static int Clamp(int value, int min, int max)
        {
            if (value < min)
            {
                value = min;
            }
            else if (value > max)
            {
                value = max;
            }

            return value;
        }

        //
        // Summary:
        //     Clamps value between 0 and 1 and returns value.
        //
        // Parameters:
        //   value:
        public static float Clamp01(float value)
        {
            if (value < 0f)
            {
                return 0f;
            }

            if (value > 1f)
            {
                return 1f;
            }

            return value;
        }

        //
        // Summary:
        //     Linearly interpolates between a and b by t.
        //
        // Parameters:
        //   a:
        //     The start value.
        //
        //   b:
        //     The end value.
        //
        //   t:
        //     The interpolation value between the two floats.
        //
        // Returns:
        //     The interpolated float result between the two float values.
        public static float Lerp(float a, float b, float t)
        {
            return a + (b - a) * Clamp01(t);
        }

        //
        // Summary:
        //     Linearly interpolates between a and b by t with no limit to t.
        //
        // Parameters:
        //   a:
        //     The start value.
        //
        //   b:
        //     The end value.
        //
        //   t:
        //     The interpolation between the two floats.
        //
        // Returns:
        //     The float value as a result from the linear interpolation.
        public static float LerpUnclamped(float a, float b, float t)
        {
            return a + (b - a) * t;
        }

        //
        // Summary:
        //     Same as Lerp but makes sure the values interpolate correctly when they wrap around
        //     360 degrees.
        //
        // Parameters:
        //   a:
        //
        //   b:
        //
        //   t:
        public static float LerpAngle(float a, float b, float t)
        {
            float num = Repeat(b - a, 360f);
            if (num > 180f)
            {
                num -= 360f;
            }

            return a + num * Clamp01(t);
        }

        //
        // Summary:
        //     Moves a value current towards target.
        //
        // Parameters:
        //   current:
        //     The current value.
        //
        //   target:
        //     The value to move towards.
        //
        //   maxDelta:
        //     The maximum change that should be applied to the value.
        public static float MoveTowards(float current, float target, float maxDelta)
        {
            if (Abs(target - current) <= maxDelta)
            {
                return target;
            }

            return current + Sign(target - current) * maxDelta;
        }

        //
        // Summary:
        //     Same as MoveTowards but makes sure the values interpolate correctly when they
        //     wrap around 360 degrees.
        //
        // Parameters:
        //   current:
        //
        //   target:
        //
        //   maxDelta:
        public static float MoveTowardsAngle(float current, float target, float maxDelta)
        {
            float num = DeltaAngle(current, target);
            if (0f - maxDelta < num && num < maxDelta)
            {
                return target;
            }

            target = current + num;
            return MoveTowards(current, target, maxDelta);
        }

        //
        // Summary:
        //     Interpolates between min and max with smoothing at the limits.
        //
        // Parameters:
        //   from:
        //
        //   to:
        //
        //   t:
        public static float SmoothStep(float from, float to, float t)
        {
            t = Clamp01(t);
            t = -2f * t * t * t + 3f * t * t;
            return to * t + from * (1f - t);
        }

        public static float Gamma(float value, float absmax, float gamma)
        {
            bool flag = value < 0f;
            float num = Abs(value);
            if (num > absmax)
            {
                return flag ? (0f - num) : num;
            }

            float num2 = Pow(num / absmax, gamma) * absmax;
            return flag ? (0f - num2) : num2;
        }

        //
        // Summary:
        //     Compares two floating point values and returns true if they are similar.
        //
        // Parameters:
        //   a:
        //
        //   b:
        //public static bool Approximately(float a, float b)
        //{
        //    return Abs(b - a) < Max(1E-06f * Max(Abs(a), Abs(b)), Epsilon * 8f);
        //}

        //public static float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed)
        //{
        //    float deltaTime = Time.deltaTime;
        //    return SmoothDamp(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
        //}

        //public static float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime)
        //{
        //    float deltaTime = Time.deltaTime;
        //    float maxSpeed = float.PositiveInfinity;
        //    return SmoothDamp(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
        //}

        //public static float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime, [DefaultValue("Mathf.Infinity")] float maxSpeed, [DefaultValue("Time.deltaTime")] float deltaTime)
        //{
        //    smoothTime = Max(0.0001f, smoothTime);
        //    float num = 2f / smoothTime;
        //    float num2 = num * deltaTime;
        //    float num3 = 1f / (1f + num2 + 0.48f * num2 * num2 + 0.235f * num2 * num2 * num2);
        //    float value = current - target;
        //    float num4 = target;
        //    float num5 = maxSpeed * smoothTime;
        //    value = Clamp(value, 0f - num5, num5);
        //    target = current - value;
        //    float num6 = (currentVelocity + num * value) * deltaTime;
        //    currentVelocity = (currentVelocity - num * num6) * num3;
        //    float num7 = target + (value + num6) * num3;
        //    if (num4 - current > 0f == num7 > num4)
        //    {
        //        num7 = num4;
        //        currentVelocity = (num7 - num4) / deltaTime;
        //    }

        //    return num7;
        //}


        //public static float SmoothDampAngle(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed)
        //{
        //    float deltaTime = Time.deltaTime;
        //    return SmoothDampAngle(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
        //}


        //public static float SmoothDampAngle(float current, float target, ref float currentVelocity, float smoothTime)
        //{
        //    float deltaTime = Time.deltaTime;
        //    float maxSpeed = float.PositiveInfinity;
        //    return SmoothDampAngle(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
        //}

        //public static float SmoothDampAngle(float current, float target, ref float currentVelocity, float smoothTime, [DefaultValue("Mathf.Infinity")] float maxSpeed, [DefaultValue("Time.deltaTime")] float deltaTime)
        //{
        //    target = current + DeltaAngle(current, target);
        //    return SmoothDamp(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
        //}

        //
        // Summary:
        //     Loops the value t, so that it is never larger than length and never smaller than
        //     0.
        //
        // Parameters:
        //   t:
        //
        //   length:
        public static float Repeat(float t, float length)
        {
            return Clamp(t - Floor(t / length) * length, 0f, length);
        }

        //
        // Summary:
        //     PingPong returns a value that will increment and decrement between the value
        //     0 and length.
        //
        // Parameters:
        //   t:
        //
        //   length:
        public static float PingPong(float t, float length)
        {
            t = Repeat(t, length * 2f);
            return length - Abs(t - length);
        }

        //
        // Summary:
        //     Determines where a value lies between two points.
        //
        // Parameters:
        //   a:
        //     The start of the range.
        //
        //   b:
        //     The end of the range.
        //
        //   value:
        //     The point within the range you want to calculate.
        //
        // Returns:
        //     A value between zero and one, representing where the "value" parameter falls
        //     within the range defined by a and b.
        public static float InverseLerp(float a, float b, float value)
        {
            if (a != b)
            {
                return Clamp01((value - a) / (b - a));
            }

            return 0f;
        }

        //
        // Summary:
        //     Calculates the shortest difference between two given angles given in degrees.
        //
        // Parameters:
        //   current:
        //
        //   target:
        public static float DeltaAngle(float current, float target)
        {
            float num = Repeat(target - current, 360f);
            if (num > 180f)
            {
                num -= 360f;
            }

            return num;
        }

        internal static bool LineIntersection(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, ref Vector2 result)
        {
            float num = p2.x - p1.x;
            float num2 = p2.y - p1.y;
            float num3 = p4.x - p3.x;
            float num4 = p4.y - p3.y;
            float num5 = num * num4 - num2 * num3;
            if (num5 == 0f)
            {
                return false;
            }

            float num6 = p3.x - p1.x;
            float num7 = p3.y - p1.y;
            float num8 = (num6 * num4 - num7 * num3) / num5;
            result.x = p1.x + num8 * num;
            result.y = p1.y + num8 * num2;
            return true;
        }

        internal static bool LineSegmentIntersection(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, ref Vector2 result)
        {
            float num = p2.x - p1.x;
            float num2 = p2.y - p1.y;
            float num3 = p4.x - p3.x;
            float num4 = p4.y - p3.y;
            float num5 = num * num4 - num2 * num3;
            if (num5 == 0f)
            {
                return false;
            }

            float num6 = p3.x - p1.x;
            float num7 = p3.y - p1.y;
            float num8 = (num6 * num4 - num7 * num3) / num5;
            if (num8 < 0f || num8 > 1f)
            {
                return false;
            }

            float num9 = (num6 * num2 - num7 * num) / num5;
            if (num9 < 0f || num9 > 1f)
            {
                return false;
            }

            result.x = p1.x + num8 * num;
            result.y = p1.y + num8 * num2;
            return true;
        }

        internal static long RandomToLong(System.Random r)
        {
            byte[] array = new byte[8];
            r.NextBytes(array);
            return (long)(BitConverter.ToUInt64(array, 0) & 0x7FFFFFFFFFFFFFFFL);
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void CorrelatedColorTemperatureToRGB_Injected(float kelvin, out Color ret);
    }
}

