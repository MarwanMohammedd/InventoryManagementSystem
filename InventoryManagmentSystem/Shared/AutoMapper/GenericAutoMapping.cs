using AutoMapper;

namespace InventoryManagmentSystem.Shared.AutoMapper;

public class GenericAutoMapping<Source, Destination> : Profile where Source : class
{
    public GenericAutoMapping()
    {
        CreateMap<Source, Destination>().ReverseMap();
    }
}