using DesignPattern.Facade.DAL;

namespace DesignPattern.Facade.FacadePattern
{
    public class OrderFacade
    {
        Order order = new Order();
        OrderDetail orderDetail = new OrderDetail();
        ProductStock productStock = new ProductStock();

        AddOrder addOrder = new AddOrder();
        AddOrderDetail addOrderDetail = new AddOrderDetail();

        public void CompleteOrderDetail(int CustomerID, int ProductID, int OrderID, int ProductCount, decimal ProductPrice)
        {
          


            orderDetail.CustomerID = CustomerID;
            orderDetail.OrderID = OrderID;
            orderDetail.ProductID = ProductID;
            orderDetail.ProductCount = ProductCount;
            orderDetail.ProductPrice = ProductPrice;
            decimal totalProductPrice = ProductCount * ProductPrice;
            orderDetail.ProductTotalPrice = totalProductPrice;
            addOrderDetail.AddNewOrderDetail(orderDetail);

            productStock.StockDecrease(ProductID, ProductCount);
        }

        public void CompleteOrder(int CustomerID)
        {
            order.CustomerID = CustomerID;
            addOrder.AddNewOrder(order);
        }
    }
}
