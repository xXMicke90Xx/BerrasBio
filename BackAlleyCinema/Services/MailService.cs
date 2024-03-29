﻿using System.Net.Mail;

namespace BackAlleyCinema.Services
{
    public static class MailService
    {
        public static async Task MailSender(string mailAddress, string movieTitle, string seatsTaken, int saloonId, string movieStart)
        {
            using (var smtp = new SmtpClient("smtp-mail.outlook.com")) //Försöker skicka ett Mail till den som registrerat biljetterna
            {

                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("Micke.Handledning@hotmail.com", "M1ke1sthebest2", "smtp-mail.outlook.com");


                var msg = new MailMessage
                {

                    Body = $"Här är en biljett för att se {movieTitle}! \n" +
                    $"Sätena är {seatsTaken.Substring(0, seatsTaken.Length - 1)} \n" +
                    $"Salongen är {saloonId} \n" +
                    $"Tiden är {TimeOnly.FromDateTime(DateTime.Parse(movieStart))}\n" +
                    $"Välkomna!\n",
                    Subject = "Biljetter",
                    From = new MailAddress("Micke.Handledning@hotmail.com"),

                };
                msg.To.Add(mailAddress);
                await smtp.SendMailAsync(msg);

            }
        }
    }
}
