﻿using Core.CrossCuttingConcerns.Exceptions.Types;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.CrossCuttingConcerns.Exceptions.Types.ValidationException;
using ValidationException = Core.CrossCuttingConcerns.Exceptions.Types.ValidationException;

namespace Core.Application.Pipelines.Validation
{
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            ValidationContext<object> context = new(request);
            IEnumerable<ValidationExceptionModel> errors = _validators
                 .Select(validator => validator.Validate(context))
                 .SelectMany(result => result.Errors)
                 .Where(failure => failure != null)
                 .GroupBy(
                     keySelector: p => p.PropertyName,
                     resultSelector: (propertyName, errors) =>
                     new ValidationExceptionModel { Property = propertyName, Errors = errors.Select(e => e.ErrorMessage) }).ToList();
            if (errors.Any())
                throw new ValidationException(errors);
            return next();
        }
    }
}
