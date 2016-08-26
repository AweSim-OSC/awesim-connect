using OSCConnect.Models;

namespace OSCConnect.Controllers
{
    class BrandFactory
    {
        public Brand _brand;

        public BrandFactory(string brandString)
        {
            if(brandString.ToLower().Contains(new AweSimBrand().brandString()))
            {
                _brand = new AweSimBrand();
            } else
            {
                _brand = new OSCBrand();
            }
        }

        public Brand getBrand()
        {
            return _brand;
        }
    }
}
