﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICardService
    {
        IDataResult<List<Card>> GetAll();
        IDataResult<Card> Get(int id);

        IResult Add(Card card);
        IResult Update(Card card);
        IResult Delete(Card card);

        IDataResult<List<Card>> GetAllByCustomerId(int customerId);
    }
}
