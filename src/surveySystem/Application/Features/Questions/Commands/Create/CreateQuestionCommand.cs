using Application.Features.Questions.Constants;
using Application.Features.Questions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Questions.Constants.QuestionsOperationClaims;
using Application.Features.OperationClaims.Constants;

namespace Application.Features.Questions.Commands.Create;

public class CreateQuestionCommand : IRequest<CreatedQuestionResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string QuestionText { get; set; }
    public Guid SurveyId { get; set; }

    public string[] Roles => [Admin, Write, QuestionsOperationClaims.Create, OperationClaimsOperationClaims.MemberRole];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetQuestions"];

    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, CreatedQuestionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQuestionRepository _questionRepository;
        private readonly QuestionBusinessRules _questionBusinessRules;

        public CreateQuestionCommandHandler(IMapper mapper, IQuestionRepository questionRepository,
                                         QuestionBusinessRules questionBusinessRules)
        {
            _mapper = mapper;
            _questionRepository = questionRepository;
            _questionBusinessRules = questionBusinessRules;
        }

        public async Task<CreatedQuestionResponse> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            Question question = _mapper.Map<Question>(request);

            await _questionRepository.AddAsync(question);

            CreatedQuestionResponse response = _mapper.Map<CreatedQuestionResponse>(question);
            return response;
        }
    }
}