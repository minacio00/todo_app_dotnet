using AutoMapper;
using TodoApp.Data.dtos;

namespace TodoApp.Profiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<CreateTaskDto, Models.Task>();
            CreateMap<UpdateTaskDto, Models.Task>();
            CreateMap<Models.Task, ReadTaskDto>();
        }
    }
}