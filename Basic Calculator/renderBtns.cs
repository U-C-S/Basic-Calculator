using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Basic_Calculator
{
    class renderBtns
    {
        public static void Main()
        {
            string[,] ButtonData = new string[18, 5]
            {
                {"1", "Btn_num", "1", "0", "#CC73D99D"  },
                {"2", "Btn_num", "1", "1", "#CC73D99D"  },
                {"3", "Btn_num", "1", "2", "#CC73D99D"  },
                {"4", "Btn_num", "2", "0", "#CC73D99D"  },
                {"5", "Btn_num", "2", "0", "#CC73D99D"  },
                {"6", "Btn_num", "2", "0", "#CC73D99D"  },
                {"7", "Btn_num", "3", "0", "#CC73D99D"  },
                {"8", "Btn_num", "3", "0", "#CC73D99D"  },
                {"9", "Btn_num", "3", "0", "#CC73D99D"  },
                {"0", "Btn_num", "4", "1", "#CC73D99D"  },
                {".", "Btn_num", "4", "0", "#CC73D99D"  },
                {"=", "Btn_num", "4", "2", "#CC73D99D"  },
                {"Clear", "Btn_num", "0", "0", "#CC73D99D"  },
                {"+", "Btn_num", "1", "3", "#CC73D99D"  },
                {"-", "Btn_num", "2", "3", "#CC73D99D"  },
                {"x", "Btn_num", "3", "3", "#CC73D99D"  },
                {"/", "Btn_num", "4", "3", "#CC73D99D"  },
                {"Back", "Btn_num", "1", "3", "#CC73D99D"  },
            };
            //ButtonsData.Add(new SingleButton() { Content="1",Click="Btn_num", GridRow="1", GridColumn= "0", Background="#CC73D99D" });
            foreach (string[] btn in ButtonData)
            {

            }
        }

    }

}
