using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Comments
{
    public class List
    {
        public class Query : IRequest<Result<List<CommentDto>>>
        {
            public Guid ActivityId { get; set; }
        }

        public class Handle : IRequestHandler<Query, Result<List<CommentDto>>> {

            private readonly DataContext _context;

            public Handler(DataContext context, IMapper mapper) {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<CommentDto>>> Handle(Query request, CancellationToken cancellationToken) 
            {
                var comments = awit _context.Comments
                    .Wher(x => x.Activity.Id == request.ActivityId)
                    .OrderBy(x => x.CreatedAt)
                    .ProjectTo<CommentDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
                return Result<List<CommentDto>>.Success(comment);
            }
        }
     }
}