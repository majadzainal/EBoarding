using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBoarding
{
    public class PATH {
        public string counterPrintPath = Environment.CurrentDirectory + "/printCounter.txt";
        public string ConfigPath = Environment.CurrentDirectory + "/config.txt";
    }
   
    public class ValidResponse
    {
        public string NUM_CODE = string.Empty;
        public string BOOK_CODE = string.Empty;
        public string SHIP_NO = string.Empty;
        public string SHIP_NAME = string.Empty;
        public string VOYAGE_NO = string.Empty;
        public string YEAR = string.Empty;
        public string ORG = string.Empty;
        public string ORG_NAME = string.Empty;
        public string ORG_CALL = string.Empty;
        public string DES = string.Empty;
        public string DES_NAME = string.Empty;
        public string DES_CALL = string.Empty;
        public string DEP_DATE = string.Empty;
        public string DEP_TIME = string.Empty;
        public string ARV_DATE = string.Empty;
        public string ARV_TIME = string.Empty;
        public string SUBCLASS = string.Empty;
        public string MAX_PRINT_TICKET = string.Empty;
        public string MAX_CHECKIN = string.Empty;
        public string MIN_CHECKIN = string.Empty;
        public string CLASS = string.Empty;
        public string FAMILY = string.Empty;
        public string STATUS = string.Empty;
        public string TRANSACTION_DATE = string.Empty;
        public string LOCATION = string.Empty;
        public string error_code = string.Empty;
        //public List<PAX_DATA> PAX_LIST = new List<PAX_DATA>();
        public string[,] PAX_LIST = {
                                { "ABNER P WORIASI", "9105011809900001", "A", "6", "6003", "B", "M", "111563200002342", "0", "5", "774000", "0", "774000" },
                                { "ABNER P WORIASI 2", "9105011809900002", "A", "6", "6003", "B", "M", "111563200002343", "0", "5", "774000", "0", "774000" },
                                { "ABNER P WORIASI 3", "910501180990002", "A", "6", "6003", "B", "M", "111563200002343", "0", "5", "774000", "0", "774000" },
                            };
    }
    public class PAX_DATA
    {
        public string arr0 = string.Empty;
        public string arr1 = string.Empty;
        public string arr2 = string.Empty;
        public string arr3 = string.Empty;
        public string arr4 = string.Empty;
        public string arr5 = string.Empty;
        public string arr6 = string.Empty;
        public string arr7 = string.Empty;
        public string arr8 = string.Empty;
        public string arr9 = string.Empty;
        public string arr10 = string.Empty;
        public string arr11 = string.Empty;
        public string arr12 = string.Empty;
        public string arr13 = string.Empty;
        public string arr14 = string.Empty;
        public string arr15 = string.Empty;
        public string arr16 = string.Empty;
    }

    public class TICKET_DATA
    {
        public string BOOK_CODE = string.Empty;
        public string TICKET_NO = string.Empty;
        public string ID_NUMBER = string.Empty;
        public string PAX_NAME = string.Empty;
        public string PAX_TYPE = string.Empty;
        public string SHIP_NO = string.Empty;
        public string SUBCLASS = string.Empty;
        public string DEP_DATE = string.Empty;
        public string ORG = string.Empty;
        public string DES = string.Empty;
        public string PRINT_BY = string.Empty;
        public string SHIP = string.Empty;
        public string DECK_CABIN = string.Empty;
        public string error_code = string.Empty;
        public bool is_print = false;
    }
}
