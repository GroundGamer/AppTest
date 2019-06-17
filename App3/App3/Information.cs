using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App3
{
    class Information
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string TextInformation1 { get; set; }
        public string TextInformation2 { get; set; }

        public override string ToString()
        {
            return this.TextInformation1 + "(" + this.TextInformation2 + ")";
        }

    }
}
