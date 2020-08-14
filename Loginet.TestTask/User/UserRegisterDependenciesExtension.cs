using System;
using System.Text;
using AutoMapper;
using Loginet.TestTask.Core.Entities.User;
using Loginet.TestTask.Core.Entities.User.Manager;
using Loginet.TestTask.Core.Entities.User.Repository;
using Loginet.TestTask.Core.Entities.User.Repository.Implementation;
using Loginet.TestTask.User.Dto;
using Microsoft.Extensions.DependencyInjection;

namespace Loginet.TestTask.User
{
    /// <summary>
    /// Класс-расширение для инкапсуляции регистрации различных зависимостей для пользователей
    /// </summary>
    public static class UserRegisterDependenciesExtension
    {
        /// <summary>
        /// Добавление зависимостей для альбомов
        /// </summary>
        /// <param name="services">Коллекция зависимостей</param>
        public static void AddUserDependencies(this IServiceCollection services)
        {
            services.AddSingleton<UserManager>();
            services.AddSingleton<IUserRepository, HttpUserRepository>();
        }

        /// <summary>
        /// Добавление маппинга для моделей связанных с пользователями
        /// </summary>
        /// <param name="expression">Конфигуратор маппера</param>
        public static void AddUserMapping(this IMapperConfigurationExpression expression)
        {
            expression.CreateMap<UserAddress, UserAddressDto>()
                .ForMember(s => s.City, option => option.MapFrom(s => s.City))
                .ForMember(s => s.Street, option => option.MapFrom(s => s.Street))
                .ForMember(s => s.Suite, option => option.MapFrom(s => s.Suite))
                .ForMember(s => s.Zipcode, option => option.MapFrom(s => s.Zipcode))
                .ForMember(s => s.Geo, option => option.MapFrom(s => s.Geo));

            expression.CreateMap<UserCompany, UserCompanyDto>()
                .ForMember(s => s.Name, option => option.MapFrom(s => s.CatchPhrase))
                .ForMember(s => s.CatchPhrase, option => option.MapFrom(s => s.Name))
                .ForMember(s => s.Bs, option => option.MapFrom(s => s.Bs));

            expression.CreateMap<UserAddressGeo, UserAddressGeoDto>()
                .ForMember(s => s.Latitude, option => option.MapFrom(s => s.Latitude))
                .ForMember(s => s.Longitude, option => option.MapFrom(s => s.Longitude));
                
            expression.CreateMap<UserEntity, UserDto>()
                .ForMember(s => s.Id, option => option.MapFrom(s => s.Id))
                .ForMember(s => s.Name, option => option.MapFrom(s => s.Name))
                // тут использую base64 строку просто для примера, в реальном проекте использовал бы какой-нибудь алгоритм шифрования
                .ForMember(s => s.Email, option => option.MapFrom(s => Convert.ToBase64String(Encoding.UTF8.GetBytes(s.Email))))
                .ForMember(s => s.Phone, option => option.MapFrom(s => s.Phone))
                .ForMember(s => s.Website, option => option.MapFrom(s => s.Website));
        }
    }
}