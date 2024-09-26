using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recharge_system.ViewModel
{
    internal class RadioPageVM:NotifyBase
    {
        private ObservableCollection<Model.RadioModel> _radioModels;


        public ObservableCollection<Model.RadioModel> RadioModels
        {
            get { return _radioModels; }
            set { _radioModels = value; OnPropertyChanged(); }

        }

        public RadioPageVM()
        {
            RadioModels = new ObservableCollection<Model.RadioModel>() 
            {
                new Model.RadioModel(),
                new Model.RadioModel()
            };
        }


    }
}
