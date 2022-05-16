using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CogentCms.WebPublic.Views.Shared.Components.GoogleAnalyticsTag
{
    public class GoogleAnalyticsTag : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var vm = new GoogleAnalyticsTagView
            {
                MeasurementId = Environment.GetEnvironmentVariable("Cogent_GoogleAnalyticsMeasurementId")
            };

            return View(vm);
        }
    }
}
