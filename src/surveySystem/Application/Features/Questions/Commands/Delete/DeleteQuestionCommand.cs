using Application.Features.Questions.Constants;
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

namespace Application.Features.Questions.Commands.Delete;

public class DeleteQuestionCommand : IRequest<DeletedQuestionResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, QuestionsOperationClaims.Delete, OperationClaimsOperationClaims.MemberRole];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetQuestions"];

    public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand, DeletedQuestionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQuestionRepository _questionRepository;
        private readonly QuestionBusinessRules _questionBusinessRules;

        public DeleteQuestionCommandHandler(IMapper mapper, IQuestionRepository questionRepository,
                                         QuestionBusinessRules questionBusinessRules)
        {
            _mapper = mapper;
            _questionRepository = questionRepository;
            _questionBusinessRules = questionBusinessRules;
        }

        public async Task<DeletedQuestionResponse> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            Question? question = await _questionRepository.GetAsync(predicate: q => q.Id == request.Id, cancellationToken: cancellationToken);
            await _questionBusinessRules.QuestionShouldExistWhenSelected(question);

            await _questionRepository.DeleteAsync(question!);

            DeletedQuestionResponse response = _mapper.Map<DeletedQuestionResponse>(question);
            return response;
        }
    }
}