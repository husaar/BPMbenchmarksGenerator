using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMbenchmarksGenerator.Interfaces;
using BPMbenchmarksGenerator.Models;
using BPMbenchmarksGenerator.Cmds;
using System.Windows.Input;

namespace BPMbenchmarksGenerator.ViewModel
{
    class MainWindowViewModel
    {

        private ICommand _exitCommand = null;
        public ICommand ExitCmd => _exitCommand ?? (_exitCommand = new ExitCommand());

        public MainWindowViewModel()
        {

        }
    }
}
