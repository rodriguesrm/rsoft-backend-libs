using MediatR;
using Microsoft.Extensions.Logging;
using RSoft.Lib.Common.Extensions;
using RSoft.Lib.Design.Application.Commands;
using RSoft.Lib.Design.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RSoft.Lib.Design.Application.Handlers
{

    /// <summary>
    /// Create entity command abstract handler
    /// </summary>
    /// <typeparam name="TCreateCommand"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class CreateCommandHandlerBase<TCreateCommand, TResult, TEntity>
        where TCreateCommand : IRequest<CommandResult<TResult>>
        where TEntity : EntityBase<TEntity>
    {

        private readonly ILogger _logger;

        #region Constructors

        /// <summary>
        /// Create a command handler instance
        /// </summary>
        /// <param name="logger">Logger object</param>
        public CreateCommandHandlerBase(ILogger logger)
        {
            _logger = logger;
        }

        #endregion

        #region Abstracts methods

        /// <summary>
        /// Prepare entity to create mapping data
        /// </summary>
        /// <param name="request">Rquest command data</param>
        protected abstract TEntity PrepareEntity(TCreateCommand request);

        /// <summary>
        /// Perform save (create) entity in context
        /// </summary>
        /// <param name="entity">Entity to save</param>
        /// <param name="cancellationToken">Cancellation token</param>
        protected abstract Task<TResult> SaveAsync(TEntity entity, CancellationToken cancellationToken);

        #endregion

        #region Public methods

        /// <summary>
        /// Command handler
        /// </summary>
        /// <param name="request">Request command data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <param name="additionalValidationsAction">Additional validations to be applied to the entity</param>
        protected virtual async Task<CommandResult<TResult>> RunHandler
        (
            TCreateCommand request,
            CancellationToken cancellationToken,
            Action<TCreateCommand, TEntity> additionalValidationsAction = null
        )
        {
            _logger.LogInformation($"{GetType().Name} START");
            CommandResult<TResult> result = Activator.CreateInstance<CommandResult<TResult>>();
            TEntity entity = PrepareEntity(request);
            entity.Validate();
            additionalValidationsAction?.Invoke(request, entity);
            if (entity.Valid)
                result.Response = await SaveAsync(entity, cancellationToken);
            else
                result.Errors = entity.Notifications.ToGenericNotifications();
            _logger.LogInformation($"{GetType().Name} END");
            return result;
        }

        #endregion

    }
}
