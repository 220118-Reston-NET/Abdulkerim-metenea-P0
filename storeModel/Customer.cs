namespace storeModel
{
    public class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string EmailPhoneNumber { get; set; }

        public List<Orders> Orders
        {
            get { return Orders; }
            set
            {
                if (value.Count > 10)
                {
                    Orders = value;
                }
                else
                {
                    throw new Exception("Sorry Out of Store!");
                }
            }

        }
        public Customer()
        {
            Name = "Jhone";
            Address = "5672 st NY";
            EmailPhoneNumber = "cust@gmail.com";
            Orders = new List<Orders>()
            {
                new Orders()
            };
        }
    }
}

