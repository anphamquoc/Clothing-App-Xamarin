﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ClothingApp.Model;

namespace ClothingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailOrder : ContentPage
    {
        public DetailOrder()
        {
            InitializeComponent();
            List<HomeItem> homeItems = new List<HomeItem> {
                new HomeItem("dress_01.jfif", "Đầm đẹp đón xế Đầm đẹp đón xế Đầm đẹp đón xế"),
                new HomeItem("dress_02.jfif", "Đầm quá đẹp luôn"),
                new HomeItem("dress_03.jfif", "Đầm này quá chất"),
                new HomeItem("dress_04.jfif", "Đầm kia khỏi chê")
            };

            listItems.ItemsSource = homeItems;
        }

        private async void GoBack_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Order");
        }
    }
}