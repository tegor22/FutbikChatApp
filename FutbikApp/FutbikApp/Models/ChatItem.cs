using Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FutbikApp.Models
{
    public class ChatItem: MessageDto
    {
        public Thickness BlockMargin { get => this.IsOwn ? new Thickness(100, 5, 5, 5) : new Thickness(5, 5, 100, 5); }
        public Color BlockColor { get => this.IsOwn ? Color.FromHex("#7FB9BABB") : Color.FromHex("#7F49A7F2"); }
    }
}
