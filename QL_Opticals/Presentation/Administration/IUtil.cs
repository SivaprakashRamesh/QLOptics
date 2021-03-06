using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QL_Opticals.Presentation.Administration
{
    interface IUtil
    {
        void MovePreviousRecord();
        void MoveNextRecord();
        void MoveLastRecord();
        void MoveFirstRecord();
        void FindMode();
        void AddMode();
        void PrintLayout();
        void PreviewLayout();
        void RefreshRecord();
    }
}
