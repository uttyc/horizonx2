﻿using Horizonx2.Models;
using Horizonx2.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Horizonx2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Favs : ContentPage
    {
        public Favs()
        {
            InitializeComponent();
            FavList.RefreshCommand = new Command(() =>
            {
                //Do your stuff.
                RefreshList();
                FavList.IsRefreshing = false;
            });
            //FavList.ItemTemplate = new DataTemplate(typeof(EntryViewCell));


            RefreshList();
        }
        public void RefreshList()
        {
            var entries = new List<EksiEntry>();
            using (var con = new SQLiteConnection(App.FilePath))
            {
                entries = con.Table<EksiEntry>().ToList();
            }
            FavList.ItemsSource = entries;
        }
        private void FavList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var entry = e.SelectedItem as EksiEntry;
            //using(var con = new SQLiteConnection(App.FilePath))
            //{
            //    con.DeleteAll<EksiEntry>();
            //}
            //DisplayAlert(entry.Header, entry.Content, "Tamam");
           Navigation.PushAsync(new EksiEntryView(entry));


        }
        //private void FavList_ItemTapped(object sender, TappedEventArgs e)
        //{
        //    var entry = e
        //}
    }
}