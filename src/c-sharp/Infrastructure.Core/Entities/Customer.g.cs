// *******************************************************************
//	GENERATED CODE. DOT NOT MODIFY MANUALLY AS CHANGES CAN BE LOST!!!
//	USE A PARTIAL CLASS INSTEAD
// *******************************************************************
using Infrastructure.Core.SharedKernel;
using System.Collections.Generic;

namespace CodeGenerator.Infrastructure.Core.Entities
{
	public partial class Customer : Entity
	{
		#region Constructors
		public Customer()
        	{
            
        	}
		#endregion
		#region Properties
		public string CustomerId { get; set; }
		public string CustomerCode { get; set; }
		public string CompanyName { get; set; }
		public string ContactName { get; set; }
		public string ContactTitle { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string PostalCode { get; set; }
		public string Telephone { get; set; }
		public string Fax { get; set; }
		public string CountryId { get; set; }
		public string Photo { get; set; }
		public string IsEnabled { get; set; }
		public Country Country { get; set; }
                
                public List<BankAccount> BankAccounts { get; set; }
		
                public List<Order> Orders { get; set; }
		#endregion
		#region Public Methods
		
    		#endregion

	}
}