using System;
using System.Collections.Generic;
using System.Text;

namespace WebtechProject
{
    /// <summary>
    /// Class responsible for providing globally needed info
    /// </summary>
    public static class ApplicationContext
	{
		private static MainHub mainPageHub; //object needed to be able to display alerts 

        /// <summary>
        /// Stores the instance of the MainPage to be able to display alerts
        /// </summary>
		public static MainHub MainPageHub
		{
			get { return mainPageHub; }
			set { mainPageHub = value; }
		}

        private static AddMockupPage addPointPage;

        public static AddMockupPage AddPointPage
        {
            get { return addPointPage; }
            set { addPointPage = value; }
        }

		private static MainHubViewModel mainPage;

        /// <summary>
        /// Stores the instance of the MainHubViewModel
        /// </summary>
		public static MainHubViewModel MainPage
		{
			get { return mainPage; }
			set { mainPage = value; }
		}
	}
}
