using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class CreateCastCommandHandler : IRequestHandler<CreateCastCommand>
    {
        private readonly MovieContext _movieContext;

        public CreateCastCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public async Task Handle(CreateCastCommand request, CancellationToken cancellationToken)
        {
             _movieContext.Casts.Add (new Cast
             {
                 Title = request.Title,
                 Name = request.Name,
                 SurName = request.SurName,
                 ImageUrl = request.ImageUrl,
                 OverView = request.OverView,
                 Biography = request.Biography
             });
        }
    }   
}

