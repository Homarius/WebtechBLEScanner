using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace WebtechProject
{
    /// <summary>
    /// ViewModel for AddMockPage
    /// </summary>
    public class AddMockupPageViewModel : ViewModelBase
    {
        private DateTime _date;

        /// <summary>
        /// The date for which the point will be created
        /// </summary>
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        private TimeSpan _time;

        /// <summary>
        /// The time for which the point will be created
        /// </summary>
        public TimeSpan Time
        {
            get { return _time; }
            set { _time = value; }
        }

        private double _speed;

        /// <summary>
        /// The speed value of the point which will we created
        /// </summary>
        public double Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        private int _cadence;

        /// <summary>
        /// The cadence value of the point which will be created
        /// </summary>
        public int Cadence
        {
            get { return _cadence; }
            set { _cadence = value; }
        }

        private ICommand _createMockupPointCommand;

        /// <summary>
        /// Command for the button to save the point
        /// </summary>
        public ICommand CreateMockupPointCommand
        {
            get { return _createMockupPointCommand; }
            set { _createMockupPointCommand = value; }
        }

        /// Initializes a new instance of the <see cref="T:WebtechProject.AddMockupPageViewModel"/> class.
        /// Sets up most important objects
        public AddMockupPageViewModel()
        {
            CreateMockupPointCommand = new Command(createPoint);
            Date = DateTime.Now;
            Time = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0);
            Speed = 30;
            Cadence = 120;
        }

        private void createPoint()
        {
            App.Database.SaveItem(new SensorData(new DateTime(Date.Year, Date.Month, Date.Day, Time.Hours, Time.Minutes, 0), Speed, Cadence));
            MessagingCenter.Send(ApplicationContext.MainPageHub, "UpdateGraphs");
            MessagingCenter.Send(ApplicationContext.AddPointPage, "NavigateBack");
        }
    }
}
