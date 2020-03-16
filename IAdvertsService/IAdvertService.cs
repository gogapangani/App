using AdvertisementData;
using System;
using System.Collections.Generic;

namespace IAdvertsService
{
    public interface IAdvertService
    {
        IEnumerable<Advertisement> GetAdvertisements();
        Advertisement GetAdvertisement(int id);
        void InsertAdvertisement(Advertisement ad);
        void UpdateAdvertisement(Advertisement ad);
    }
}
