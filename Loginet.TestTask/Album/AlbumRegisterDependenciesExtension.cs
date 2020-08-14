using AutoMapper;
using Loginet.TestTask.Album.Dto;
using Loginet.TestTask.Core.Entities.Album;
using Loginet.TestTask.Core.Entities.Album.Manager;
using Loginet.TestTask.Core.Entities.Album.Repository;
using Loginet.TestTask.Core.Entities.Album.Repository.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace Loginet.TestTask.Album
{
    /// <summary>
    /// Класс-расширение для инкапсуляции регистрации различных зависимостей для альбомов
    /// </summary>
    public static class AlbumRegisterDependenciesExtension
    {
        /// <summary>
        /// Добавление зависимостей для альбомов
        /// </summary>
        /// <param name="services">Коллекция зависимостей</param>
        public static void AddAlbumDependencies(this IServiceCollection services)
        {
            services.AddSingleton<AlbumsManager>();
            services.AddSingleton<IAlbumRepository, HttpAlbumRepository>();
        }

        /// <summary>
        /// Добавление маппинга для моделей связанных с альбомами
        /// </summary>
        /// <param name="expression">Конфигуратор маппера</param>
        public static void AddAlbumMapping(this IMapperConfigurationExpression expression)
        {
            expression.CreateMap<AlbumEntity, AlbumDto>()
                .ForMember(s => s.Id, option => option.MapFrom(s => s.Id))
                .ForMember(s => s.Title, option => option.MapFrom(s => s.Title))
                .ForMember(s => s.UserId, option => option.MapFrom(s => s.UserId));
        }
    }
}