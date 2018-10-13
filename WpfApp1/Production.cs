﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    [Database]
    public class Production : DataContext
    {


        public Production() : base("Data Source=WALK-SERVER;Initial Catalog=PRODUCTION;Persist Security Info=True;Integrated Security=true;") { }

        public Table<Vamvakera> Vamvakera;
        public Table<Wool> Wool;
        public Table<WarehouseChanges> WarehouseChanges;




    }

}
