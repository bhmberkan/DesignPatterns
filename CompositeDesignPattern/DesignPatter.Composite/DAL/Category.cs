namespace DesignPatter.Composite.DAL
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int UpperCategoryID { get; set; } // bir üstte bulunan kategory ıdsi ne ?
        public List<Product> products { get; set; }
    }
}
