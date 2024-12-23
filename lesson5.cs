using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Project
{
    internal class Fraction
    {
        private int numerator;

        private int denominator;

        public Fraction(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
            Reduce();
        }



        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return Math.Abs(a);
        }

        private void Reduce()
        {
            int gcd = GCD(numerator, denominator);
            numerator /= gcd;
            denominator /= gcd;

            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            return new Fraction(
                a.numerator * b.denominator + b.numerator * a.denominator,
                a.denominator * b.denominator
            );
        }


        public static Fraction operator -(Fraction a, Fraction b)
        {
            return new Fraction(
                a.numerator * b.denominator - b.numerator * a.denominator,
                a.denominator * b.denominator
            );
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(
                a.numerator * b.numerator,
                a.denominator * b.denominator
            );
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.numerator == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero fraction");
            }

            return new Fraction(
                a.numerator * b.denominator,
                a.denominator * b.numerator
            );
        }

        public static bool operator ==(Fraction a, Fraction b)
        {
            return a.numerator == b.numerator && a.denominator == b.denominator;
        }


        public static bool operator !=(Fraction a, Fraction b)
        {
            return !(a == b);
        }


        public static bool operator >(Fraction a, Fraction b)
        {
            return a.numerator * b.denominator > b.numerator * a.denominator;
        }

        public static bool operator <(Fraction a, Fraction b)
        {
            return a.numerator * b.denominator < b.numerator * a.denominator;
        }


        public override string ToString()
        {
            return $"{numerator}/{denominator}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Fraction other)
            {
                return this == other;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(numerator, denominator);
        }

    }
}
