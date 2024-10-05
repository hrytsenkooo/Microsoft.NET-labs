using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace laba1
{
    public class MenuItem
    {
        private readonly string _title;
        private readonly Action _selectedAction;
        public MenuItem(string title, Action selectedAction)
        {
            _title = title;
            _selectedAction = selectedAction;
        }
        internal void ExecuteSelectedAction()
        {
            _selectedAction.Invoke();
        }
        public override string ToString()
        {
            return _title;
        }
    }
}