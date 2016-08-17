using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whiskey.ViewModel;
using Xamarin.Forms;

namespace Whiskey.View
{
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
            this.BindingContext = new HomeViewModel();
        }
    }
}
