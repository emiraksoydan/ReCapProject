using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string SuccessAdd = "Araba Eklendi";
        public static string SuccessUpdate = "Araba Güncellendi";
        public static string SuccessDelete = "Araba Silindi";
        public static string SuccessGetCarList = "Arabalar Getirildi";
        public static string SuccessGetCarListByBrandId = "Arabalar Markaya göre Getirildi";
        public static string SuccessGetCarListByColorId = "Arabalar Renge göre Getirildi";
        public static string SuccessGetCarBrandList = "Araba Markaları Geldi";
        public static string Error = "Hata";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre eşleşmedi";
        public static string SuccesfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı Mevcut";
        public static string SuccessRegister = "Kullanıcı Kayıt oldu";
        public static string AuthorizationDenied = "Yetki yok";
    }
}
