using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace recharge_system.Common
{
    [Serializable]
    public class MyCustomContentState : CustomContentState
    {
        private int _selectedItemIndex = -1;

        private TabControl _dateTabControl;

        public MyCustomContentState(int selectedItemIndex, TabControl dateTabControl)
        {
            _selectedItemIndex = selectedItemIndex;
            _dateTabControl = dateTabControl;
        }

        public override string JournalEntryName
        {
            get
            {
                return "Journal Entry SelectedTabItemIndex " + this._selectedItemIndex;
            }
        }

        public override void Replay(NavigationService navigationService, NavigationMode mode)
        {
            _dateTabControl.SelectedIndex = this._selectedItemIndex;
        }
    }
}
