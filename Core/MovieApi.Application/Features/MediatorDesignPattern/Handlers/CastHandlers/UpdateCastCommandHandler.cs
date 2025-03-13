using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class UpdateCastCommandHandler :IRequestHandler<UpdateCastCommand>
    {
        private readonly MovieContext _movieContext;

        public UpdateCastCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task Handle(UpdateCastCommand request, CancellationToken cancellationToken)
        {
            var values = await _movieContext.Casts.FindAsync(request.CastId);
            values.Title = request.Title;
            values.Name = request.Name;
            values.SurName = request.SurName;
            values.ImageUrl = request.ImageUrl;
            values.OverView = request.OverView;
            values.Biography = request.Biography;
            await _movieContext.SaveChangesAsync();
        }
    }
}
