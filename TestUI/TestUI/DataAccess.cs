using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUI.Models;

namespace TestUI
{
    class DataAccess
    {
        Random rnd = new Random();
        string[] name = new string[] { "Petr", "Jan", "Karel", "Ivo", "Marek", "Michal" };
        string[] surname = new string[] { "Manasek", "Bomsky", "Hodak", "Riha", "Chury", "Svejda" };
        string[] title = new string[] { "Prodam auto brm brm", "Skoro nove!!", "Odpada vyfuk jinak jak nove", "Cervene = rychle", "Do kauflandu na nakup dobre", "Cana za odvoz" };
        string[] description = new string[] { "asdfasdf", "fdfdffdfdf", "eeeeeeeeee", "aiiiiii", "sussussussussus", "GetOutOfMyHeadGetOutOfMyHeadGetOutOfMyHeadGetOutOfMyHead" };
        string[] date = new string[] { "2022-01-15", "2022-02-22", "2022-02-15", "2022-03-15", "2022-04-15", "2022-05-15" };
        string[] picture = new string[] { "/Resources/Images/Cars/Auto1.png", "/Resources/Images/Cars/Auto2.png", "/Resources/Images/Cars/Auto3.png", "/Resources/Images/Cars/Auto4.png", "/Resources/Images/Cars/Auto5.png", "/Resources/Images/Cars/Auto6.png" };
        string[] carManufacturer = new string[] { "Skoda", "Volvo", "VW", "Mazda", "Suzuki", "Ford" };
        string[] cartype = new string[] { "Fabia", "144", "Golf", "mx 5", "Swift", "Focus" };
        int[] mileage = new int[] { int.MaxValue,484456,112134,321654,2545454,5222252 };
        int total = 6;


      /*  public List<MergedModel> GetMerged()
        {
            List<MergedModel> output = new List<MergedModel>();

            for (int i = 0; i < total; i++)
            {
                MergedModel merged = new MergedModel();
                
                AdvertsModel advert = GetAdvert(i + 1);
                CarModel car = GetCar();
                merged.AdvertId = advert.AdvertId;
                merged.CarId = advert.CarId;
                merged.AdvertId = advert.AdvertId;
                merged.AdvertId = advert.AdvertId;
                merged.AdvertId = advert.AdvertId;
                merged.AdvertId = advert.AdvertId;
                merged.AdvertId = advert.AdvertId;
                merged.AdvertId = advert.AdvertId;
                merged.AdvertId = advert.AdvertId;
                merged.AdvertId = advert.AdvertId;
                output.Add(GetCar(i + 1));

            }

            return output;
        }*/
        public List<AdvertsModel> GetAdverts()
        {
            List<AdvertsModel> output = new List<AdvertsModel>();

            for (int i = 0; i < total; i++)
            {
                output.Add(GetAdvert(i + 1));
                
            }


            return output;
        }
        public List<CarModel> GetCars()
        {
            List<CarModel> output = new List<CarModel>();

            for (int i = 0; i < total; i++)
            {
                output.Add(GetCar(i + 1));

            }

            return output;
        }
        private AdvertsModel GetAdvert(int id)
        {
            AdvertsModel output = new AdvertsModel();
            output.AdvertId = id;
            output.Name = GetRandomItem(name);
            output.Surname = GetRandomItem(surname);
            output.Title = GetRandomItem(title);
            output.Description = GetRandomItem(description);
            output.Date = GetRandomItem(date);
            output.Picture = GetRandomItem(picture);
            output.CarId = rnd.Next(0,total)+1;

            return output;
        }

        private CarModel GetCar(int id)
        {
            CarModel output = new CarModel();
            output.CarId = id;
            output.Manufacturer = GetRandomItem(name);
            output.Type = GetRandomItem(surname);
            output.Mileage = GetRandomItem(mileage);       
            return output;
        }

        private T GetRandomItem<T>(T[] data)
        {
            return data[rnd.Next(0, data.Length)];
        }
    }
}
