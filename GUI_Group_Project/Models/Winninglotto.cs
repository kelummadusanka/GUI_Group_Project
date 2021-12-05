using System;
using System.ComponentModel.DataAnnotations;

namespace GUI_Group_Project.Models
{
    public class Winninglotto
    {
        [Key]
        public int LotteryID { get; set; }

        public DateTime Date { get; set; }

        public int No1 { get; set; }

        public int No2 { get; set; }

        public int No3 { get; set; }

        public string Letter { get; set; }

       
    }
}
