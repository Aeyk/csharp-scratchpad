// using Microsoft.Identity.Client;
// using Keycloak.AuthServices.Sdk.Admin.Models;

// namespace Keycloak.AuthServices.Sdk.Admin;


// /// <summary>
// /// Keycloak Admin API Client
// /// </summary>
// /// <remarks>
// /// Aggregates multiple clients
// /// </remarks>
// public static class KeycloakClientExtensions
// {
//     /// <summary>
//     /// Get realm
//     /// </summary>
//     /// <param name="realm"></param>
//     /// <param name="cancellationToken"></param>
//     /// <returns></returns>
//     async static Task<RealmRepresentation> GetRolesAsync(
//         this KeycloakClient keycloakClient,
//         string realm,
//         string clientUuid,
//         CancellationToken cancellationToken = default
//     )
//     {
//         var response = await keycloakClient.GetRolesAsyncWithResponseAsync(realm, clientUuid, cancellationToken);

//         return (await response.GetResponseAsync<RealmRepresentation>(cancellationToken))!;
//     }

//     /// <summary>
//     /// Get realm
//     /// </summary>
//     /// <param name="realm"></param>
//     /// <param name="cancellationToken"></param>
//     /// <returns></returns>
//     public static Task<HttpResponseMessage> GetRolesAsyncWithResponseAsync(
//         this KeycloakClient keycloakClient,
//         string realm,
//         string clientUuid, 
//         CancellationToken cancellationToken = default
//     ) 
//     {
//         var path = $"/admin/realms/{realm}/clients/{clientUuid}/roles";

//         var responseMessage = await keycloakClient.httpClient.GetAsync(
//             path,
//             cancellationToken: cancellationToken
//         );

//         return responseMessage!;
//     }
// }



// /// <summary>
// /// Keycloak Admin API Client
// /// </summary>
// /// <remarks>
// /// Aggregates multiple clients
// /// </remarks>
// public static class IKeycloakClientExtensions
// {
//     /// <summary>
//     /// Get realm
//     /// </summary>
//     /// <param name="realm"></param>
//     /// <param name="cancellationToken"></param>
//     /// <returns></returns>
//     async static Task<RealmRepresentation> GetRolesAsync(
//         this IKeycloakClient ikeycloakClient,
//         string realm,
//         string clientUuid,
//         CancellationToken cancellationToken = default
//     )
//     {
//         var response = await ikeycloakClient.GetRolesAsyncWithResponseAsync(realm, clientUuid, cancellationToken);

//         return (await response.GetResponseAsync<RealmRepresentation>(cancellationToken))!;
//     }

//     /// <summary>
//     /// Get realm
//     /// </summary>
//     /// <param name="realm"></param>
//     /// <param name="cancellationToken"></param>
//     /// <returns></returns>
//     public static Task<HttpResponseMessage> GetRolesAsyncWithResponseAsync(
//         this IKeycloakClient ikeycloakClient,
//         string realm,
//         string clientUuid, 
//         CancellationToken cancellationToken = default
//     ) {
//         throw new NotImplementedException();
//     }
// }
