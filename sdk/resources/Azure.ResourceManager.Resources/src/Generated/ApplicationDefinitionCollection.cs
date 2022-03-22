// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Resources
{
    /// <summary> A class representing collection of ApplicationDefinition and their operations over its parent. </summary>
    public partial class ApplicationDefinitionCollection : ArmCollection, IEnumerable<ApplicationDefinitionResource>, IAsyncEnumerable<ApplicationDefinitionResource>
    {
        private readonly ClientDiagnostics _applicationDefinitionClientDiagnostics;
        private readonly ApplicationDefinitionsRestOperations _applicationDefinitionRestClient;

        /// <summary> Initializes a new instance of the <see cref="ApplicationDefinitionCollection"/> class for mocking. </summary>
        protected ApplicationDefinitionCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ApplicationDefinitionCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ApplicationDefinitionCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _applicationDefinitionClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", ApplicationDefinitionResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ApplicationDefinitionResource.ResourceType, out string applicationDefinitionApiVersion);
            _applicationDefinitionRestClient = new ApplicationDefinitionsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, applicationDefinitionApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroupResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroupResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates a new managed application definition.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applicationDefinitions/{applicationDefinitionName}
        /// Operation Id: ApplicationDefinitions_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="applicationDefinitionName"> The name of the managed application definition. </param>
        /// <param name="parameters"> Parameters supplied to the create or update an managed application definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationDefinitionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationDefinitionName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ArmOperation<ApplicationDefinitionResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string applicationDefinitionName, ApplicationDefinitionData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationDefinitionName, nameof(applicationDefinitionName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _applicationDefinitionClientDiagnostics.CreateScope("ApplicationDefinitionCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _applicationDefinitionRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, applicationDefinitionName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new ResourcesArmOperation<ApplicationDefinitionResource>(new ApplicationDefinitionOperationSource(Client), _applicationDefinitionClientDiagnostics, Pipeline, _applicationDefinitionRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, applicationDefinitionName, parameters).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates a new managed application definition.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applicationDefinitions/{applicationDefinitionName}
        /// Operation Id: ApplicationDefinitions_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="applicationDefinitionName"> The name of the managed application definition. </param>
        /// <param name="parameters"> Parameters supplied to the create or update an managed application definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationDefinitionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationDefinitionName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<ApplicationDefinitionResource> CreateOrUpdate(WaitUntil waitUntil, string applicationDefinitionName, ApplicationDefinitionData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationDefinitionName, nameof(applicationDefinitionName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _applicationDefinitionClientDiagnostics.CreateScope("ApplicationDefinitionCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _applicationDefinitionRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, applicationDefinitionName, parameters, cancellationToken);
                var operation = new ResourcesArmOperation<ApplicationDefinitionResource>(new ApplicationDefinitionOperationSource(Client), _applicationDefinitionClientDiagnostics, Pipeline, _applicationDefinitionRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, applicationDefinitionName, parameters).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the managed application definition.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applicationDefinitions/{applicationDefinitionName}
        /// Operation Id: ApplicationDefinitions_Get
        /// </summary>
        /// <param name="applicationDefinitionName"> The name of the managed application definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationDefinitionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationDefinitionName"/> is null. </exception>
        public virtual async Task<Response<ApplicationDefinitionResource>> GetAsync(string applicationDefinitionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationDefinitionName, nameof(applicationDefinitionName));

            using var scope = _applicationDefinitionClientDiagnostics.CreateScope("ApplicationDefinitionCollection.Get");
            scope.Start();
            try
            {
                var response = await _applicationDefinitionRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, applicationDefinitionName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ApplicationDefinitionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the managed application definition.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applicationDefinitions/{applicationDefinitionName}
        /// Operation Id: ApplicationDefinitions_Get
        /// </summary>
        /// <param name="applicationDefinitionName"> The name of the managed application definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationDefinitionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationDefinitionName"/> is null. </exception>
        public virtual Response<ApplicationDefinitionResource> Get(string applicationDefinitionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationDefinitionName, nameof(applicationDefinitionName));

            using var scope = _applicationDefinitionClientDiagnostics.CreateScope("ApplicationDefinitionCollection.Get");
            scope.Start();
            try
            {
                var response = _applicationDefinitionRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, applicationDefinitionName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ApplicationDefinitionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists the managed application definitions in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applicationDefinitions
        /// Operation Id: ApplicationDefinitions_ListByResourceGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApplicationDefinitionResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApplicationDefinitionResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ApplicationDefinitionResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _applicationDefinitionClientDiagnostics.CreateScope("ApplicationDefinitionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _applicationDefinitionRestClient.ListByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApplicationDefinitionResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ApplicationDefinitionResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _applicationDefinitionClientDiagnostics.CreateScope("ApplicationDefinitionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _applicationDefinitionRestClient.ListByResourceGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApplicationDefinitionResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Lists the managed application definitions in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applicationDefinitions
        /// Operation Id: ApplicationDefinitions_ListByResourceGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApplicationDefinitionResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApplicationDefinitionResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ApplicationDefinitionResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _applicationDefinitionClientDiagnostics.CreateScope("ApplicationDefinitionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _applicationDefinitionRestClient.ListByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApplicationDefinitionResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ApplicationDefinitionResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _applicationDefinitionClientDiagnostics.CreateScope("ApplicationDefinitionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _applicationDefinitionRestClient.ListByResourceGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApplicationDefinitionResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applicationDefinitions/{applicationDefinitionName}
        /// Operation Id: ApplicationDefinitions_Get
        /// </summary>
        /// <param name="applicationDefinitionName"> The name of the managed application definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationDefinitionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationDefinitionName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string applicationDefinitionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationDefinitionName, nameof(applicationDefinitionName));

            using var scope = _applicationDefinitionClientDiagnostics.CreateScope("ApplicationDefinitionCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(applicationDefinitionName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applicationDefinitions/{applicationDefinitionName}
        /// Operation Id: ApplicationDefinitions_Get
        /// </summary>
        /// <param name="applicationDefinitionName"> The name of the managed application definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationDefinitionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationDefinitionName"/> is null. </exception>
        public virtual Response<bool> Exists(string applicationDefinitionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationDefinitionName, nameof(applicationDefinitionName));

            using var scope = _applicationDefinitionClientDiagnostics.CreateScope("ApplicationDefinitionCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(applicationDefinitionName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applicationDefinitions/{applicationDefinitionName}
        /// Operation Id: ApplicationDefinitions_Get
        /// </summary>
        /// <param name="applicationDefinitionName"> The name of the managed application definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationDefinitionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationDefinitionName"/> is null. </exception>
        public virtual async Task<Response<ApplicationDefinitionResource>> GetIfExistsAsync(string applicationDefinitionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationDefinitionName, nameof(applicationDefinitionName));

            using var scope = _applicationDefinitionClientDiagnostics.CreateScope("ApplicationDefinitionCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _applicationDefinitionRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, applicationDefinitionName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ApplicationDefinitionResource>(null, response.GetRawResponse());
                return Response.FromValue(new ApplicationDefinitionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applicationDefinitions/{applicationDefinitionName}
        /// Operation Id: ApplicationDefinitions_Get
        /// </summary>
        /// <param name="applicationDefinitionName"> The name of the managed application definition. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationDefinitionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationDefinitionName"/> is null. </exception>
        public virtual Response<ApplicationDefinitionResource> GetIfExists(string applicationDefinitionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationDefinitionName, nameof(applicationDefinitionName));

            using var scope = _applicationDefinitionClientDiagnostics.CreateScope("ApplicationDefinitionCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _applicationDefinitionRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, applicationDefinitionName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ApplicationDefinitionResource>(null, response.GetRawResponse());
                return Response.FromValue(new ApplicationDefinitionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ApplicationDefinitionResource> IEnumerable<ApplicationDefinitionResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ApplicationDefinitionResource> IAsyncEnumerable<ApplicationDefinitionResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
