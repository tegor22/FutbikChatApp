using System;
using System.Collections.Generic;
using System.Text;

namespace FutbikApp.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Chat,
        User
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
