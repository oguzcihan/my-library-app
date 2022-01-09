using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constans
{
    static class Messages
    {
        //bir kere dursun diye static olarak eklendik her seferinde new lenmesin
        //çok dil desteğindeki sistemlerle de kullanılabilir.

        public static string ProductAdded = "Ürün eklendi";
        public static string ProductDeleted = "Ürün silindi";
        public static string ProductUpdated = "Ürün güncellendi";

        public static string UserNotFound = "Kullanıcı bulnamadı";

        public static string PasswordError = "Şifre Hatalı";
        public static string SuccessLogin = "Giriş Başarılı";
        public static string UserAlReady = "Kullanıcı mevcut";
        public static string UserRegistered = "Kullanıcı kayıt edildi";
        public static string AccessTokenCreated = "Token oluşturuldu";
    }
}
