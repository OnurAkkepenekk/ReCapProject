using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi.";
        public static string CarDeleted = "Araba silindi.";
        public static string CarUpdated = "Araba Güncellendi.";
        public static string CarDetails = "Araba Detayları getirildi.";

        public static string BrandAdded = "Marka Eklendi.";
        public static string BrandDeleted = "Marka silindi.";
        public static string BrandUpdated = "Marka Güncellendi.";

        public static string ColorAdded = "Renk Eklendi.";
        public static string ColorDeleted = "Renk Silindi.";
        public static string ColorUpdated = "Renk Güncellendi.";

        public static string CarNameInvalidAndDailyPriceInvalid = "Araba ismi ve Günlük ücret geçersiz";
        internal static string MaintenanceTime = "Bakım sürecindedir.";
        internal static string CarListed = "Arabalar listelendi.";
        internal static string BrandListed = "Markalar Listelendi.";
        internal static string ColorListed = "Renkler listelendi.";
    }
}
