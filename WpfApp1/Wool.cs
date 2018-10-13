using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    [Table(Name = "WarehouseWool")]
    public class Wool
    {

        [Column(IsPrimaryKey = true, IsDbGenerated = false)] public string ColourNo { get; set; }
        [Column] public string ColourName { get; set; }
        [Column] public Nullable<int> A116first { get; set; }
        [Column] public Nullable<int> A116last { get; set; }
        [Column] public Nullable<int> A140first { get; set; }
        [Column] public Nullable<int> A140last { get; set; }
        [Column] public Nullable<int> M128first { get; set; }
        [Column] public Nullable<int> M128last { get; set; }
        [Column] public Nullable<int> M228first { get; set; }
        [Column] public Nullable<int> M228last { get; set; }
        [Column] public Nullable<int> T128first { get; set; }
        [Column] public Nullable<int> T128last { get; set; }
        [Column] public Nullable<int> M132first { get; set; }
        [Column] public Nullable<int> M132last { get; set; }
        [Column] public Nullable<int> M134first { get; set; }
        [Column] public Nullable<int> M134last { get; set; }
        [Column] public Nullable<int> M244first { get; set; }
        [Column] public Nullable<int> M244last { get; set; }
        [Column] public Nullable<int> M144first { get; set; }
        [Column] public Nullable<int> M144last { get; set; }
        [Column] public Nullable<int> M116first { get; set; }
        [Column] public Nullable<int> M116last { get; set; }
        [Column] public Nullable<int> A132first { get; set; }
        [Column] public Nullable<int> A132last { get; set; }
        [Column] public Nullable<int> M156first { get; set; }
        [Column] public Nullable<int> M156last { get; set; }
        [Column] public Nullable<int> P120first { get; set; }
        [Column] public Nullable<int> P120last { get; set; }
        [Column] public Nullable<bool> Inactive { get; set; }

    }
}
