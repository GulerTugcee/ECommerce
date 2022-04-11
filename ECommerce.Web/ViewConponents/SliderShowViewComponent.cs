using Microsoft.AspNetCore.Mvc;
using ECommerce.Business.Abstract;
using ECommerce.Web.ViewConponents.Models;//----
namespace ECommerce.Web.ViewConponents
{
    public class SliderShowViewComponent : ViewComponent
    {
        private readonly ISliderService _sliderService;
        public SliderShowViewComponent(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        public IViewComponentResult Invoke()//--
        {
            SliderShowModel sliderShowModel = new SliderShowModel();
            sliderShowModel.Sliders = _sliderService.List();
            return View(sliderShowModel);
        }
    }
}
