using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartDomain.Concrete
{
    public class EmailSettings
    {
        public string MailToAddress = "980498809@qq.com";
        public string MailFromAddress = "zha779645641@163.com";
        public bool UseSsl = false;
        public string Username = "zha779645641@163.com";
        public string Password = "980498809";
        public int ServerPort = 25;
        public string ServerName = "smtp.163.com";
        public bool WriteAsFile = true;
        //public string FileLocation = @"D:\MyFile\temp";
    }



}