using System;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MVVMDemo.Messages
{
 
    public class MyMessage : ValueChangedMessage<int>
    {
        public MyMessage(int value) : base(value)
        {
        }
    }
 

}

