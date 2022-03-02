using Core.IEntity.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    //static sınıflar sadece program boyunca bir nesne uzerinden işlem yaparlar ve sabittir ve newlwnmwyw gerek duymazlar
    public static class Message
    {
        public static string CarAdded = "Araba eklendi";
        public static string NoCar = "Araba yok";
        public static string FailedCarImageAdd;
        public static string AddImage = "resim eklendi";
        internal static string CarImageLimmit="arac resim limirti 5 olabilri";
        internal static SerializationInfo AuthorizationDenied;
        internal static string UserRegistered="kullanıcı kayıt oldu";
        internal static string SuccessfulLogin="giriş işlemi başarılı";
        internal static string UserAlreadyExists="Kulanıcı zaten var";
        internal static string AccessTokenCreated="kullanıc tokenı oluşturuldu";

        public static string UserNotFound = "kullanici bulunamadi";

        public static string PasswordError = "sifre hatli";
    }
}
