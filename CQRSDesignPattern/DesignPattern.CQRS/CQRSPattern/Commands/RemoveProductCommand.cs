namespace DesignPattern.CQRS.CQRSPattern.Commands
{
    public class RemoveProductCommand
    {
        public RemoveProductCommand(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
