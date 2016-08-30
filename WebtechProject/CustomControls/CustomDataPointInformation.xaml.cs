using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace WebtechProject
{
    /// <summary>
    /// 
    /// </summary>
    public partial class CustomDataPointInformation : StackLayout
    {
        public IEnumerable<SensorData> Datapoints { get; set; }

        public CustomDataPointInformation()
        {
            InitializeComponent();

            //PointListView.ItemsSource = ApplicationContext.MainPage.SpeedAndCadenceData;
        }
    }
}
