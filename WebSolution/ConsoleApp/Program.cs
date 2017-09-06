using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static void SendEmail()
        {
            try
            {
                MailMessage mm = new MailMessage();
                MailAddress Fromma = new MailAddress("1020627112@qq.com");
                MailAddress Toma = new MailAddress("1215063062@qq.com", null);
                mm.From = Fromma;
                //收件人
                mm.To.Add("1020627112@qq.com");
                //邮箱标题
                mm.Subject = "Hello Dear:";
                mm.IsBodyHtml = true;
                //邮件内容
                mm.Body = "你好Mr流星！";
                //内容的编码格式
                mm.BodyEncoding = System.Text.Encoding.UTF8;
                //mm.ReplyTo = Toma;
                //mm.Sender =Fromma;
                //mm.IsBodyHtml = false;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
                mm.CC.Add(Toma);
                SmtpClient sc = new SmtpClient();
                NetworkCredential nc = new NetworkCredential();
                nc.UserName = "1020627112@qq.com";//你的邮箱地址
                nc.Password = "whl2009zsw2010Z";//你的邮箱密码,这里的密码是xxxxx@qq.com邮箱的密码，特别说明下~
                sc.UseDefaultCredentials = true;
                sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                sc.Credentials = nc;
                //如果这里报mail from address must be same as authorization user这个错误，是你的QQ邮箱没有开启SMTP，
                //到你自己的邮箱设置一下就可以啦！在帐户下面,如果是163邮箱的话，下面该成smtp.163.com
                sc.Host = "smtp.qq.com";
                sc.Send(mm);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
