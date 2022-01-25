namespace storeModel
{
    public class Orders
    {
        private int TotalPrice;
        public int storeFront
        {
            get { return TotalPrice; }
            
        }


        //Full property is needed to add validation
        public List<items> items
        {
            get { return   items; }
            //You can not order more than 10 items at time
            set
            {
                if (value < 10)
                {
                    items = value;
                }
                else
                {
                    throw new Exception("You cannot order more than 10!");
                }
            }
        }
        // public int TotalPrice
        // {
        //     get { return Price; }
        //     set { Quantity* Price; }

        // }

    }
    
}