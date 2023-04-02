using System;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SkiaSharp;

namespace MVVMDemo.ViewModels
{
    public partial class MessageSenderViewModel : AppViewModelBase
    {

        [RelayCommand]
        private async void SendMessage()
        {
            // send 1 to subscribers
            WeakReferenceMessenger.Default.Send<MVVMDemo.Messages.MyMessage>(new Messages.MyMessage(1));
           
            await NavigationService.PopAsync(true);
        }

    }
}

