using System;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SkiaSharp;

namespace MVVMDemo.ViewModels
{

	public partial class TransientMsgRecieverViewModel : AppViewModelBase
	{
       
        private int _internalCount = 0;
        
        public TransientMsgRecieverViewModel()
        {
 
            WeakReferenceMessenger.Default.Register<TransientMsgRecieverViewModel, Messages.MyMessage>(this, (r, m) =>
            {
                _internalCount += m.Value;
                Console.WriteLine($"Transient Subscriber Message recieved : {DateTime.UtcNow.Ticks}");
            });
        }

      
        [RelayCommand]
        private async void LoadMessageSender()
        {
            await NavigationService.PushAsync(new Views.MessageSenderView(1));
        }

        [RelayCommand]
        private async void NavBack()
        {
            await NavigationService.PopAsync();
        }
    }
}

