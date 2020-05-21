using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _7Lab
{
    public class Fraction : IComparable<Fraction>, IEquatable<Fraction>, IFormattable
    {
        public long Numerator { get; set; }
        public long Denominator { get; set; }
        public Fraction(long Numerator, long Denominator = 1)
        {
            this.Numerator = Numerator;
            this.Denominator = (Denominator > 0 ? Denominator : 1);
            Simplify();
        }

        #region Math

        public static Fraction operator +(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Denominator + a.Denominator * b.Numerator, a.Denominator * b.Denominator);
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Denominator - a.Denominator * b.Numerator, a.Denominator * b.Denominator);
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.Numerator == 0)
            {
                throw new DivideByZeroException();
            }
            return new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        public static bool operator <(Fraction a, Fraction b)
        {
            return a.CompareTo(b) == -1;
        }

        public static bool operator >(Fraction a, Fraction b)
        {
            return a.CompareTo(b) == 1;
        }

        public static bool operator ==(Fraction a, Fraction b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Fraction a, Fraction b)
        {
            return !a.Equals(b);
        }
        public static bool operator >=(Fraction a, Fraction b)
        {
            return a.CompareTo(b) != -1;
        }

        public static bool operator <=(Fraction a, Fraction b)
        {
            return a.CompareTo(b) != 1;
        }

        public static Fraction operator ++(Fraction a)
        {
            return new Fraction(a.Numerator + a.Denominator, a.Denominator);
        }

        public static Fraction operator --(Fraction a)
        {
            return new Fraction(a.Numerator - a.Denominator, a.Denominator);
        }

        public static Fraction operator -(Fraction a)
        {
            return new Fraction(a.Numerator * Math.Sign(a.Numerator), a.Denominator);
        }

        public static Fraction operator +(Fraction a)
        {
            return a;
        }

        #endregion

        #region Casts
        public static implicit operator Fraction(int val)
        {
            return new Fraction(val);
        }

        public static implicit operator Fraction(long val)
        {
            return new Fraction(val);
        }

        public static implicit operator Fraction(decimal val)
        {
            return GetFractionFromDecimal(val);
        }

        public static implicit operator Fraction(double val)
        {
            return GetFractionFromDecimal((decimal)val);
        }

        public static implicit operator Fraction(float val)
        {
            return GetFractionFromDecimal((decimal)val);
        }

        public static explicit operator int(Fraction a)
        {
            return (int)a.Numerator / (int)a.Denominator;
        }

        public static explicit operator long(Fraction a)
        {
            return a.Numerator / a.Denominator;
        }

        public static explicit operator float(Fraction a)
        {
            return (float)a.Numerator / (float)a.Denominator;
        }

        public static explicit operator double(Fraction a)
        {
            return (double)a.Numerator / (double)a.Denominator;
        }

        public static explicit operator decimal(Fraction a)
        {
            return (decimal)a.Numerator / (decimal)a.Denominator;
        }

        #endregion

        private void Simplify()
        {
            long gcd = Math.Abs(GCD(Numerator, Denominator));
            Numerator /= gcd;
            Denominator /= gcd;
        }

        public static long GCD(long a, long b)
        {
            return (b == 0 ? a : GCD(b, a % b));
        }

        private static Fraction GetFractionFromDecimal(decimal d)
        {
            int x = 0;
            while (d.ToString().IndexOf(',') != -1 && d < long.MaxValue / 10)
            {
                d *= 10;
                x++;
            }
            if (d.ToString().IndexOf(',') != -1)
            {
                return new Fraction((long)d, (long)Math.Pow(10, x));
            }
            else
            {
                string str = d.ToString();
                str = str.Substring(0, str.IndexOf(','));
                Console.WriteLine(Convert.ToDecimal(str));
                return new Fraction(Convert.ToInt64(str), x);
            }
        }

        public int CompareTo([AllowNull] Fraction other)
        {
            if (other == null) throw new NullReferenceException();
            else if (Numerator * other.Denominator < Denominator * other.Numerator) return -1;
            else if (Numerator * other.Denominator > Denominator * other.Numerator) return 1;
            else return 0;
        }
        
        public override bool Equals(object obj)
        {
            return obj is Fraction && (this.CompareTo(obj as Fraction) == 0);
        }
        
        override public int GetHashCode()
        {
            return HashCode.Combine(Numerator, Denominator);
        }

        
        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.CurrentCulture);
        }

        public string ToString()
        {
            return ToString("FRACTION");
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (String.IsNullOrEmpty(format)) format = "FRACTION";
            if (formatProvider == null) formatProvider = CultureInfo.CurrentCulture;

            switch (format.ToUpperInvariant())
            {
                case "FRACTION":
                    return $"{this.Numerator}/{this.Denominator}";
                case "LONG":
                    return ((long)this).ToString();
                case "DOUBLE":
                    return ((double)this).ToString();
                default:
                    throw new FormatException($"Invalid format {format}");
            }
        }

        public static Fraction Parse(string str)
        {
            if(TryParse(str,out Fraction result))
            {
                return result;
            }
            else
            {
                throw new FormatException("Invalid format");
            }
        }

        public static bool TryParse(string str,out Fraction result)
        {
            Regex pattern1 = new Regex(@"^(-?\d+)/(\d+)$");
            Regex pattern2 = new Regex(@"^(-?\d+)$");
            Regex pattern3 = new Regex(@"^(-?\d+),(\d+)$");
            if (pattern1.IsMatch(str))
            {
                Match match = pattern1.Match(str);
                result = new Fraction(int.Parse(match.Groups[1].Value),
                                            int.Parse(match.Groups[2].Value));
                return true;
            }
            if (pattern2.IsMatch(str))
            {
                Match match = pattern2.Match(str);
                result = new Fraction(int.Parse(match.Groups[1].Value), 1);
                return true;
            }
            if (pattern3.IsMatch(str))
            {
                result = GetFractionFromDecimal(Convert.ToDecimal(str));
                return true;
            }
            result = null;
            return false;
        }
    }
}
