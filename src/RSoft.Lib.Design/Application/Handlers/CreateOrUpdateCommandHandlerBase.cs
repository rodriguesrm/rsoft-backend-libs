using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using RSoft.Lib.Common.Abstractions;
using RSoft.Lib.Common.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using RSoft.Lib.Design.Domain.Entities;
using System;
using RSoft.Lib.Design.Application.Commands;
using RSoft.Lib.Common.Extensions;

namespace RSoft.Lib.Design.Application.Handlers
{

    /// <summary>
    /// Create or update entity command abstract handler
    /// </summary>
    /// <typeparam name="TCreateOrUpdateCommand">Create or update command type</typeparam>
    /// <typeparam name="TResult">Result type</typeparam>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public abstract class CreateOrUpdateCommandHandlerBase<TCreateOrUpdateCommand, TResult, TEntity>
        where TCreateOrUpdateCommand : IRequest<CommandResult<TResult>>
        where TEntity : EntityBase<TEntity>
    {

        #region Local objects/variables

        private readonly ILogger _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new handler instance
        /// </summary>
        /// <param name="logger">Logger object</param>
        public CreateOrUpdateCommandHandlerBase(ILogger logger)
        {
            _logger = logger;
        }

        #endregion

        #region Abstracts methods

        /// <summary>
        /// Get entity by key
        /// </summary>
        /// <param name="request">Request command data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        protected abstract Task<TEntity> GetEntityByKeyAsync(TCreateOrUpdateCommand request, CancellationToken cancellationToken);

        /// <summary>
        /// Prepare entity to create mapping data
        /// </summary>
        /// <param name="request">Rquest command data</param>
        /// <param name="entity">Entity instance</param>
        /// <param name="isUpdate">Operation status flag (true=Update/false=Create)</param>
        protected abstract TEntity PrepareEntity(TCreateOrUpdateCommand request, TEntity entity, bool isUpdate);

        /// <summary>
        /// Perform save (update) entity in context
        /// </summary>
        /// <param name="entity">Entity to save</param>
        /// <param name="isUpdate">Operation status flag (true=Update/false=Create)</param>
        /// <param name="cancellationToken">Cancellation token</param>
        protected abstract Task<TResult> SaveAsync(TEntity entity, bool isUpdate, CancellationToken cancellationToken);

        #endregion

        #region Handlers

        /// <summary>
        /// Command handler
        /// </summary>
        /// <param name="request">Request command data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <param name="additionalValidationsAction">Additional validations to be applied to the entity</param>
        protected virtual async Task<CommandResult<TResult>> RunHandler
        (
            TCreateOrUpdateCommand request,
            CancellationToken cancellationToken,
            Action<TCreateOrUpdateCommand, TEntity> additionalValidationsAction = null
        )
        {
            _logger.LogInformation($"{GetType().Name} START");
            CommandResult<TResult> result = Activator.CreateInstance<CommandResult<TResult>>();
            TEntity entity = await GetEntityByKeyAsync(request, cancellationToken);
            bool isUpdate = entity != null;
            if (entity == null)
                entity = Activator.CreateInstance<TEntity>();
            entity = PrepareEntity(request, entity, isUpdate);
            entity.Validate();
            additionalValidationsAction?.Invoke(request, entity);
            if (entity.Valid)
                result.Response = await SaveAsync(entity, isUpdate, cancellationToken);
            else
                result.Errors = entity.Notifications.ToGenericNotifications();
            _logger.LogInformation($"{GetType().Name} END");
            return result;
        }

        #endregion

    }
}
