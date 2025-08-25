using DesignPattern.CQRS.CQRSPattern.Results;
using DesignPattern.CQRS.DAL;
using System.Collections.Generic;
using System.Linq;

namespace DesignPattern.CQRS.CQRSPattern.Handlers
{
    public class GetProductQueryHandler
    {
        private readonly Context _context;

        public GetProductQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetProductQueryResult> Handle()
        {
            var values = _context.products.Select(x=>new GetProductQueryResult()
            {
                //resultta productıd olarkata girilebilir. Ancak burada girmesekte problem olmayacağını göstermek adına yazdım.
                ID=x.ProductID,
                Price=x.Price,
                ProductName=x.Name,
                Stock=x.Stock,

            }).ToList();

            return values;
        }
    }
}
