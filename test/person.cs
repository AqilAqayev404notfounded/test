using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Car : IComparable<Car>, ICloneable, IEquatable<Car>
    {
        public string Name { get; set; }
        public int MaxMph { get; set; }
        public int Horsepower { get; set; }
        public decimal Price { get; set; }

        public int CompareTo(Car other)
        {
            if (other == null) return 1;
            // Compare cars by Price by default
            return this.Price.CompareTo(other.Price);
        }

        public object Clone()
        {
            return new Car
            {
                Name = this.Name,
                MaxMph = this.MaxMph,
                Horsepower = this.Horsepower,
                Price = this.Price
            };
        }

        public bool Equals(Car other)
        {
            if (other == null) return false;
            return this.Name == other.Name &&
                   this.MaxMph == other.MaxMph &&
                   this.Horsepower == other.Horsepower &&
                   this.Price == other.Price;
        }

        public override bool Equals(object obj)
        {
            if (obj is Car)
            {
                return Equals((Car)obj);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, MaxMph, Horsepower, Price);
        }
    }

    public class CarComparer : IComparer<Car>
    {
        private string _comparisonProperty;

        public CarComparer(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        public int Compare(Car x, Car y)
        {
            if (x == null || y == null) return 0;

            switch (_comparisonProperty.ToLower())
            {
                case "price":
                    return x.Price.CompareTo(y.Price);
                case "horsepower":
                    return x.Horsepower.CompareTo(y.Horsepower);
                case "maxmph":
                    return x.MaxMph.CompareTo(y.MaxMph);
                default:
                    throw new ArgumentException("Invalid comparison property");
            }
        }
    }

}
