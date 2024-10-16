namespace CA_ApplicationLayer.Contracts
{
    public interface IMapper<TDto, TOutput>
    {
        TOutput ToEntity(TDto dto);
    }
}
