using AutoMapper;
namespace CodeGenerator.Api.V1.mappers;

public class TestMapper : Profile
{
    public TestMapper()
    {
        // CreateMap<Test, TestMessage>()
        //     .ForMember(
        //         d => d.Name,
        //         d => d.MapFrom(s => s.Name)
        //     );
    }
}