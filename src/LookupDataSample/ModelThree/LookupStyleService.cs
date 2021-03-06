﻿using System.Collections.Generic;
using System.Linq;

namespace LookupDataSample.ModelThree
{
    public class LookupStyleService
    {
        private static List<Feature> _features = new List<Feature> 
    ()
        {
            new Feature() {Id = 1, Name = "Feature One", DefaultStyleId = 1},
            new Feature() {Id = 2, Name = "Feature Two", DefaultStyleId = 5}

        };
    private static List<Style> _styles = new List<Style>()
        {
            new Style() {FeatureId = 1, Id=1, Name = "Style A"},
            new Style() {FeatureId = 1, Id=2, Name = "Style B"},
            new Style() {FeatureId = 1, Id=3, Name = "Style C"},
            new Style() {FeatureId = 2, Id=4, Name = "Style D"},
            new Style() {FeatureId = 2, Id=5, Name = "Style E"},

        };
        public LookupDataViewModel ListStylesForFeature(int featureId)
        {
            var feature = _features.Single(f => f.Id == featureId);
            var viewModel = new LookupDataViewModel();
            viewModel.DefaultItemId = feature.DefaultStyleId;
            viewModel.Items.AddRange(_styles
                .Where(s => s.FeatureId == featureId)
                .Select(s => new LookupDataItem()
                    {
                        Id = s.Id,
                        Name = s.Name
                    }
                ));
            return viewModel;
        }
    }
}
