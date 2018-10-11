using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BPMbenchmarksGenerator.Cmds
{
    internal class ExitCommand : CommandBase
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            MainWindow mw = (MainWindow)parameter;
            mw.Close();
        }

    }
}
