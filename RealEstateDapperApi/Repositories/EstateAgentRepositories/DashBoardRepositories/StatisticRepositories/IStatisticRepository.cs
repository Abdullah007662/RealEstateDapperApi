namespace RealEstateDapperApi.Repositories.EstateAgentRepositories.DashBoardRepositories.StatisticRepositories
{
    public interface IStatisticRepository
    {
        int ProductCountEmployeeId(int id);
        int ProductCountByStatusTrue(int id);
        int ProductCountByStatusFalse(int id);
        int AllProductCount();
        
    }
}
