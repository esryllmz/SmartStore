namespace SmartStore.Models.Dtos.Users.Requests;

public sealed record AddRoleToUserRequest(string UserId, string RoleName);
