
namespace xtrade.Models
{
    public enum Classification { Automotive, Furniture, ClothesNShoes, Electronics, Books, Services, Miscellaneous};
    
    public class Item
    {
        static int item_count = 1;

        //User enters
        public string name { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public Classification category { get; set; }
        
        //Set automatically
        public int id { get; set; }
        public bool bIsAvailable;
        public User seller { get; set; }
        public User buyer { get; set; }              
        
        public System.DateTime postedOn;

        public int nViews;
        public Item()
        {
            bIsAvailable = true;
            nViews = 0;
            postedOn = new System.DateTime();
            postedOn = System.DateTime.Now;
            id = item_count++;
            //seller = currentUser; 
        }

        public void buy(ref User Buyer)
        {
            bIsAvailable = false;
            //buyer = Buyer; 
        }
    }
}
