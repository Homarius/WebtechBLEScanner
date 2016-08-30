using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WebtechProject
{
    /// <summary>
    /// Custom control which handles all task referring the mockup
    /// </summary>
    public partial class CustomMockupControl : StackLayout
    {
        /// <summary>
        /// Initialisation of the CustomMockupControl
        /// </summary>
        public CustomMockupControl()
        {
            InitializeComponent();
        }

        void Add_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(ApplicationContext.MainPageHub, "NavigateTask");
        }

        void AddMultiple_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(ApplicationContext.MainPageHub, "CreatePoints");
        }
    }
}

