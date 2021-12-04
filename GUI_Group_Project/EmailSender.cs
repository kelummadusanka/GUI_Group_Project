using System;
using System.Net.Mail; // to send email
using System.Net; // to send email
using System.Windows;

namespace GUI_Group_Project
{
    public class EmailSender
    {

        public static void Emailsender(string email, string username, string password)
        {
            try
            {
                SmtpClient clienDetails = new SmtpClient();
                clienDetails.Port = 587;
                clienDetails.Host = "smtp.gmail.com";
                clienDetails.EnableSsl = true;
                clienDetails.DeliveryMethod = SmtpDeliveryMethod.Network;
                clienDetails.UseDefaultCredentials = false;
                clienDetails.Credentials = new NetworkCredential("buyyourticketstoday@gmail.com", "Lottery@12345");

               // ProgressBarIncrement1(SavingProgressBar);

                MailMessage mailDetails = new MailMessage();
                mailDetails.From = new MailAddress("buyyourticketstoday@gmail.com");
                mailDetails.To.Add(email);// this placed should be relpaced by buyer email--------------------------->>>>>

                mailDetails.Subject = "Signup Detail of Lottery App";
                mailDetails.Body = "Lottery App \n\n Successfully Registerd to our Lottery App \n\n username : " + username+"\n password : "+password+"\n\n This is a system generated email, please don't reply."; //this is he email content . must be fill wih suiaable data --------------------------->>>>>


                //ProgressBarIncrement1(SavingProgressBar);

                clienDetails.Send(mailDetails);

                // ProgressBarIncrement1(SavingProgressBar);//saving progress bar incememt
                Console.WriteLine("Send email "+ mailDetails.Body);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Faild Send email "+ ex);
                MessageBox.Show(ex.Message);
                //SavingProgressBarLabel.Text = "Faild to send Email, Check Your Internet Connection!!!";
            }

        }
    }
}
