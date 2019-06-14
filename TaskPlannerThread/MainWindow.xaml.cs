using DataPlannerThread.DataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskPlannerThread.Models;

namespace TaskPlannerThread
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SendMassege()
        {
            MailAddress from = new MailAddress("Saparbek28@gmail.com", "Saparbek");
            MailAddress to = new MailAddress("gvo_step2018@mail.ru");
            MailMessage message = new MailMessage(from, to);
            message.Subject = "yes its working!!";
            message.Body = "OMG ITS WORKING !!!!";
            message.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");            
            smtp.Credentials = new NetworkCredential("Saparbek28@gmail.com","saparbek");
            smtp.EnableSsl = true;
            smtp.Send(message);
            Console.Read();

        }

        private void Download()
        {
            WebClient web = new WebClient();
            web.DownloadFileAsync(new System.Uri("http://www.sayka.in/downloads/front_view.jpg"),"D:\\Images\\front_view.jpg");
        }

        private void TimeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (var context = new DataContext())
            {
                var times = context.Works.ToList();
                foreach (var time in times)
                {
                    if (time.DateTime <= DateTime.Now)
                    {
                        switch (time.Timer)
                        {
                            case 0: time.DateTime = time.DateTime.AddDays(7);
                                break;
                            case 1: time.DateTime = time.DateTime.AddMonths(12);
                                break;
                            case 2: time.DateTime = time.DateTime.AddYears(1);
                                break;

                        }
                    }
                }
                context.SaveChanges();
            }
        }

        private void WorkTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (var context = new DataContext())
            {
                var Does = context.Works.ToList();
                foreach (var Do in Does)
                {
                    switch (Do.Do)
                    {
                        case 0: var SendMassage = new Thread(SendMassege);
                            SendMassage.Start();
                            MessageBox.Show("Message is send");
                            break;
                        case 2: var download = new Thread(Download);
                            download.Start();
                            MessageBox.Show("Download is dowloading");
                            break;
                    }
                }               
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var time = new Time
            {
                DateTime = (DateTime)calendar.SelectedDate,
                Timer = TimeComboBox.SelectedIndex,
                Do = WorkTypeComboBox.SelectedIndex
            };

            using (var context = new DataContext())
            {
                context.Works.Add(time);
                context.SaveChanges();
            }
        }

    }
}
