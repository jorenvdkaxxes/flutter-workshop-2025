using AutoMapper;

namespace Common.Application;

public interface IMapFrom<T>
{
    void Mapping(Profile mapper) => mapper.CreateMap(typeof(T), GetType());
}