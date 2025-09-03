using System.Text;

namespace DesignPattern.Composite.CompositePattern
{
    public class ProductComposite : IComponent
    {
       

        public int Id { get; set; }
        public string Name { get; set; }

        private List<IComponent> _components;

        public ProductComposite(int id, string name)
        {
            Id = id;
            Name = name;
            _components = new List<IComponent>();
        }

        public ICollection<IComponent> Components => _components;
        public void Add(IComponent component)
        {
            _components.Add(component);
        }
        public string Display()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"<div class='text-success'>{Name} ({TotalCount()})</div>");
            stringBuilder.Append("<ul class='list-group list-group-flush ms-3'>");
            foreach (var item in _components)
            {
                stringBuilder.Append(item.Display());
            }
            stringBuilder.Append("</ul>");

            return stringBuilder.ToString();
        }

        public int TotalCount()
        {
            return _components.Sum(x => x.TotalCount());
        }
    }
}
