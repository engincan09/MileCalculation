using MileCalculation.Api.Helpers.MileCalculator.Abstract;
using MileCalculation.Api.Helpers.MileCalculator.Concrete;
using System;

namespace MileCalculation.Api.Helpers.MileCalculator
{
    public static class MileCalculator
    {

        public static double CalculateMile(Coordinate start, Coordinate end)
        {
            double theta = start.Longitude - end.Longitude;
            double dist = Math.Sin(Deg2Rad(start.Latitude)) * Math.Sin(Deg2Rad(end.Latitude)) + Math.Cos(Deg2Rad(start.Latitude)) * Math.Cos(Deg2Rad(end.Latitude)) * Math.Cos(Deg2Rad(theta));
            dist = Math.Acos(dist);
            dist = Rad2Deg(dist);
            dist = dist * 60 * 1.1515;
            return dist;
        }

        static double Deg2Rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        static double Rad2Deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }
    }
}
