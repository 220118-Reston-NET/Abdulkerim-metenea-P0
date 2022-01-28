namespace storeModel
{
    public class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string EmailPhoneNumber { get; set; }
        private List<Orders> _order;
        public List<Orders> Orders
        {
            get{return _order;}
            set {
                if (value.Count  > 10)
                {
                    _order = value;
                }
                else{
                    throw new Exception("One Customer can not order More Than 10 items!");
                }
            }
        }
        public Customer()
        {
            Name = "Abdu";
            Address = "24 st Washington" ;
            EmailPhoneNumber = "202 234 5678" ;
            _order = new List<Orders>() 
            { 
                 new Orders()
            };
        }
        public override string ToString()
        {
            return $"Name: {Name}\nAddress: {Address}\nEmailPhoneNumber: {EmailPhoneNumber}";
        }
    }

}

