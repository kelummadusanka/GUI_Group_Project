using System.ComponentModel.DataAnnotations;

namespace GUI_Group_Project.Models
{
    public class Boughtlotto
    {
        [Key]
        public int BoughtlottoID { get; set; }
                
        public int LotteryID { get; set; }

        public int No1 { get; set; }

        public int No2 { get; set; }

        public int No3 { get; set; }

        public string Letter { get; set; }

        public int UserID { get; set; }

     
    }
}
