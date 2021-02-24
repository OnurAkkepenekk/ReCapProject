﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramewotk
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectDatabaseContext>, IRentalDal
    {
    }
}