namespace storeModel
{
    public class Customer
    {   public int CustID {get;set;}
        public string CustName { get; set; }
        public string CustAddress { get; set; }
        public string CustPhoneNumber { get; set; }
        public List<Orders> Orders { get; set; }
        public Customer()
        {   
            CustID=1;
            CustName = "Abdu";
            CustAddress = "24 st Washington" ;
            CustPhoneNumber = "202 234 5678" ;
            Orders = new List<Orders>(){new Orders() };
        }
        public override string ToString()
        {
            return $"Name: {CustName}\nAddress: {CustAddress}\nEmailPhoneNumber: {CustPhoneNumber}";
        }
    }

}

