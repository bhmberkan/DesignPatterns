namespace DesignPattern.TemplateMethod.TemplatePattern
{
    public abstract class NetflixPlans
    {
        public void CreatePlan()
        {
            PlanType(string.Empty);
            CountPerson(0);
            Price(0);
            Resolution(string.Empty);
            Content(string.Empty);
            // ilk başta boş atadık daha sonra planlara göre içeriklerini  istediğimiz gibi değiştiriyor olabilmeliyiz.
        }

        public abstract string PlanType(string planType);
        public abstract int CountPerson(int countPerson);
        public abstract double Price(double price);
        public abstract string Resolution(string resolution);
        public abstract string Content(string content);

        /* public abstract string PlanType { get; set; }
        public abstract int CountPerson { get; set; }
        public abstract double Price { get; set; }
        public abstract string Resolution { get; set; }
        public abstract string Content { get; set; }
        */
    }
}
