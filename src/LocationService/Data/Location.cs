﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Driver.GeoJsonObjectModel;

namespace LocationService.Data
{
    public class Location
    {
        [Required]
        [Range(-90.00, 90.00)]
        public double Latitude { get; set; }

        [Required]
        [Range(-180.00, 180.00)]
        public double Longitude { get; set; }
    }

    public static class LocationExtensions
    {
        public static GeoJsonPoint<GeoJson2DGeographicCoordinates> ToGeoJsonPoint(this Location location) =>
            new GeoJsonPoint<GeoJson2DGeographicCoordinates>(
                new GeoJson2DGeographicCoordinates(location.Longitude, location.Latitude));

        public static GeoJson2DGeographicCoordinates GetCoordinates(this Location location) =>
            new GeoJson2DGeographicCoordinates(location.Longitude, location.Latitude);

        public static GeoJsonMultiPoint<GeoJson2DGeographicCoordinates> ToGeoJsonMultiPoint(this Location location) =>
            new GeoJsonMultiPoint<GeoJson2DGeographicCoordinates>(
                new GeoJsonMultiPointCoordinates<GeoJson2DGeographicCoordinates>(
                    new List<GeoJson2DGeographicCoordinates>
                    {
                        new GeoJson2DGeographicCoordinates(location.Longitude, location.Latitude)
                    }));
    }
}