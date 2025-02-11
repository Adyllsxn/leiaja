#region <AutoMapper>
    global using AutoMapper;
#endregion </AutoMapper>

#region <System>
    global using System.ComponentModel.DataAnnotations;
    global using System.ComponentModel.DataAnnotations.Schema;
    global using System.Text.Json.Serialization;
#endregion

#region <Domain>
    global using LeiaJa.Domain.Interfaces;
    global using LeiaJa.Domain.Entities;
    global using LeiaJa.Domain.Common;
    global using LeiaJa.Domain.Enums;
#endregion </Domain>

#region <Application>
    global using LeiaJa.Application.DTOs.CategoryDTO;
    global using LeiaJa.Application.DTOs.DashboardDTO;
    global using LeiaJa.Application.DTOs.AthorDTO;
    global using LeiaJa.Application.DTOs.BookDTO;
    global using LeiaJa.Application.DTOs.UserDTO;
    global using LeiaJa.Application.Interfaces;
    global using LeiaJa.Application.UseCase.CategoryUseCase;
    global using LeiaJa.Application.UseCase.DashboardUseCase;
    global using LeiaJa.Application.UseCase.AthorUseCase;
    global using LeiaJa.Application.UseCase.BookUseCase;
    global using LeiaJa.Application.UseCase.UserUseCase;
#endregion </Application>