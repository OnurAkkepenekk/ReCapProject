﻿using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba Eklendi.";
        public static string CarDeleted = "Araba Silindi.";
        public static string CarUpdated = "Araba Güncellendi.";
        public static string CarDetails = "Araba Detayları getirildi.";

        public static string BrandAdded = "Marka Eklendi.";
        public static string BrandDeleted = "Marka Silindi.";
        public static string BrandUpdated = "Marka Güncellendi.";

        public static string ColorAdded = "Renk Eklendi.";
        public static string ColorDeleted = "Renk Silindi.";
        public static string ColorUpdated = "Renk Güncellendi.";

        public static string CarNameInvalidAndDailyPriceInvalid = "Araba ismi ve Günlük ücret geçersiz";
        public static string MaintenanceTime = "Bakım sürecindedir.";
        public static string CarListed = "Arabalar Listelendi.";
        public static string BrandListed = "Markalar Listelendi.";
        public static string ColorListed = "Renkler Listelendi.";

        public static string UserAdded = "Kullanıcı Eklendi.";
        public static string UserDeleted = "Kullanıcı Silindi.";
        public static string UserUpdated = "Kullanıcı Güncellendi.";
        public static string CustomerAdded = "Müşteri Eklendi";
        public static string RentalAdded;
        public static string CustomerDeleted = "Müşteri Silindi.";
        public static string CustomerUpdated = "Müşteri Güncellendi.";
        public static string CustomerList = "Müşteri Listesi";
        public static string RentalDeleted;
        public static string RentalUpdated;
        public static string CarImageAdded = "Araba resmi yüklendi.";
        public static string ListCarImage = "Resim listesi";
        public static string CarImageLimitExceeded = "En fazla 5 resim upload edebilirsin.";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered ="Kullanıcı kayıt işlemi tamamlandı.";
        public static string PasswordError ="Şifre yanlış";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists;
        public static string AccessTokenCreated ="Token oluşturuldu";
        public static string CarImageUpdated;
        public static string RentalDetails;

        public static User UserNotFound { get; internal set; }
    }
}
