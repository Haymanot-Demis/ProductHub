using Application.DTO.Category;
using Application.DTO.Product;
using Application.DTO.User;
using AutoMapper;
using Domain.Entites;

namespace Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateUserDto, UserEntity>().ReverseMap().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => {
            if (srcMember is int value && value == 0)
            {
                return false;
            }
            return srcMember != null;
        }));
        
        CreateMap<UserResponseDto, UserEntity>().ReverseMap().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => {
            if (srcMember is int value && value == 0)
            {
                return false;
            }
            return srcMember != null;
        }));
        
        CreateMap<ProductResponseDto, ProductEntity>().ReverseMap().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => {
            if (srcMember is int value && value == 0)
            {
                return false;
            }
            return srcMember != null;
        }));
        
        
        CreateMap<CreateProdDto, ProductEntity>().ReverseMap().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => {
            if (srcMember is int value && value == 0)
            {
                return false;
            }
            return srcMember != null;
        }));
        
        
        CreateMap<CreateCategoryDto, CategoryEntity>().ReverseMap().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => {
            if (srcMember is int value && value == 0)
            {
                return false;
            }
            return srcMember != null;
        }));
        
        CreateMap<CategoryResponseDto, CategoryEntity>().ReverseMap().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => {
            if (srcMember is int value && value == 0)
            {
                return false;
            }
            return srcMember != null;
        }));
    }
}