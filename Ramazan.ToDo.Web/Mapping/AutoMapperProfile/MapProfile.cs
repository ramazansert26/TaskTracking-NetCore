using AutoMapper;
using Ramazan.ToDo.DTO.DTOs.ActionDTOs;
using Ramazan.ToDo.DTO.DTOs.AppUserDTOs;
using Ramazan.ToDo.DTO.DTOs.NotificationDTOs;
using Ramazan.ToDo.DTO.DTOs.PriorityDTOs;
using Ramazan.ToDo.DTO.DTOs.WorkDTOs;
using Ramazan.ToDo.Entittes.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Action = Ramazan.ToDo.Entittes.Concrete.Action;

namespace Ramazan.ToDo.Web.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region Priority - PriorityDto
            CreateMap<PriorityAddDto, Priority>();
            CreateMap<Priority, PriorityAddDto>();
            CreateMap<PriorityListDto, Priority>();
            CreateMap<Priority, PriorityListDto>();
            CreateMap<PriorityUpdateDto, Priority>();
            CreateMap<Priority, PriorityUpdateDto>();
            #endregion

            #region AppUser - AppUserDto
            CreateMap<AppUserAddDto, AppUser>();
            CreateMap<AppUser, AppUserAddDto>();
            CreateMap<AppUserListDto, AppUser>();
            CreateMap<AppUser, AppUserListDto>();
            CreateMap<AppUserSignInDto, AppUser>();
            CreateMap<AppUser, AppUserSignInDto>();
            #endregion

            #region Notification - NotificationDto
            CreateMap<NotificationListDto, Notification>();
            CreateMap<Notification, NotificationListDto>();
            #endregion

            #region Work - WorkDto
            CreateMap<WorkAddDto, Work>();
            CreateMap<Work, WorkAddDto>();
            CreateMap<WorkListDto, Work>();
            CreateMap<Work, WorkListDto>();
            CreateMap<WorkUpdateDto, Work>();
            CreateMap<Work, WorkUpdateDto>();
            CreateMap<WorkListAllDto, Work>();
            CreateMap<Work, WorkListAllDto>();
            #endregion

            #region Action-ActionDto
            CreateMap<ActionAddDto, Action>();
            CreateMap<Action, ActionAddDto>();
            CreateMap<ActionUpdateDto, Action>();
            CreateMap<Action, ActionUpdateDto>();
            CreateMap<Action, ActionExportDto>();
            CreateMap<ActionExportDto, Action>();
            #endregion
        }
    }
}
