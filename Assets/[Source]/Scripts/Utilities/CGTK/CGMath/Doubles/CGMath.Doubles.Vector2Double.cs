﻿namespace Utilities.CGTK
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Utilities.Extensions;
    
    using Math = System.Math;

    public static partial class CGMath
    {
        public struct Vector2Double
        {
            
            public const double kEpsilon = 1E-05d;
            public double x;
            public double y;
    
            public double this[int index]
            {
                get
                {
                    switch (index)
                    {
                        case 0:
                            return this.x;
                        case 1:
                            return this.y;
                        default:
                            throw new IndexOutOfRangeException("Invalid Vector2d index!");
                    }
                }
                set
                {
                    switch (index)
                    {
                        case 0:
                            this.x = value;
                            break;
                        case 1:
                            this.y = value;
                            break;
                        default:
                            throw new IndexOutOfRangeException("Invalid Vector2d index!");
                    }
                }
            }
    
            public Vector2Double normalized
            {
                get
                {
                    Vector2Double vector2d = new Vector2Double(this.x, this.y);
                    vector2d.Normalize();
                    return vector2d;
                }
            }

        public double magnitude => CGMath.Sqrt(this.x * this.x + this.y * this.y);

        public double sqrMagnitude => this.x * this.x + this.y * this.y;

        public static Vector2Double zero => new Vector2Double(0.0d, 0.0d);

        public static Vector2Double one => new Vector2Double(1d, 1d);

        public static Vector2Double up => new Vector2Double(0.0d, 1d);

        public static Vector2Double right => new Vector2Double(1d, 0.0d);

        public Vector2Double(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public static implicit operator Vector2Double(Vector3Double v)
        {
            return new Vector2Double(v.x, v.y);
        }

        public static implicit operator Vector3Double(Vector2Double v)
        {
            return new Vector3Double(v.x, v.y, 0.0d);
        }

        public static Vector2Double operator +(Vector2Double a, Vector2Double b) {
            return new Vector2Double(a.x + b.x, a.y + b.y);
        }

        public static Vector2Double operator -(Vector2Double a, Vector2Double b) {
            return new Vector2Double(a.x - b.x, a.y - b.y);
        }

        public static Vector2Double operator -(Vector2Double a) {
            return new Vector2Double(-a.x, -a.y);
        }

        public static Vector2Double operator *(Vector2Double a, double d) {
            return new Vector2Double(a.x * d, a.y * d);
        }

        public static Vector2Double operator *(float d, Vector2Double a) {
            return new Vector2Double(a.x * d, a.y * d);
        }

        public static Vector2Double operator /(Vector2Double a, double d) {
            return new Vector2Double(a.x / d, a.y / d);
        }

        public static bool operator ==(Vector2Double lhs, Vector2Double rhs)
        {
            return Vector2Double.SqrMagnitude(lhs - rhs) < 0.0 / 1.0;
        }

        public static bool operator !=(Vector2Double lhs, Vector2Double rhs)
        {
            return (double)Vector2Double.SqrMagnitude(lhs - rhs) >= 0.0 / 1.0;
        }

        public void Set(double new_x, double new_y)
        {
            this.x = new_x;
            this.y = new_y;
        }

        public static Vector2Double Lerp(Vector2Double from, Vector2Double to, double t)
        {
            t = CGMath.Clamp01(t);
            return new Vector2Double(from.x + (to.x - from.x) * t, from.y + (to.y - from.y) * t);
        }

        public static Vector2Double MoveTowards(Vector2Double current, Vector2Double target, double maxDistanceDelta)
        {
            Vector2Double vector2 = target - current;
            double magnitude = vector2.magnitude;
            if (magnitude <= maxDistanceDelta || magnitude == 0.0d)
            {return target;}
            
            return current + vector2 / magnitude * maxDistanceDelta;
        }

        public static Vector2Double Scale(Vector2Double a, Vector2Double b)
        {
            return new Vector2Double(a.x * b.x, a.y * b.y);
        }

        public void Scale(Vector2Double scale)
        {
            this.x *= scale.x;
            this.y *= scale.y;
        }

        public void Normalize()
        {
            double magnitude = this.magnitude;
            if (magnitude > 9.99999974737875E-06)
                this = this / magnitude;
            else
                this = Vector2Double.zero;
        }

        public override int GetHashCode()
        {
            return this.x.GetHashCode() ^ this.y.GetHashCode() << 2;
        }

        public override bool Equals(object other)
        {
            if (!(other is Vector2Double))
                return false;
            Vector2Double vector2D = (Vector2Double)other;
            
            return this.x.Equals(vector2D.x) && this.y.Equals(vector2D.y);
        }

        public static double Dot(Vector2Double lhs, Vector2Double rhs)
        {
            return lhs.x * rhs.x + lhs.y * rhs.y;
        }

        public static double Angle(Vector2Double from, Vector2Double to)
        {
            return CGMath.Acos(CGMath.Clamp(Vector2Double.Dot(from.normalized, to.normalized), -1d, 1d)) * 57.29578d;
        }

        public static double Distance(Vector2Double a, Vector2Double b)
        {
            return (a - b).magnitude;
        }

        public static Vector2Double ClampMagnitude(Vector2Double vector, double maxLength)
        {
            if (vector.sqrMagnitude > maxLength * maxLength)
                return vector.normalized * maxLength;
            else
                return vector;
        }

        public static double SqrMagnitude(Vector2Double a)
        {
            return (a.x * a.x + a.y * a.y);
        }

        public double SqrMagnitude()
        {
            return (this.x * this.x + this.y * this.y);
        }

        public static Vector2Double Min(Vector2Double lhs, Vector2Double rhs)
        {
            return new Vector2Double(CGMath.Min(lhs.x, rhs.x), CGMath.Min(lhs.y, rhs.y));
        }

        public static Vector2Double Max(Vector2Double lhs, Vector2Double rhs)
        {
            return new Vector2Double(CGMath.Max(lhs.x, rhs.x), CGMath.Max(lhs.y, rhs.y));
        }
    }
    }
}
