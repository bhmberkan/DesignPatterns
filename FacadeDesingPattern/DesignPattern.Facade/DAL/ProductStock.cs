namespace DesignPattern.Facade.DAL
{
    public class ProductStock
    {
        Context context = new Context();

        public void StockDecrease(int id,int amount)
        {
            var value = context.products.Find(id);
            value.ProductStock -= amount;
            context.SaveChanges();
        }
    }
}
