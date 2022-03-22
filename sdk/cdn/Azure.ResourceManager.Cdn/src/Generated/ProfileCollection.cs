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
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Cdn
{
    /// <summary> A class representing collection of Profile and their operations over its parent. </summary>
    public partial class ProfileCollection : ArmCollection, IEnumerable<ProfileResource>, IAsyncEnumerable<ProfileResource>
    {
        private readonly ClientDiagnostics _profileClientDiagnostics;
        private readonly ProfilesRestOperations _profileRestClient;

        /// <summary> Initializes a new instance of the <see cref="ProfileCollection"/> class for mocking. </summary>
        protected ProfileCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ProfileCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ProfileCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _profileClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Cdn", ProfileResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ProfileResource.ResourceType, out string profileApiVersion);
            _profileRestClient = new ProfilesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, profileApiVersion);
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
        /// Creates a new CDN profile with a profile name under the specified subscription and resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}
        /// Operation Id: Profiles_Create
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="profileName"> Name of the CDN profile which is unique within the resource group. </param>
        /// <param name="profile"> Profile properties needed to create a new profile. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="profileName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="profileName"/> or <paramref name="profile"/> is null. </exception>
        public virtual async Task<ArmOperation<ProfileResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string profileName, ProfileData profile, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(profileName, nameof(profileName));
            Argument.AssertNotNull(profile, nameof(profile));

            using var scope = _profileClientDiagnostics.CreateScope("ProfileCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _profileRestClient.CreateAsync(Id.SubscriptionId, Id.ResourceGroupName, profileName, profile, cancellationToken).ConfigureAwait(false);
                var operation = new CdnArmOperation<ProfileResource>(new ProfileOperationSource(Client), _profileClientDiagnostics, Pipeline, _profileRestClient.CreateCreateRequest(Id.SubscriptionId, Id.ResourceGroupName, profileName, profile).Request, response, OperationFinalStateVia.Location);
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
        /// Creates a new CDN profile with a profile name under the specified subscription and resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}
        /// Operation Id: Profiles_Create
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="profileName"> Name of the CDN profile which is unique within the resource group. </param>
        /// <param name="profile"> Profile properties needed to create a new profile. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="profileName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="profileName"/> or <paramref name="profile"/> is null. </exception>
        public virtual ArmOperation<ProfileResource> CreateOrUpdate(WaitUntil waitUntil, string profileName, ProfileData profile, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(profileName, nameof(profileName));
            Argument.AssertNotNull(profile, nameof(profile));

            using var scope = _profileClientDiagnostics.CreateScope("ProfileCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _profileRestClient.Create(Id.SubscriptionId, Id.ResourceGroupName, profileName, profile, cancellationToken);
                var operation = new CdnArmOperation<ProfileResource>(new ProfileOperationSource(Client), _profileClientDiagnostics, Pipeline, _profileRestClient.CreateCreateRequest(Id.SubscriptionId, Id.ResourceGroupName, profileName, profile).Request, response, OperationFinalStateVia.Location);
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
        /// Gets a CDN profile with the specified profile name under the specified subscription and resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}
        /// Operation Id: Profiles_Get
        /// </summary>
        /// <param name="profileName"> Name of the CDN profile which is unique within the resource group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="profileName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="profileName"/> is null. </exception>
        public virtual async Task<Response<ProfileResource>> GetAsync(string profileName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(profileName, nameof(profileName));

            using var scope = _profileClientDiagnostics.CreateScope("ProfileCollection.Get");
            scope.Start();
            try
            {
                var response = await _profileRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, profileName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ProfileResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a CDN profile with the specified profile name under the specified subscription and resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}
        /// Operation Id: Profiles_Get
        /// </summary>
        /// <param name="profileName"> Name of the CDN profile which is unique within the resource group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="profileName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="profileName"/> is null. </exception>
        public virtual Response<ProfileResource> Get(string profileName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(profileName, nameof(profileName));

            using var scope = _profileClientDiagnostics.CreateScope("ProfileCollection.Get");
            scope.Start();
            try
            {
                var response = _profileRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, profileName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ProfileResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all of the CDN profiles within a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles
        /// Operation Id: Profiles_ListByResourceGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ProfileResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ProfileResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ProfileResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _profileClientDiagnostics.CreateScope("ProfileCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _profileRestClient.ListByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ProfileResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ProfileResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _profileClientDiagnostics.CreateScope("ProfileCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _profileRestClient.ListByResourceGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ProfileResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all of the CDN profiles within a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles
        /// Operation Id: Profiles_ListByResourceGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ProfileResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ProfileResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ProfileResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _profileClientDiagnostics.CreateScope("ProfileCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _profileRestClient.ListByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ProfileResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ProfileResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _profileClientDiagnostics.CreateScope("ProfileCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _profileRestClient.ListByResourceGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ProfileResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}
        /// Operation Id: Profiles_Get
        /// </summary>
        /// <param name="profileName"> Name of the CDN profile which is unique within the resource group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="profileName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="profileName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string profileName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(profileName, nameof(profileName));

            using var scope = _profileClientDiagnostics.CreateScope("ProfileCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(profileName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}
        /// Operation Id: Profiles_Get
        /// </summary>
        /// <param name="profileName"> Name of the CDN profile which is unique within the resource group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="profileName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="profileName"/> is null. </exception>
        public virtual Response<bool> Exists(string profileName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(profileName, nameof(profileName));

            using var scope = _profileClientDiagnostics.CreateScope("ProfileCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(profileName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}
        /// Operation Id: Profiles_Get
        /// </summary>
        /// <param name="profileName"> Name of the CDN profile which is unique within the resource group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="profileName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="profileName"/> is null. </exception>
        public virtual async Task<Response<ProfileResource>> GetIfExistsAsync(string profileName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(profileName, nameof(profileName));

            using var scope = _profileClientDiagnostics.CreateScope("ProfileCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _profileRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, profileName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ProfileResource>(null, response.GetRawResponse());
                return Response.FromValue(new ProfileResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}
        /// Operation Id: Profiles_Get
        /// </summary>
        /// <param name="profileName"> Name of the CDN profile which is unique within the resource group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="profileName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="profileName"/> is null. </exception>
        public virtual Response<ProfileResource> GetIfExists(string profileName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(profileName, nameof(profileName));

            using var scope = _profileClientDiagnostics.CreateScope("ProfileCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _profileRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, profileName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ProfileResource>(null, response.GetRawResponse());
                return Response.FromValue(new ProfileResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ProfileResource> IEnumerable<ProfileResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ProfileResource> IAsyncEnumerable<ProfileResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
