namespace storeModel
{
    public class Customer
    {   public int CustID {get;set;}
        public string CustName { get; set; }
        public string CustAddress { get; set; }
        public string CustPhone { get; set; }
        public List<Orders> Orders { get; set; }
        public Customer()
        {
            CustName = " ";
            CustAddress = "24 st Washington" ;
            CustPhone = "202 234 5678" ;
            Orders = new List<Orders>(){new Orders() };
        }
        public override string ToString()
        {
            return $"CustID: {CustID}\nName: {CustName}\nAddress: {CustAddress}\nPhoneNumber: {CustPhone}";
        }
    }

}

