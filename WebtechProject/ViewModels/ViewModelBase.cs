using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WebtechProject
{
    /// <summary>
    /// Base class for all ViewModel
    /// </summary>
	public class ViewModelBase : INotifyPropertyChanged
	{
        /// <summary>
        /// The event which is raised, if property of an object changed
        /// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// If property has changed, raise the PropertyChanged event
        /// </summary>
        /// <param name="propertyName">The property</param>
		protected virtual void OnPropertyChanged(String propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
