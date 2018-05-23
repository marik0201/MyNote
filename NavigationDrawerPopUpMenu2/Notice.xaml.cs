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

namespace MyNote
{
    /// <summary>
    /// Interação lógica para UserControlCreate.xam
    /// </summary>
    public partial class NoticeControl : UserControl
    {

        
        public UserDbContext db = new UserDbContext();
        public User user = MainWindow.user;
        public NoticeControl()
        {
            InitializeComponent();
            var noticesList = db.Notices.Where(u => u.User.Id == user.Id).ToList();
            wrapNotice.Children.Clear();
            foreach (var n in noticesList)
            {

                NoticeWrap item = new NoticeWrap();
                item.NoticeText.Text = n.Text;
                item.NoticeDate.Text = n.Time.ToString();

                wrapNotice.Children.Add(item);
            }
        }




        private void AddNotice_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime dateNotice = NoticeData.DisplayDate.Date + NoticeTime.SelectedTime.Value.TimeOfDay;
            string noticeText = NoticeText.Text;
            if (noticeText!="" && NoticeData!=null)
            {
                Notice notice = new Notice
                {
                    Text = noticeText,
                    Time = dateNotice,
                    User_Id = user.Id
                };
                db.Notices.Add(notice);
                db.SaveChanges();
                AddNoticeChildren();
                ResetNotice();
            }
        }

        private void AddNoticeChildren()
        {
            wrapNotice.Children.Clear();
            var  noticesList = db.Notices.Where(u => u.User.Id == user.Id).ToList();
            foreach (var n in noticesList)
            {
                
                NoticeWrap item = new NoticeWrap();
                item.NoticeText.Text = n.Text;
                item.NoticeDate.DataContext = n.Time;

                wrapNotice.Children.Add(item);
            }
        }

        private void ResetNotice()
        {
            NoticeText.Text = "";
            NoticeData.Text = "";
            NoticeTime.Text = "";
        }
    }
}
