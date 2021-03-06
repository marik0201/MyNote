﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Drawing;
using System.Data;
using System.Data.SqlClient;

namespace MyNote
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public UserDbContext db = new UserDbContext();
        public MainWindow(User user1)
        {
            InitializeComponent();
            user = user1;
            username.Text = "Привет, " + user.FirstName+ " :)";
            HelloText.Text = "Привет, " + user.FirstName + "!";
            var count = db.Notes.Where(u => u.User.Id == user.Id).Count();
            HelloTextNote.Text = "Заметок создано: " + count ;
            var count2 = db.Notices.Where(u => u.User.Id == user.Id).Count();
            HelloNotice.Text = "Напоминаний создано: " + count2;
            var count3 = db.Archives.Where(u => u.User.Id == user.Id).Count();
            HelloArchive.Text = "Заметок в архиве: " + count3;
            manwnd = this;

        }

        public static User user = new User();
        
       public static Window manwnd;

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemNote":
                    usc = new NoteControl();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemNotice":
                    usc = new NoticeControl();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemArchive":
                    usc = new ArchiveControl();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemSettings":
                    usc = new Settings();
                    GridMain.Children.Add(usc);
                    break;
                default:
                    break;
            }
        }

        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ChangeUser(object sender, RoutedEventArgs e)
        {
            SignIn change = new SignIn();
            change.Show();
            this.Close();
            
        }
        
        private void Tray_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;

        }
        
        private void DragEvent(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
