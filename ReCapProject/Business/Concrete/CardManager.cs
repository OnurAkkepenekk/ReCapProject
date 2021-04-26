using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CardManager : ICardService
    {
        ICardDal _cardDal;

        public CardManager(ICardDal cardDal)
        {
            _cardDal = cardDal;
        }

        public IResult Add(Card card)
        {
            _cardDal.Add(card);
            return new SuccessResult("Kart Ekleme Başarılı..");
        }

        public IResult Delete(Card card)
        {
            _cardDal.Delete(card);
            return new SuccessResult("Kart Silme Başarılı..");
        }

        public IDataResult<Card> Get(int id)
        {
            var result = _cardDal.Get(p => p.CustomerId == id);
            return new SuccessDataResult<Card>(result);
        }

        public IDataResult<List<Card>> GetAll()
        {
            return new SuccessDataResult<List<Card>>(_cardDal.GetAll().ToList());
        }

        public IDataResult<List<Card>> GetAllByCustomerId(int customerId)
        {
            var result = _cardDal.GetAll(p => p.CustomerId == customerId);
            return new SuccessDataResult<List<Card>>(result);
        }

        public IResult Update(Card card)
        {
            _cardDal.Update(card);
            return new SuccessResult("Kart Güncelleme Başarılı..");
        }
    }
}
