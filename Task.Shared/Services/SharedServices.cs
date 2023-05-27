using AutoMapper;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Task.Core.Resources;

namespace Task.Shared.Services
{
    public abstract class SharedServices<T>
    {
        protected readonly IMapper _mapper;
        protected readonly IStringLocalizer<Resource> _localizer;
        protected readonly ILogger<T> _logger;

        public SharedServices(IMapper mapper,
                                             IStringLocalizer<Resource> localizer, ILogger<T> logger)
        {
            _mapper = mapper;
            _localizer = localizer;
            _logger = logger;
        }
    }
}