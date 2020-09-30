using MiniAspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniAspNetCore.Extensions
{
   public static class FeatureExtensions
    {
        public static IFeatureCollection Set<TFeature>(this IFeatureCollection featureCollection, TFeature feature)
        {
            featureCollection[typeof(TFeature)] = feature;
            return featureCollection;
        }

        public static TFeature Get<TFeature>(this IFeatureCollection featureCollection)
        {
            var featureType = typeof(TFeature);
            return featureCollection.ContainsKey(featureType) ? (TFeature)featureCollection[featureType] : default(TFeature);
        }

    }
}
