using MileCalculation.Api.Helpers.MileCalculator.Abstract;

namespace MileCalculation.Api.Helpers.MileCalculator.Concrete
{
    public class Coordinate : ICoordinate
    {
        public double Latitude { get; }
        public double Longitude { get; }

        public Coordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
