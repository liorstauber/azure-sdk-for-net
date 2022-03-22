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

namespace Azure.ResourceManager.AppService
{
    /// <summary> A class representing collection of SiteDomainOwnershipIdentifier and their operations over its parent. </summary>
    public partial class SiteDomainOwnershipIdentifierCollection : ArmCollection, IEnumerable<SiteDomainOwnershipIdentifierResource>, IAsyncEnumerable<SiteDomainOwnershipIdentifierResource>
    {
        private readonly ClientDiagnostics _siteDomainOwnershipIdentifierWebAppsClientDiagnostics;
        private readonly WebAppsRestOperations _siteDomainOwnershipIdentifierWebAppsRestClient;

        /// <summary> Initializes a new instance of the <see cref="SiteDomainOwnershipIdentifierCollection"/> class for mocking. </summary>
        protected SiteDomainOwnershipIdentifierCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SiteDomainOwnershipIdentifierCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SiteDomainOwnershipIdentifierCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _siteDomainOwnershipIdentifierWebAppsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.AppService", SiteDomainOwnershipIdentifierResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(SiteDomainOwnershipIdentifierResource.ResourceType, out string siteDomainOwnershipIdentifierWebAppsApiVersion);
            _siteDomainOwnershipIdentifierWebAppsRestClient = new WebAppsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, siteDomainOwnershipIdentifierWebAppsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != WebSiteResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, WebSiteResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Description for Creates a domain ownership identifier for web app, or updates an existing ownership identifier.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/domainOwnershipIdentifiers/{domainOwnershipIdentifierName}
        /// Operation Id: WebApps_CreateOrUpdateDomainOwnershipIdentifier
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="domainOwnershipIdentifierName"> Name of domain ownership identifier. </param>
        /// <param name="domainOwnershipIdentifier"> A JSON representation of the domain ownership properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="domainOwnershipIdentifierName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="domainOwnershipIdentifierName"/> or <paramref name="domainOwnershipIdentifier"/> is null. </exception>
        public virtual async Task<ArmOperation<SiteDomainOwnershipIdentifierResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string domainOwnershipIdentifierName, IdentifierData domainOwnershipIdentifier, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(domainOwnershipIdentifierName, nameof(domainOwnershipIdentifierName));
            Argument.AssertNotNull(domainOwnershipIdentifier, nameof(domainOwnershipIdentifier));

