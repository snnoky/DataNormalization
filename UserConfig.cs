using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1MIW
{
    public class UserConfig
    {
        public string DataName;
        public string DataSaveName;
        public string DataPath;
        public string DataTypesPath;
        public string DataSeparator;
        public int DataNormalizationFrom;
        public int DataNormalizationTo;
        public List<DataSymbolicToNumeric> DataSymbolicsToNumerics;
    }
}
