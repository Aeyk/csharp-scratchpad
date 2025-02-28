using System.Security.Claims;
using Keycloak.AuthServices.Authorization;
using Keycloak.AuthServices.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Shared;

public class GroupMembershipRequirement : AuthorizationHandler<GroupMembershipRequirement>, IAuthorizationRequirement
{
    public object? Resource { get; internal set; }
    public IEnumerable<string> Groups { get; internal set; }
    public GroupMembershipRequirement(IEnumerable<string> groups)
    {
        ArgumentNullException.ThrowIfNull(groups);

        if (!groups.Any())
        {
            throw new InvalidOperationException(/*Resources.Exception_RoleRequirementEmpty*/);
        }
        Groups = groups;
    }
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, GroupMembershipRequirement requirement)
    {
        if (context.User != null)
        {
            if (context.User.Claims.Where(c => c.Type == "groups").Select(c => c.Value).Intersect(requirement.Groups).Any())
            {
                context.Succeed(requirement);
            }
        }
        return Task.CompletedTask;
    }

}

// public partial class GroupMembershipRequirementHandler : AuthorizationHandler<GroupMembershipRequirement>, IAuthorizationRequirement(
//         IOptions<KeycloakAuthorizationOptions> keycloakOptions,
//         KeycloakMetrics metrics,
//         ILogger<GroupMembershipRequirementHandler> logger
//     )
//     : AuthorizationHandler<GroupMembershipRequirement>
// {
//     protected override Task HandleRequirementAsync(
//         AuthorizationHandlerContext context,
//         GroupMembershipRequirement requirement
//     )
//     {
//         ArgumentNullException.ThrowIfNull(context);
//         ArgumentNullException.ThrowIfNull(requirement);

//         var userName = context.User.Identity?.Name;

//         // if (!context.User.  .IsAuthenticated())
//         // {
//         //     metrics.SkipRequirement(nameof(GroupMembershipRequirement));
//         //     // logger.LogRequirementSkipped(
//         //     //     nameof(ParameterizedProtectedResourceRequirementHandler)
//         //     // );

//         //     return Task.CompletedTask;
//         // }

//         var clientId =
//             requirement.Resource
//             ?? keycloakOptions.Value.RolesResource
//             ?? keycloakOptions.Value.Resource;
//         requirement.Resource = clientId;

//         var success = false;

//         // if (string.IsNullOrWhiteSpace(clientId))
//         // {
//         //     metrics.ErrorRequirement(nameof(GroupMembershipRequirement));
//         //     throw new KeycloakException(
//         //         $"Unable to resolve Resource for Role Validation - please make sure {nameof(KeycloakAuthorizationOptions)} are configured. \n\n See documentation for more details - https://nikiforovall.github.io/keycloak-authorization-services-dotnet/configuration/configuration-authorization.html#require-resource-roles"
//         //     );
//         // }
//         var groups = context.User.Claims.Where(c => c.Type == "groups").Select(c=>c.Value);
//         if (
//             groups.Any()
//         )
//         {
//             success = groups.Intersect(requirement.Groups).Any();
//         }

//         // logger.LogAuthorizationResult(requirement.ToString()!, success, userName);

//         if (success)
//         {
//             metrics.SucceedRequirement(nameof(GroupMembershipRequirement));

//             context.Succeed(requirement);
//         }
//         else
//         {
//             metrics.FailRequirement(nameof(GroupMembershipRequirement));
//             // logger.LogAuthorizationFailed(requirement.ToString()!, userName);
//         }

//         return Task.CompletedTask;
//     }
// }