            using var scope = _siteDomainOwnershipIdentifierWebAppsClientDiagnostics.CreateScope("SiteDomainOwnershipIdentifierCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _siteDomainOwnershipIdentifierWebAppsRestClient.CreateOrUpdateDomainOwnershipIdentifierAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, domainOwnershipIdentifierName, domainOwnershipIdentifier, cancellationToken).ConfigureAwait(false);
                var operation = new AppServiceArmOperation<SiteDomainOwnershipIdentifierResource>(Response.FromValue(new SiteDomainOwnershipIdentifierResource(Client, response), response.GetRawResponse()));
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
        /// Description for Creates a domain ownership identifier for web app, or updates an existing ownership identifier.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/domainOwnershipIdentifiers/{domainOwnershipIdentifierName}
        /// Operation Id: WebApps_CreateOrUpdateDomainOwnershipIdentifier
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="domainOwnershipIdentifierName"> Name of domain ownership identifier. </param>
        /// <param name="domainOwnershipIdentifier"> A JSON representation of the domain ownership properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="domainOwnershipIdentifierName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="domainOwnershipIdentifierName"/> or <paramref name="domainOwnershipIdentifier"/> is null. </exception>
        public virtual ArmOperation<SiteDomainOwnershipIdentifierResource> CreateOrUpdate(WaitUntil waitUntil, string domainOwnershipIdentifierName, IdentifierData domainOwnershipIdentifier, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(domainOwnershipIdentifierName, nameof(domainOwnershipIdentifierName));
            Argument.AssertNotNull(domainOwnershipIdentifier, nameof(domainOwnershipIdentifier));

            using var scope = _siteDomainOwnershipIdentifierWebAppsClientDiagnostics.CreateScope("SiteDomainOwnershipIdentifierCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _siteDomainOwnershipIdentifierWebAppsRestClient.CreateOrUpdateDomainOwnershipIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, domainOwnershipIdentifierName, domainOwnershipIdentifier, cancellationToken);
                var operation = new AppServiceArmOperation<SiteDomainOwnershipIdentifierResource>(Response.FromValue(new SiteDomainOwnershipIdentifierResource(Client, response), response.GetRawResponse()));
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
        /// Description for Get domain ownership identifier for web app.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/domainOwnershipIdentifiers/{domainOwnershipIdentifierName}
        /// Operation Id: WebApps_GetDomainOwnershipIdentifier
        /// </summary>
        /// <param name="domainOwnershipIdentifierName"> Name of domain ownership identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="domainOwnershipIdentifierName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="domainOwnershipIdentifierName"/> is null. </exception>
        public virtual async Task<Response<SiteDomainOwnershipIdentifierResource>> GetAsync(string domainOwnershipIdentifierName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(domainOwnershipIdentifierName, nameof(domainOwnershipIdentifierName));

            using var scope = _siteDomainOwnershipIdentifierWebAppsClientDiagnostics.CreateScope("SiteDomainOwnershipIdentifierCollection.Get");
            scope.Start();
            try
            {
                var response = await _siteDomainOwnershipIdentifierWebAppsRestClient.GetDomainOwnershipIdentifierAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, domainOwnershipIdentifierName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SiteDomainOwnershipIdentifierResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Get domain ownership identifier for web app.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/domainOwnershipIdentifiers/{domainOwnershipIdentifierName}
        /// Operation Id: WebApps_GetDomainOwnershipIdentifier
        /// </summary>
        /// <param name="domainOwnershipIdentifierName"> Name of domain ownership identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="domainOwnershipIdentifierName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="domainOwnershipIdentifierName"/> is null. </exception>
        public virtual Response<SiteDomainOwnershipIdentifierResource> Get(string domainOwnershipIdentifierName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(domainOwnershipIdentifierName, nameof(domainOwnershipIdentifierName));

            using var scope = _siteDomainOwnershipIdentifierWebAppsClientDiagnostics.CreateScope("SiteDomainOwnershipIdentifierCollection.Get");
            scope.Start();
            try
            {
                var response = _siteDomainOwnershipIdentifierWebAppsRestClient.GetDomainOwnershipIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, domainOwnershipIdentifierName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SiteDomainOwnershipIdentifierResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Lists ownership identifiers for domain associated with web app.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/domainOwnershipIdentifiers
        /// Operation Id: WebApps_ListDomainOwnershipIdentifiers
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SiteDomainOwnershipIdentifierResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SiteDomainOwnershipIdentifierResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SiteDomainOwnershipIdentifierResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _siteDomainOwnershipIdentifierWebAppsClientDiagnostics.CreateScope("SiteDomainOwnershipIdentifierCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _siteDomainOwnershipIdentifierWebAppsRestClient.ListDomainOwnershipIdentifiersAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteDomainOwnershipIdentifierResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SiteDomainOwnershipIdentifierResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _siteDomainOwnershipIdentifierWebAppsClientDiagnostics.CreateScope("SiteDomainOwnershipIdentifierCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _siteDomainOwnershipIdentifierWebAppsRestClient.ListDomainOwnershipIdentifiersNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteDomainOwnershipIdentifierResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Description for Lists ownership identifiers for domain associated with web app.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/domainOwnershipIdentifiers
        /// Operation Id: WebApps_ListDomainOwnershipIdentifiers
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SiteDomainOwnershipIdentifierResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SiteDomainOwnershipIdentifierResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<SiteDomainOwnershipIdentifierResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _siteDomainOwnershipIdentifierWebAppsClientDiagnostics.CreateScope("SiteDomainOwnershipIdentifierCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _siteDomainOwnershipIdentifierWebAppsRestClient.ListDomainOwnershipIdentifiers(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteDomainOwnershipIdentifierResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SiteDomainOwnershipIdentifierResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _siteDomainOwnershipIdentifierWebAppsClientDiagnostics.CreateScope("SiteDomainOwnershipIdentifierCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _siteDomainOwnershipIdentifierWebAppsRestClient.ListDomainOwnershipIdentifiersNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteDomainOwnershipIdentifierResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/domainOwnershipIdentifiers/{domainOwnershipIdentifierName}
        /// Operation Id: WebApps_GetDomainOwnershipIdentifier
        /// </summary>
        /// <param name="domainOwnershipIdentifierName"> Name of domain ownership identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="domainOwnershipIdentifierName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="domainOwnershipIdentifierName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string domainOwnershipIdentifierName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(domainOwnershipIdentifierName, nameof(domainOwnershipIdentifierName));

            using var scope = _siteDomainOwnershipIdentifierWebAppsClientDiagnostics.CreateScope("SiteDomainOwnershipIdentifierCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(domainOwnershipIdentifierName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/domainOwnershipIdentifiers/{domainOwnershipIdentifierName}
        /// Operation Id: WebApps_GetDomainOwnershipIdentifier
        /// </summary>
        /// <param name="domainOwnershipIdentifierName"> Name of domain ownership identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="domainOwnershipIdentifierName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="domainOwnershipIdentifierName"/> is null. </exception>
        public virtual Response<bool> Exists(string domainOwnershipIdentifierName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(domainOwnershipIdentifierName, nameof(domainOwnershipIdentifierName));

            using var scope = _siteDomainOwnershipIdentifierWebAppsClientDiagnostics.CreateScope("SiteDomainOwnershipIdentifierCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(domainOwnershipIdentifierName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/domainOwnershipIdentifiers/{domainOwnershipIdentifierName}
        /// Operation Id: WebApps_GetDomainOwnershipIdentifier
        /// </summary>
        /// <param name="domainOwnershipIdentifierName"> Name of domain ownership identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="domainOwnershipIdentifierName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="domainOwnershipIdentifierName"/> is null. </exception>
        public virtual async Task<Response<SiteDomainOwnershipIdentifierResource>> GetIfExistsAsync(string domainOwnershipIdentifierName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(domainOwnershipIdentifierName, nameof(domainOwnershipIdentifierName));

            using var scope = _siteDomainOwnershipIdentifierWebAppsClientDiagnostics.CreateScope("SiteDomainOwnershipIdentifierCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _siteDomainOwnershipIdentifierWebAppsRestClient.GetDomainOwnershipIdentifierAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, domainOwnershipIdentifierName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<SiteDomainOwnershipIdentifierResource>(null, response.GetRawResponse());
                return Response.FromValue(new SiteDomainOwnershipIdentifierResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/domainOwnershipIdentifiers/{domainOwnershipIdentifierName}
        /// Operation Id: WebApps_GetDomainOwnershipIdentifier
        /// </summary>
        /// <param name="domainOwnershipIdentifierName"> Name of domain ownership identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="domainOwnershipIdentifierName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="domainOwnershipIdentifierName"/> is null. </exception>
        public virtual Response<SiteDomainOwnershipIdentifierResource> GetIfExists(string domainOwnershipIdentifierName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(domainOwnershipIdentifierName, nameof(domainOwnershipIdentifierName));

            using var scope = _siteDomainOwnershipIdentifierWebAppsClientDiagnostics.CreateScope("SiteDomainOwnershipIdentifierCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _siteDomainOwnershipIdentifierWebAppsRestClient.GetDomainOwnershipIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, domainOwnershipIdentifierName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<SiteDomainOwnershipIdentifierResource>(null, response.GetRawResponse());
                return Response.FromValue(new SiteDomainOwnershipIdentifierResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SiteDomainOwnershipIdentifierResource> IEnumerable<SiteDomainOwnershipIdentifierResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SiteDomainOwnershipIdentifierResource> IAsyncEnumerable<SiteDomainOwnershipIdentifierResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
