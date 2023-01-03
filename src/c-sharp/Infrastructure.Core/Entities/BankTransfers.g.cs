// *******************************************************************
//	GENERATED CODE. DOT NOT MODIFY MANUALLY AS CHANGES CAN BE LOST!!!
//	USE A PARTIAL CLASS INSTEAD
// *******************************************************************
using Infrastructure.Core.SharedKernel;
using System.Collections.Generic;

namespace CodeGenerator.Infrastructure.Core.Entities
{
	public partial class BankTransfers : Entity
	{
		#region Constructors
		public BankTransfers()
        	{
            
        	}
		#endregion
		#region Properties
		public string BankTransferId { get; set; }
		public string FromBankAccountId { get; set; }
		public string ToBankAccountId { get; set; }
		public string Amount { get; set; }
		public string TransferDate { get; set; }
		public BankAccount BankAccount { get; set; }
                #endregion
		#region Public Methods
		
    		#endregion

	}
}