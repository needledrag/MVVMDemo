using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Microsoft.Maui.Graphics.Platform;
using CommunityToolkit.Mvvm.Messaging;

namespace MVVMDemo.ViewModels
{
    public partial class SingletonMsgRecieverViewModel : AppViewModelBase
    {
        [ObservableProperty]
        private int _count;

        public SingletonMsgRecieverViewModel()
        {
            WeakReferenceMessenger.Default.Register<Messages.MyMessage>(this, (r, m) =>
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Count += m.Value;
                    Console.WriteLine($"Singleton Subscriber Message recieved : {DateTime.UtcNow.Ticks}");
                });
            });
        }
        [RelayCommand]
        private async Task LoadSubscriber()
        {
            await NavigationService.PushAsync(new Views.TransientMsgRecieverView(1));
        }

       
    }
}

