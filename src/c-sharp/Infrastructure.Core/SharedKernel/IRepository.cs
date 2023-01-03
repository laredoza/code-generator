namespace Infrastructure.Core.SharedKernel
{
    public interface IRepository
    {      
        IUnitOfWork UnitOfWork { get; }         
    }
}