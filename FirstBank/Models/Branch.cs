using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstBank.Models
{
    public class Branch
    {
        public int BranchId { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        public int? BankerId { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual Banker Administrator { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}